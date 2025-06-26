using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystemTest.Forms
{
    public partial class EnrollmentForm : Form
    {
        public EnrollmentForm()
        {
            InitializeComponent();
            Load += EnrollmentForm_Load;
        }



        private void EnrollmentForm_Load(object? sender, EventArgs e)
        {
            comboGender.Items.AddRange(new[] { "Male", "Female" });
            comboStatus.Items.AddRange(new[] { "Work", "No Work" });

            // Optional: Prevent user from typing custom values
            comboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnInsert_Click(object? sender, EventArgs e)
        {
            string studentId = txtStudentID.Text;
            string nameEn = comboStudentEN.Text;
            string nameKh = comboStudentKH.Text;
            string gender = comboGender.Text;
            DateTime birthdate = birthDate.Value;
            string phone = txtPhone.Text;
            string parentPhone = txtParentPhone.Text;
            string status = comboStatus.Text;

            if (string.IsNullOrWhiteSpace(studentId) ||
                string.IsNullOrWhiteSpace(nameEn) ||
                string.IsNullOrWhiteSpace(nameKh))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            DataTable? dt = dataOne.DataSource as DataTable;
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("Student ID");
                dt.Columns.Add("Name EN");
                dt.Columns.Add("Name KH");
                dt.Columns.Add("Gender");
                dt.Columns.Add("Birth Date");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Parent Phone");
                dt.Columns.Add("Status");
                dataOne.DataSource = dt;
            }

            dt.Rows.Add(studentId, nameEn, nameKh, gender, birthdate.ToShortDateString(), phone, parentPhone, status);

            // Clear form fields
            txtStudentID.Clear();
            comboStudentEN.Clear();
            comboStudentKH.Clear();
            comboGender.SelectedIndex = -1;
            birthDate.Value = DateTime.Now;
            txtPhone.Clear();
            txtParentPhone.Clear();
            comboStatus.SelectedIndex = -1;
        }
    }
}
