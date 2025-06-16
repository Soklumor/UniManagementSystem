using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SchoolManagementSystemTest.Forms
{
    public partial class FormSchedule : Form
    {
        private bool isClearing = false;

        public FormSchedule()
        {
            InitializeComponent();

            isClearing = true;
            LoadComboBoxes();
            isClearing = false;

            comboSubject.SelectedIndexChanged += ComboBoxes_SelectedIndexChanged;
            comboClass.SelectedIndexChanged += ComboBoxes_SelectedIndexChanged;
            comboDepartment.SelectedIndexChanged += ComboBoxes_SelectedIndexChanged;
            comboday.SelectedIndexChanged += ComboBoxes_SelectedIndexChanged;
            comboInstructor.SelectedIndexChanged += ComboBoxes_SelectedIndexChanged;

            Selection();
            HideColumns();

            dataOne.SelectionChanged += dataSelectionChange;

            TimeStart.Format = DateTimePickerFormat.Time;
            TimeStart.ShowUpDown = true;
            TimeEnd.Format = DateTimePickerFormat.Time;
            TimeEnd.ShowUpDown = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            isClearing = true;

            comboSubject.SelectedIndex = -1;
            comboClass.SelectedIndex = -1;
            comboDepartment.SelectedIndex = -1;
            comboday.SelectedIndex = -1;
            comboInstructor.SelectedIndex = -1;

            title.Text = "";

            TimeStart.Value = DateTime.Now;
            TimeEnd.Value = DateTime.Now;

            isClearing = false;
        }

        private void Selection()
        {
            using var conn = HandleConnection.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("SELECT * FROM vw_ScheduleDetails", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataOne.DataSource = null;
            dataOne.DataSource = table;
        }

        private void LoadComboBoxes()
        {
            using var conn = HandleConnection.GetConnection();

            // Load Subjects
            var subjectAdapter = new SqlDataAdapter("SELECT SubjectID, SubjectName FROM tbSubjects", conn);
            var subjectTable = new DataTable();
            subjectAdapter.Fill(subjectTable);
            comboSubject.DataSource = subjectTable;
            comboSubject.ValueMember = "SubjectID";
            comboSubject.DisplayMember = "SubjectName";

            // Load Classes
            var classAdapter = new SqlDataAdapter("SELECT ClassID, ClassName FROM tbClasses", conn);
            var classTable = new DataTable();
            classAdapter.Fill(classTable);
            comboClass.DataSource = classTable;
            comboClass.ValueMember = "ClassID";
            comboClass.DisplayMember = "ClassName";

            // Load Departments
            var deptAdapter = new SqlDataAdapter("SELECT DepartmentID, DepartmentName FROM tbDepartments", conn);
            var deptTable = new DataTable();
            deptAdapter.Fill(deptTable);
            comboDepartment.DataSource = deptTable;
            comboDepartment.ValueMember = "DepartmentID";
            comboDepartment.DisplayMember = "DepartmentName";

            // Load Days
            var dayAdapter = new SqlDataAdapter("SELECT DISTINCT Day FROM tbSchedule ORDER BY Day", conn);
            var dayTable = new DataTable();
            dayAdapter.Fill(dayTable);
            comboday.DataSource = dayTable;
            comboday.DisplayMember = "Day";
            comboday.ValueMember = "Day";

            // Load Instructors
            var instructorAdapter = new SqlDataAdapter("SELECT InstructorID, (FirstName + ' '+ LastName ) AS InstructorName FROM tbInstructors", conn);
            var instructorTable = new DataTable();
            instructorAdapter.Fill(instructorTable);
            comboInstructor.DataSource = instructorTable;
            comboInstructor.ValueMember = "InstructorID";
            comboInstructor.DisplayMember = "InstructorName";
        }

        private void HideColumns()
        {
            string[] columnsToHide = { "SubjectID", "ClassID", "DepartmentID", "ScheduleID", "Title" };
            foreach (string col in columnsToHide)
            {
                if (dataOne.Columns.Contains(col))
                    dataOne.Columns[col].Visible = false;
            }
        }

        private void dataSelectionChange(object? sender, EventArgs e)
        {
            if (dataOne.SelectedRows.Count > 0)
            {
                var selection = dataOne.SelectedRows[0];
                if (selection == null) return;

                isClearing = true;

                // Set Instructor ComboBox from selected row
                var instructorValue = selection.Cells["InstructorID"]?.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(instructorValue) &&
                    comboInstructor.Items.Cast<DataRowView>().Any(r => r["InstructorID"].ToString() == instructorValue))
                {
                    comboInstructor.SelectedValue = instructorValue;
                }
                else
                {
                    comboInstructor.SelectedIndex = -1;
                }

                // Set other combos
                var dayValue = selection.Cells["Day"]?.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(dayValue) &&
                    comboday.Items.Cast<DataRowView>().Any(r => r["Day"].ToString() == dayValue))
                {
                    comboday.SelectedValue = dayValue;
                }
                else
                {
                    comboday.SelectedIndex = -1;
                }

                var subjectValue = selection.Cells["SubjectID"]?.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(subjectValue) &&
                    comboSubject.Items.Cast<DataRowView>().Any(r => r["SubjectID"].ToString() == subjectValue))
                {
                    comboSubject.SelectedValue = subjectValue;
                }
                else
                {
                    comboSubject.SelectedIndex = -1;
                }

                var classValue = selection.Cells["ClassID"]?.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(classValue) &&
                    comboClass.Items.Cast<DataRowView>().Any(r => r["ClassID"].ToString() == classValue))
                {
                    comboClass.SelectedValue = classValue;
                }
                else
                {
                    comboClass.SelectedIndex = -1;
                }

                var deptValue = selection.Cells["DepartmentID"]?.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(deptValue) &&
                    comboDepartment.Items.Cast<DataRowView>().Any(r => r["DepartmentID"].ToString() == deptValue))
                {
                    comboDepartment.SelectedValue = deptValue;
                }
                else
                {
                    comboDepartment.SelectedIndex = -1;
                }

                title.Text = selection.Cells["Title"]?.Value?.ToString() ?? "";

                SetDateTimePickerValue(TimeStart, selection.Cells["TimeStart"]?.Value);
                SetDateTimePickerValue(TimeEnd, selection.Cells["TimeEnd"]?.Value);

                isClearing = false;
            }
            else
            {
                ClearFields();
            }
        }

        private void ComboBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isClearing) return;

            UpdateAllColumnsValues();
        }

        private void UpdateAllColumnsValues()
        {
            if (dataOne.SelectedRows.Count == 0) return;

            var row = dataOne.SelectedRows[0];

            var updates = new System.Collections.Generic.Dictionary<string, string>()
            {
                { "SubjectName", comboSubject.Text },
                { "ClassName", comboClass.Text },
                { "DepartmentName", comboDepartment.Text },
                { "Day", comboday.Text },
                { "InstructorName", comboInstructor.Text },

                { "SubjectID", comboSubject.SelectedValue?.ToString() ?? "" },
                { "ClassID", comboClass.SelectedValue?.ToString() ?? "" },
                { "DepartmentID", comboDepartment.SelectedValue?.ToString() ?? "" },
                { "InstructorID", comboInstructor.SelectedValue?.ToString() ?? "" }
            };

            foreach (var kvp in updates)
            {
                var colName = kvp.Key;
                var val = kvp.Value;

                if (dataOne.Columns.Contains(colName))
                {
                    row.Cells[colName].Value = val;
                }
            }
        }

        private void SetDateTimePickerValue(DateTimePicker picker, object value)
        {
            if (value == null || value == DBNull.Value)
            {
                picker.Value = DateTime.Now;
            }
            else if (value is TimeSpan ts)
            {
                picker.Value = DateTime.Today.Add(ts);
            }
            else
            {
                picker.Value = Convert.ToDateTime(value);
            }
        }

        private void logout(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSchedule_Load(object sender, EventArgs e)
        {
            // Optional code on form load
        }
    }
}
