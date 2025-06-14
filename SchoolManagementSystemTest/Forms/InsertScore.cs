using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SchoolManagementSystemTest.Models;

namespace SchoolManagementSystemTest.Forms
{
    public partial class InsertScore : Form
    {
        private bool isModified = false;
        private readonly HashSet<int> modifiedRows = new();
        private SqlDataAdapter examScoreAdapter;
        private DataSet dataSet = new();

        public InsertScore()
        {
            InitializeComponent();
            LoadCombos();

            dateTime.Format = DateTimePickerFormat.Custom;
            dateTime.CustomFormat = "yyyy-MM-dd";
            dateTime.Value = new DateTime(DateTime.Now.Year - 1, 1, 1);

            // Events
            Load += YourForm_Load;
            dateTime.ValueChanged += selection;
            comboDepartment.SelectedIndexChanged += selection;
            comboClass.SelectedIndexChanged += selection;
            comboDepartment.SelectionChangeCommitted += ComboDepartment_SelectionChangeCommitted;
            comboClass.SelectionChangeCommitted += ComboClass_SelectionChangeCommitted;
            btnSaveScores.Click += BtnSaveScores_Click;
            FormClosing += FormResult_FormClosing;
            dataOne.CellFormatting += dataOne_CellFormatting;
            dataOne.DataBindingComplete += FormatExamDate;
            dataOne.CellValueChanged += TrackModifiedRows;
            dataOne.CurrentCellDirtyStateChanged += CommitCellEdit;
            dataOne.SelectionChanged += dataselectoinChange;
            dataOne.DataError += dataOne_DataError;
            dataOne.CellBeginEdit += dataOne_CellBeginEdit;

        }

        private void LoadCombos()
        {
            var conn = HandleConnection.GetConnection();

            SqlDataAdapter adapterStudents = new("SELECT StudentID, FirstName, LastName FROM tbStudents", conn);
            adapterStudents.Fill(dataSet, "tbStudents");

            var dtStudents = dataSet.Tables["tbStudents"];
            if (!dtStudents.Columns.Contains("StudentName"))
                dtStudents.Columns.Add("StudentName", typeof(string), "FirstName + ' ' + LastName");

            SqlDataAdapter adapterDepartments = new("SELECT DepartmentID, DepartmentName FROM tbDepartments", conn);
            adapterDepartments.Fill(dataSet, "tbDepartments");

            var dtDepartments = dataSet.Tables["tbDepartments"];
            if (dtDepartments.PrimaryKey.Length == 0)
                dtDepartments.PrimaryKey = new[] { dtDepartments.Columns["DepartmentID"] };

            comboDepartment.DataSource = dtDepartments;
            comboDepartment.DisplayMember = "DepartmentName";
            comboDepartment.ValueMember = "DepartmentID";

            LoadClasses();
        }

        private void LoadClasses()
        {
            if (comboDepartment.SelectedValue == null) return;

            int selectedDepartmentID = Convert.ToInt32(comboDepartment.SelectedValue);
            var conn = HandleConnection.GetConnection();

            SqlDataAdapter adapterClasses = new("SELECT ClassID, ClassName FROM tbClasses WHERE DepartmentID = @deptID", conn);
            adapterClasses.SelectCommand.Parameters.AddWithValue("@deptID", selectedDepartmentID);

            if (dataSet.Tables.Contains("tbClasses"))
                dataSet.Tables["tbClasses"].Clear();

            adapterClasses.Fill(dataSet, "tbClasses");

            var dtClasses = dataSet.Tables["tbClasses"];
            if (dtClasses.PrimaryKey.Length == 0)
                dtClasses.PrimaryKey = new[] { dtClasses.Columns["ClassID"] };

            comboClass.DataSource = dtClasses;
            comboClass.DisplayMember = "ClassName";
            comboClass.ValueMember = "ClassID";
        }

        private void selection(object? sender, EventArgs e)
        {
            using var conn = HandleConnection.GetConnection();


            string query = "SELECT * FROM dbo.fn_ExamResultsPivotFiltered(@FromDate, @DepartmentID, @ClassID)";
            using var adapter = new SqlDataAdapter(query, conn);

            adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dateTime.Value);
            adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", comboDepartment.SelectedValue ?? DBNull.Value);
            adapter.SelectCommand.Parameters.AddWithValue("@ClassID", comboClass.SelectedValue ?? DBNull.Value);

            if (dataSet.Tables.Contains("tbExamScore"))
                dataSet.Tables["tbExamScore"].Clear();
            adapter.Fill(dataSet, "tbExamScore");
            dataOne.DataSource = null;
            dataOne.DataSource = dataSet.Tables["tbExamScore"];
            examScoreAdapter = adapter;

            HideColumns();
        }

        private void HideColumns()
        {
            string[] hiddenColumns = { "StudentID", "ClassID", "DepartmentID", "ClassName", "DepartmentName" };
            foreach (var col in hiddenColumns)
            {
                if (dataOne.Columns.Contains(col))
                    dataOne.Columns[col].Visible = false;
            }
        }

