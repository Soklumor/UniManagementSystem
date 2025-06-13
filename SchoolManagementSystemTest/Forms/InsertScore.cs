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

namespace SchoolManagementSystemTest.Forms;

public partial class InsertScore : Form
{
    private bool isModified = false;
    private SqlDataAdapter examScoreAdapter;
    DataSet? dataSet = new DataSet();
    public InsertScore()
    {
        InitializeComponent();
        LoadCombos();
        dateTime.Format = DateTimePickerFormat.Custom;
        dateTime.CustomFormat = "yyyy-MM-dd";
        this.Load += new System.EventHandler(this.YourForm_Load);
        dateTime.ValueChanged += selection;
        dataOne.CellFormatting += dataOne_CellFormatting;
        comboDepartment.SelectedIndexChanged += selection;
        comboClass.SelectedIndexChanged += selection;
        comboDepartment.SelectionChangeCommitted += ComboDepartment_SelectionChangeCommitted;
        comboClass.SelectionChangeCommitted += ComboClass_SelectionChangeCommitted;
        btnSaveScores.Click += BtnSaveScores_Click;
        this.FormClosing += FormResult_FormClosing;

    }
    private void LoadCombos()
    {
        var conn = HandleConnection.GetConnection();
        DataSet dataSet = new DataSet();

        // Load students
        SqlDataAdapter adapterStudents = new SqlDataAdapter("SELECT StudentID, FirstName, LastName FROM tbStudents", conn);
        adapterStudents.Fill(dataSet, "tbStudents");

        var dtStudents = dataSet.Tables["tbStudents"];
        if (!dtStudents.Columns.Contains("StudentName"))
        {
            dtStudents.Columns.Add("StudentName", typeof(string), "FirstName + ' ' + LastName");
        }
        // Load departments
        SqlDataAdapter adapterDepartments = new SqlDataAdapter("SELECT DepartmentID, DepartmentName FROM tbDepartments", conn);
        adapterDepartments.Fill(dataSet, "tbDepartments");

        var dtDepartments = dataSet.Tables["tbDepartments"];
        if (dtDepartments.PrimaryKey.Length == 0)
            dtDepartments.PrimaryKey = new DataColumn[] { dtDepartments.Columns["DepartmentID"] };

        comboDepartment.DataSource = dtDepartments;
        comboDepartment.DisplayMember = "DepartmentName";
        comboDepartment.ValueMember = "DepartmentID";
        // Load classes filtered by selected department
        LoadClasses();
        // Optionally set initial student ID textbox
    }
    private void selection(object? sender, EventArgs e)
    {
        using (var conn = HandleConnection.GetConnection())
        {
            string query = "SELECT * FROM dbo.fn_ExamResultsPivotFiltered(@FromDate, @DepartmentID, @ClassID)";
            using (SqlDataAdapter adapterShow = new SqlDataAdapter(query, conn))
            {
                adapterShow.SelectCommand.Parameters.AddWithValue("@FromDate", dateTime.Value);
                object selectedDept = comboDepartment.SelectedValue ?? DBNull.Value;
                object selectedClass = comboClass.SelectedValue ?? DBNull.Value;
                adapterShow.SelectCommand.Parameters.AddWithValue("@DepartmentID", selectedDept);
                adapterShow.SelectCommand.Parameters.AddWithValue("@ClassID", selectedClass);

                dataSet.Tables.Clear();
                adapterShow.Fill(dataSet, "tbExamScore");
                dataOne.DataSource = dataSet.Tables["tbExamScore"];
                this.examScoreAdapter = adapterShow;
            }
        }
        HideColumns();
    }


    private void SaveClosing()
    {
        using var conn = HandleConnection.GetConnection();
        if (conn.State != ConnectionState.Open)
            conn.Open();

        using SqlCommand cmd = new SqlCommand("sp_InsertSubjectScores", conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        DataTable scoreData = BuildExamScoresDataTable();

        var param = cmd.Parameters.AddWithValue("@ExamData", scoreData);
        param.SqlDbType = SqlDbType.Structured;
        param.TypeName = "ExamScoresForSubjects";

        cmd.ExecuteNonQuery();

        isModified = false;
    }


    private void FormResult_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (!isModified) return;

        if (!HasDataToSave())
        {
            // No data to save, just allow closing
            isModified = false;
            return;
        }

        var result = MessageBox.Show(
            "You have unsaved changes.\n\nDo you want to save before closing?",
            "Unsaved Changes",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
        else if (result == DialogResult.Yes)
        {
            SaveClosing();
        }
    }

    private void HideColumns()
    {
        string[] columnsToHide = { "StudentID", "ClassID", "DepartmentID", "ExamDate", "ClassName", "DepartmentName" };
        foreach (string col in columnsToHide)
        {
            if (dataOne.Columns.Contains(col))
                dataOne.Columns[col].Visible = false;
        }
    }
    private void YourForm_Load(object sender, EventArgs e)
    {
        // Set default to Jan 1 of last year (correct)
        dateTime.Value = new DateTime(DateTime.Now.Year - 1, 1, 1);

        // Hook the event to auto-refresh when date changes
        dateTime.ValueChanged += selection;

        // Load data immediately
        selection(null, null);
    }

    private void dataOne_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        string[] scoreColumns = { "Score_DataAnalysist", "Score_DataBase", "Score_CSharp", "Score_Network", "Score_WebApp" };

        if (e.Value == null || Convert.IsDBNull(e.Value) || (e.Value is decimal && (decimal)e.Value == 0))
        {
            if (e.ColumnIndex >= 0 && scoreColumns.Contains(dataOne.Columns[e.ColumnIndex].Name))
            {
                e.Value = "";      // Show empty instead of 0
                e.FormattingApplied = true;
            }
        }
    }

