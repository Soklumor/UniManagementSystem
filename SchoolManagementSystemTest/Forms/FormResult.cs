using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SchoolManagementSystemTest.Forms;
using SchoolManagementSystemTest.Models;

namespace SchoolManagementSystemTest;

public partial class FormResult : Form
{
    private HashSet<int> modifiedRows = new HashSet<int>();

    DataSet dataSet = new DataSet();
    SqlDataAdapter adapter = new();
    private bool isModified = false;
    private readonly string connString = $"Server=DESKTOP-IBQJ98S\\SQLEXPRESS;Database=sms;Trusted_Connection=true;TrustServerCertificate=true;";

    public FormResult()
    {
        InitializeComponent();
        comboLoad();
        Selection();
        dataOne.SelectionChanged += dataselectoinChange;
        dataOne.KeyDown += dataOne_KeyDown;
        dataOne.EditMode = DataGridViewEditMode.EditOnEnter;
        btnSave.Click += btnSave_Click;
        btnInsert.Click += changeform;
        this.Load += (s, e) => FocusFirstCell();
        this.FormClosing += FormResult_FormClosing;
        dataOne.DataBindingComplete += DataOne_DataBindingComplete;
        comboDepartment.SelectedIndexChanged += comboDepartment_SelectedIndexChanged;
        comboClass.SelectedIndexChanged -= comboClass_SelectedIndexChanged;
        comboClass.SelectedIndexChanged += comboClass_SelectedIndexChanged;
        dataOne.CellValueChanged += DataOne_CellValueChanged;
        btnReload.Click += Reload;
        dataOne.CellValueChanged += (s, e) => isModified = true;
        dataOne.CurrentCellDirtyStateChanged += (s, e) =>
        {
            if (dataOne.IsCurrentCellDirty)
                dataOne.CommitEdit(DataGridViewDataErrorContexts.Commit);
        };
        dataOne.DataBindingComplete += (s, e) =>
        {
            if (dataOne.Columns.Contains("ExamDate"))
            {
                dataOne.Columns["ExamDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        };

        formatdate();
        begindate.ValueChanged += DateFilterChanged;
        enddate.ValueChanged += DateFilterChanged;
    }
    

    private void Reload(object? sender, EventArgs e)
    {
        SearchByDateRange();
    }
    private void comboLoad()
    {
        using var conn = new SqlConnection(connString);
        conn.Open();

        SqlDataAdapter adapterDepartment = new SqlDataAdapter("SELECT * FROM tbDepartments", conn);
        adapterDepartment.Fill(dataSet, "tbDepartments");

        comboDepartment.DataSource = dataSet.Tables["tbDepartments"];
        comboDepartment.ValueMember = "DepartmentID";
        comboDepartment.DisplayMember = "DepartmentName";

        SqlDataAdapter adapterClass = new SqlDataAdapter("SELECT * FROM tbClasses", conn);
        adapterClass.Fill(dataSet, "tbClasses");

        comboClass.DataSource = dataSet.Tables["tbClasses"];
        comboClass.DisplayMember = "ClassName";
        comboClass.ValueMember = "ClassID";
    }
    private void SearchByDateRange()
    {
        selection(true);
    }
    private void Selection()
    {
        selection(false);
    }
    private void selection(bool useFilter)
    {
        var results = new List<ExamResultsPivot>();
        using var conn = new SqlConnection(connString);
        conn.Open();
        string query = @"
        SELECT * FROM vw_ExamResultsPivot
        WHERE CAST(ExamDate AS DATE) BETWEEN @StartDate AND @EndDate";

        if (useFilter)
        {
            query += " AND DepartmentID = @DepartmentID AND ClassID = @ClassID";
        }

        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            DateTime startDate;
            DateTime endDate;

            if (useFilter)
            {
                startDate = begindate.Value.Date;
                endDate = enddate.Value.Date;

                if (startDate > endDate)
                {
                    MessageBox.Show("Start date cannot be after end date.",
                                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                begindate.Format = DateTimePickerFormat.Custom;
                begindate.CustomFormat = "yyyy-MM-dd";
                enddate.Format = DateTimePickerFormat.Custom;
                enddate.CustomFormat = "yyyy-MM-dd";

                if (comboDepartment.SelectedValue == null || comboClass.SelectedValue == null)
                {
                    MessageBox.Show("Please select both a department and a class.");
                    return;
                }

                int departmentId = Convert.ToInt32(comboDepartment.SelectedValue);
                int classId = Convert.ToInt32(comboClass.SelectedValue);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentId;
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classId;
            }
            else
            {
                endDate = DateTime.Today;
                startDate = new DateTime(endDate.Year - 1, endDate.Month, 1);
            }

            cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var examResult = new ExamResultsPivot
                    {
                        StudentID = reader.GetString(reader.GetOrdinal("StudentID")),
                        StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                        ClassName = reader.GetString(reader.GetOrdinal("ClassName")),
                        DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName")),
                        ClassID = reader.GetInt32(reader.GetOrdinal("ClassID")),
                        DepartmentID = reader.GetInt32(reader.GetOrdinal("DepartmentID")),
                        DataAnalysist = reader.IsDBNull(reader.GetOrdinal("DataAnalysist"))
                                        ? (decimal?)null
                                        : reader.GetDecimal(reader.GetOrdinal("DataAnalysist")),
                        Database = reader.IsDBNull(reader.GetOrdinal("Database"))
                                   ? (decimal?)null
                                   : reader.GetDecimal(reader.GetOrdinal("Database")),
                        CSharp = reader.IsDBNull(reader.GetOrdinal("CSharp"))
                                 ? (decimal?)null
                                 : reader.GetDecimal(reader.GetOrdinal("CSharp")),
                        Network = reader.IsDBNull(reader.GetOrdinal("Network"))
                                  ? (decimal?)null
                                  : reader.GetDecimal(reader.GetOrdinal("Network")),
                        WebApp = reader.IsDBNull(reader.GetOrdinal("WebApp"))
                                 ? (decimal?)null
                                 : reader.GetDecimal(reader.GetOrdinal("WebApp")),
                        TotalScore = reader.GetDecimal(reader.GetOrdinal("TotalScore")),
                        ExamDate = reader.GetDateTime(reader.GetOrdinal("ExamDate")),
                    };

                    results.Add(examResult);
                }
            }
        }

        // Bind list to DataGridView
        dataOne.DataSource = null;
        dataOne.DataSource = results;

        if (results.Count == 0)
        {
            HideColumns();
            MessageBox.Show("No results found for the selected criteria.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        HideColumns();
        DisplayFirstRowDetails();
        SetEditableColumns();
    }


    private void DateFilterChanged(object? sender, EventArgs e)
    {
        if (!dataOne.IsHandleCreated)
        {
            dataOne.HandleCreated += (s, args) =>
            {
                dataOne.HandleCreated -= (EventHandler)s;
                DateFilterChanged(sender, e);
            };
            return;
        }

        this.BeginInvoke((MethodInvoker)(() =>
        {
            SearchByDateRange();
        }));
    }

    private void formatdate()
    {
        begindate.Format = DateTimePickerFormat.Custom;
        begindate.CustomFormat = "yyyy-MM-dd";
        begindate.Value = new DateTime(DateTime.Today.Year - 1, DateTime.Today.Month, 1);
        enddate.Format = DateTimePickerFormat.Custom;
        enddate.CustomFormat = "yyyy-MM-dd";
        enddate.Value = DateTime.Today;
    }
    private void comboDepartment_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboDepartment.SelectedValue == null || !(comboDepartment.SelectedValue is int departmentId))
            return;

        using var conn = new SqlConnection(connString);
        conn.Open();

        string query = "SELECT * FROM tbClasses WHERE DepartmentID = @DepartmentID";

        SqlDataAdapter adapterClass = new SqlDataAdapter(query, conn);
        adapterClass.SelectCommand.Parameters.AddWithValue("@DepartmentID", departmentId);

        if (dataSet.Tables.Contains("tbClasses"))
            dataSet.Tables["tbClasses"].Clear();

        adapterClass.Fill(dataSet, "tbClasses");

        comboClass.DataSource = dataSet.Tables["tbClasses"];
        comboClass.DisplayMember = "ClassName";
        comboClass.ValueMember = "ClassID";

        if (comboClass.Items.Count > 0)
        {
            comboClass.SelectedIndex = 0;
            comboClass_SelectedIndexChanged(comboClass, EventArgs.Empty); // manually trigger
        }
        else
        {
            dataOne.DataSource = null; // 🧹 Clear the grid if no class
        }
    }

    private void comboClass_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboClass.SelectedValue != null)
            SearchByDateRange();
    }