        private void FormatExamDate(object? sender, EventArgs e)
        {
            if (dataOne.Columns.Contains("ExamDate"))
            {
                dataOne.Columns["ExamDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }

        private void dataOne_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            string[] scoreColumns = { "Score_DataAnalysist", "Score_DataBase", "Score_CSharp", "Score_Network", "Score_WebApp" };

            if (e.Value == null || Convert.IsDBNull(e.Value) || (e.Value is decimal d && d == 0))
            {
                if (e.ColumnIndex >= 0 && scoreColumns.Contains(dataOne.Columns[e.ColumnIndex].Name))
                {
                    e.Value = string.Empty;
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataselectoinChange(object? sender, EventArgs e)
        {
            if (dataOne.CurrentRow is { IsNewRow: false } row)
            {
                studentID.Text = row.Cells["StudentID"]?.Value?.ToString() ?? "";
                studentName.Text = row.Cells["StudentName"]?.Value?.ToString() ?? "";
            }
        }

        private void TrackModifiedRows(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dataOne.Rows[e.RowIndex].IsNewRow)
            {
                isModified = true;
                modifiedRows.Add(e.RowIndex);
            }
        }

        private void CommitCellEdit(object? sender, EventArgs e)
        {
            if (dataOne.IsCurrentCellDirty)
            {
                dataOne.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void FormResult_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!isModified || !HasDataToSave()) return;

            var result = MessageBox.Show(
                "You have unsaved changes.\n\nDo you want to save before closing?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
                SaveClosing();
            }
        }
        private void dataOne_DataError(object? sender, DataGridViewDataErrorEventArgs e)
{
    // Suppress the error during editing
    if (e.Context.HasFlag(DataGridViewDataErrorContexts.Commit) ||
        e.Context.HasFlag(DataGridViewDataErrorContexts.Parsing))
    {
        e.Cancel = true;
        // Optionally show message AFTER editing is done, like in CellEndEdit
    }
}


        private Dictionary<int, DateTime> originalExamDates = new Dictionary<int, DateTime>();

        // Call this when the user begins editing a row or cell to store the old ExamDate
        private void dataOne_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dataOne.Columns["ExamDate"].Index)
            {
                var row = dataOne.Rows[e.RowIndex];
                if (!originalExamDates.ContainsKey(e.RowIndex))
                {
                    DateTime oldDate;
                    if (DateTime.TryParse(row.Cells["ExamDate"].Value?.ToString(), out oldDate))
                    {
                        originalExamDates[e.RowIndex] = oldDate;
                    }
                }
            }
        }

        private void SaveClosing()
        {
            dataOne.EndEdit();

            using var conn = HandleConnection.GetConnection();

            var subjectMap = new Dictionary<string, int>
    {
        { "DataAnalysist", 1 },
        { "DataBase", 2 },
        { "CSharp", 3 },
        { "Network", 4 },
        { "WebApp", 5 }
    };

            foreach (int rowIndex in modifiedRows)
            {
                var row = dataOne.Rows[rowIndex];
                if (row.IsNewRow) continue;

                string? studentId = row.Cells["StudentID"]?.Value?.ToString()?.Trim();
                if (string.IsNullOrEmpty(studentId)) continue;

                DateTime newExamDate;
                if (!DateTime.TryParse(row.Cells["ExamDate"]?.Value?.ToString(), out newExamDate))
                {
                    newExamDate = DateTime.Now.Date; // fallback
                }
                newExamDate = newExamDate.Date;

                if (!originalExamDates.TryGetValue(rowIndex, out DateTime oldExamDate))
                {
                    oldExamDate = newExamDate; // fallback, or skip update if you want
                }

                int deptId = Convert.ToInt32(comboDepartment.SelectedValue);
                int classId = Convert.ToInt32(comboClass.SelectedValue);

                foreach (var (subject, subjectId) in subjectMap)
                {
                    if (!dataOne.Columns.Contains(subject)) continue;

                    decimal score = TryParseDecimal(row.Cells[subject]?.Value);

                    using var cmd = new SqlCommand("sp_UpsertExamResult", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@DepartmentID", deptId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@SubjectID", subjectId);
                    cmd.Parameters.AddWithValue("@OldExamDate", oldExamDate);
                    cmd.Parameters.AddWithValue("@NewExamDate", newExamDate);
                    cmd.Parameters.AddWithValue("@Score", score);

                    cmd.ExecuteNonQuery();
                }
            }

            originalExamDates.Clear();
            modifiedRows.Clear();
            isModified = false;
        }


        private void BtnSaveScores_Click(object? sender, EventArgs e)
        {
            if (!HasDataToSave())
            {
                MessageBox.Show("No data to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                SaveClosing();
                MessageBox.Show("Scores saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving scores:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasDataToSave()
        {
            return dataOne.Rows.Cast<DataGridViewRow>().Any(row =>
                !row.IsNewRow && !string.IsNullOrEmpty(row.Cells["StudentID"].Value?.ToString()));
        }

        private decimal TryParseDecimal(object? value)
        {
            return decimal.TryParse(value?.ToString(), out decimal result) ? result : 0;
        }

        private void LoadStudentsByClass()
        {
            if (comboClass.SelectedValue == null) return;

            int classId = Convert.ToInt32(comboClass.SelectedValue);
            var conn = HandleConnection.GetConnection();

            SqlDataAdapter adapter = new("SELECT StudentID, FirstName, LastName FROM tbStudents WHERE ClassID = @classID", conn);
            adapter.SelectCommand.Parameters.AddWithValue("@classID", classId);

            DataSet studentSet = new();
            adapter.Fill(studentSet, "FilteredStudents");

            var dt = studentSet.Tables["FilteredStudents"];
            if (!dt.Columns.Contains("StudentName"))
            {
                dt.Columns.Add("StudentName", typeof(string), "FirstName + ' ' + LastName");
            }
        }

        private void ComboDepartment_SelectionChangeCommitted(object? sender, EventArgs e) => LoadClasses();

        private void ComboClass_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            LoadStudentsByClass();
            selection(null, null);
        }

        private void YourForm_Load(object? sender, EventArgs e)
        {
            selection(null, null);
        }

        private void InsertScore_Load(object sender, EventArgs e) { }
    }
}