    private void LoadClasses()
    {
        var conn = HandleConnection.GetConnection();

        if (comboDepartment.SelectedValue == null) return;
        int selectedDepartmentID = Convert.ToInt32(comboDepartment.SelectedValue);

        SqlDataAdapter adapterClasses = new SqlDataAdapter("SELECT ClassID, ClassName FROM tbClasses WHERE DepartmentID = @deptID", conn);
        adapterClasses.SelectCommand.Parameters.AddWithValue("@deptID", selectedDepartmentID);

        DataSet dataSet = comboClass.DataSource as DataSet ?? new DataSet();

        if (dataSet.Tables.Contains("tbClasses"))
            dataSet.Tables["tbClasses"].Clear();

        adapterClasses.Fill(dataSet, "tbClasses");

        var dtClasses = dataSet.Tables["tbClasses"];
        if (dtClasses.PrimaryKey.Length == 0)
            dtClasses.PrimaryKey = new DataColumn[] { dtClasses.Columns["ClassID"] };

        comboClass.DataSource = dtClasses;
        comboClass.DisplayMember = "ClassName";
        comboClass.ValueMember = "ClassID";
    }
    private void LoadStudentsByClass()
    {
        if (comboClass.SelectedValue == null) return;

        int selectedClassID = Convert.ToInt32(comboClass.SelectedValue);
        var conn = HandleConnection.GetConnection();

        string query = "SELECT StudentID, FirstName, LastName FROM tbStudents WHERE ClassID = @classID";
        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
        adapter.SelectCommand.Parameters.AddWithValue("@classID", selectedClassID);

        DataSet studentSet = new DataSet();
        adapter.Fill(studentSet, "FilteredStudents");

        DataTable dtStudents = studentSet.Tables["FilteredStudents"];
        if (!dtStudents.Columns.Contains("StudentName"))
        {
            dtStudents.Columns.Add("StudentName", typeof(string), "FirstName + ' ' + LastName");
        }
    }
    private void ComboDepartment_SelectionChangeCommitted(object? sender, EventArgs e)
    {
        LoadClasses();
    }
    private void ComboClass_SelectionChangeCommitted(object? sender, EventArgs e)
    {
        LoadStudentsByClass();
        selection(null, null);
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
    private DataTable BuildExamScoresDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("StudentID", typeof(string));
        dt.Columns.Add("DepartmentID", typeof(int));
        dt.Columns.Add("ClassID", typeof(int));
        dt.Columns.Add("ExamDate", typeof(DateTime));  // Keep as DateTime
        dt.Columns.Add("Score_DataAnalysist", typeof(decimal));
        dt.Columns.Add("Score_DataBase", typeof(decimal));
        dt.Columns.Add("Score_CSharp", typeof(decimal));
        dt.Columns.Add("Score_Network", typeof(decimal));
        dt.Columns.Add("Score_WebApp", typeof(decimal));
        foreach (DataGridViewRow row in dataOne.Rows)
        {
            if (row.IsNewRow) continue;

            string studentId = row.Cells["StudentID"].Value?.ToString() ?? "";
            int deptId = Convert.ToInt32(comboDepartment.SelectedValue);
            int classId = Convert.ToInt32(comboClass.SelectedValue);
            DateTime examDate = dateTime.Value;

            decimal scoreDataAnalysist = TryParseDecimal(row.Cells["DataAnalysist"].Value);
            decimal scoreDataBase = TryParseDecimal(row.Cells["DataBase"].Value);
            decimal scoreCSharp = TryParseDecimal(row.Cells["CSharp"].Value);
            decimal scoreNetwork = TryParseDecimal(row.Cells["Network"].Value);
            decimal scoreWebApp = TryParseDecimal(row.Cells["WebApp"].Value);

            dt.Rows.Add(studentId, deptId, classId, examDate,
                        scoreDataAnalysist, scoreDataBase, scoreCSharp, scoreNetwork, scoreWebApp);
        }
        return dt;
    }
    private bool HasDataToSave()
    {
        return dataOne.Rows.Cast<DataGridViewRow>()
                   .Any(row => !row.IsNewRow &&
                              !string.IsNullOrEmpty(row.Cells["StudentID"].Value?.ToString()));
    }



    private decimal TryParseDecimal(object? value)
    {
        if (value == null) return 0m;
        if (decimal.TryParse(value.ToString(), out decimal result))
            return result;
        return 0m;
    }
    //private void InsertScoresBatch()
    //{
    //    using var conn = HandleConnection.GetConnection();
    //    using SqlCommand cmd = new SqlCommand("sp_InsertSubjectScores", conn)
    //    {
    //        CommandType = CommandType.StoredProcedure
    //    };
    //    DataTable examScores = BuildExamScoresDataTable();
    //    var param = cmd.Parameters.AddWithValue("@ExamData", examScores);
    //    param.SqlDbType = SqlDbType.Structured;
    //    param.TypeName = "dbo.ExamScoresForSubjects";         
    //    cmd.ExecuteNonQuery();
    //}
}