    private void HideColumns()
    {
        string[] columnsToHide = { "StudentID", "ClassID", "DepartmentID", "ClassName", "DepartmentName" };
        foreach (string col in columnsToHide)
        {
            if (dataOne.Columns.Contains(col))
                dataOne.Columns[col].Visible = false;
        }
    }
    private void DisplayFirstRowDetails()
    {
        if (dataOne.Rows.Count > 0)
        {
            var firstRow = dataOne.Rows[0];
            if (!firstRow.IsNewRow)
            {
                studentID.Text = firstRow.Cells["StudentID"]?.Value?.ToString() ?? "";
                studentName.Text = firstRow.Cells["StudentName"]?.Value?.ToString() ?? "";
                departmentName.Text = firstRow.Cells["DepartmentName"]?.Value?.ToString() ?? "";
                className.Text = firstRow.Cells["ClassName"]?.Value?.ToString() ?? "";
            }
        }
    }

    private void SetEditableColumns()
    {
        foreach (DataGridViewColumn col in dataOne.Columns)
        {
            col.ReadOnly = !(col.Name == "DataAnalysist" || col.Name == "Database" ||
                             col.Name == "CSharp" || col.Name == "Network" || col.Name == "WebApp");
        }
    }

    private void FocusFirstCell()
    {
        if (dataOne.Rows.Count == 0) return;

        this.BeginInvoke((MethodInvoker?)(() =>
        {
            dataOne.Focus();
            dataOne.ClearSelection();

            int firstRowIndex = dataOne.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => r.Index)
                .FirstOrDefault();

            var firstEditableColumn = dataOne.Columns
                .Cast<DataGridViewColumn?>()
                .Where(c => c.Visible && !c.ReadOnly && c.Name != "StudentName")
                .FirstOrDefault();

            if (firstEditableColumn == null || firstRowIndex < 0)
                return;

            var cell = dataOne.Rows[firstRowIndex].Cells[firstEditableColumn.Index];
            dataOne.CurrentCell = cell;
            cell.Selected = true;
            dataOne.BeginEdit(true);
        }));
    }

    private void DataOne_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        FocusFirstCell();
    }

    private void dataOne_KeyDown(object? sender, KeyEventArgs e)
    {
        int rowCount = dataOne.Rows.Count;
        if (dataOne.AllowUserToAddRows) rowCount--;

        if (rowCount == 0) return;

        int currentIndex = dataOne.CurrentRow?.Index ?? -1;

        if (e.KeyCode == Keys.Down && currentIndex == rowCount - 1)
        {
            this.BeginInvoke((MethodInvoker)(() => WrapToRow(0)));
            e.Handled = true;
        }
        else if (e.KeyCode == Keys.Up && currentIndex == 0)
        {
            this.BeginInvoke((MethodInvoker)(() => WrapToRow(rowCount - 1)));
            e.Handled = true;
        }
    }

    private void WrapToRow(int targetIndex)
    {
        var firstColumn = dataOne.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Visible);
        if (firstColumn == null || targetIndex < 0 || targetIndex >= dataOne.Rows.Count)
            return;

        dataOne.ClearSelection();
        dataOne.CurrentCell = dataOne.Rows[targetIndex].Cells[firstColumn.Index];
        dataOne.Rows[targetIndex].Selected = true;

        var row = dataOne.Rows[targetIndex];
        if (!row.IsNewRow)
        {
            studentID.Text = row.Cells["StudentID"]?.Value?.ToString() ?? "";
            studentName.Text = row.Cells["StudentName"]?.Value?.ToString() ?? "";
            departmentName.Text = row.Cells["DepartmentName"]?.Value?.ToString() ?? "";
            className.Text = row.Cells["ClassName"]?.Value?.ToString() ?? "";
        }
    }

    private void dataselectoinChange(object? sender, EventArgs e)
    {
        if (dataOne.CurrentRow != null && !dataOne.CurrentRow.IsNewRow)
        {
            var row = dataOne.CurrentRow;
            studentID.Text = row.Cells["StudentID"]?.Value?.ToString() ?? "";
            studentName.Text = row.Cells["StudentName"]?.Value?.ToString() ?? "";
            departmentName.Text = row.Cells["DepartmentName"]?.Value?.ToString() ?? "";
            className.Text = row.Cells["ClassName"]?.Value?.ToString() ?? "";
        }
    }
    private async void btnSave_Click(object? sender, EventArgs e)
    {
        await Task.Run(() => SaveClosing());
        MessageBox.Show("Scores updated successfully.");
        SearchByDateRange();
    }

    private void SaveClosing()
    {
        using var conn = new SqlConnection(connString);
        conn.Open();

        var subjects = new Dictionary<string, int>
    {
        { "DataAnalysist", 1 },
        { "Database", 2 },
        { "CSharp", 3 },
        { "Network", 4 },
        { "WebApp", 5 }
    };

        foreach (int rowIndex in modifiedRows)
        {
            var row = dataOne.Rows[rowIndex];
            if (row.IsNewRow) continue;

            string? studentId = row.Cells["StudentID"].Value?.ToString();
            if (string.IsNullOrEmpty(studentId)) continue;

            // Parse exam date from the cell:
            DateTime examDate;
            object? dateCellValue = row.Cells["ExamDate"].Value;
            if (dateCellValue == null || !DateTime.TryParse(dateCellValue.ToString(), out examDate))
            {
                // Handle missing or invalid date (skip or set default)
                continue;
            }

            foreach (var subject in subjects)
            {
                if (!dataOne.Columns.Contains(subject.Key)) continue;

                double.TryParse(row.Cells[subject.Key].Value?.ToString(), out double score);

                using SqlCommand cmd = new SqlCommand(
                    "UPDATE ExamResults SET Score = @Score WHERE StudentID = @StudentID AND SubjectID = @SubjectID AND ExamDate = @ExamDate",
                    conn);
                cmd.Parameters.AddWithValue("@Score", score);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.Parameters.AddWithValue("@SubjectID", subject.Value);
                cmd.Parameters.AddWithValue("@ExamDate", examDate);

                cmd.ExecuteNonQuery();
            }
        }
        modifiedRows.Clear();
        isModified = false;
    }
    private void DataOne_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        modifiedRows.Add(e.RowIndex);
        isModified = true;
    }

    private void FormResult_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (isModified)
        {
            var result = MessageBox.Show("You have unsaved changes. Do you want to save before closing?",
                                         "Confirm Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                btnSave_Click(sender, EventArgs.Empty);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true; // Cancel closing
            }
        }
    }
    private void changeform(object? sender, EventArgs e)
    {
        SaveClosing();
        this.Hide(); 
        using (InsertScore insertScore = new InsertScore())
        {
            insertScore.ShowDialog();
        }
        this.Show();
    }
    private void Logout(object sender, EventArgs e)
    {
        SaveClosing();
        this.Close();
    }
}
