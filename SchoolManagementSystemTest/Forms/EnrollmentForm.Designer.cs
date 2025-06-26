
namespace SchoolManagementSystemTest.Forms
{
    partial class EnrollmentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label9 = new Label();
            label11 = new Label();
            label14 = new Label();
            dataOne = new DataGridView();
            btnInsert = new Button();
            panel1 = new Panel();
            labelTitle = new Label();
            panel2 = new Panel();
            birthDate = new DateTimePicker();
            txtStudentID = new TextBox();
            comboStudentEN = new TextBox();
            comboStudentKH = new TextBox();
            comboGender = new ComboBox();
            txtPhone = new TextBox();
            txtParentPhone = new TextBox();
            comboStatus = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataOne).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(34, 111);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "Student ID";
            // 
            // label2
            // 
            label2.Location = new Point(34, 396);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 1;
            label2.Text = "Gender";
            // 
            // label4
            // 
            label4.Location = new Point(34, 217);
            label4.Name = "label4";
            label4.Size = new Size(159, 23);
            label4.TabIndex = 2;
            label4.Text = "Student Name (EN)";
            // 
            // label5
            // 
            label5.Location = new Point(34, 504);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 3;
            label5.Text = "Birth Date";
            // 
            // label9
            // 
            label9.Location = new Point(34, 771);
            label9.Name = "label9";
            label9.Size = new Size(100, 23);
            label9.TabIndex = 4;
            label9.Text = "Status";
            // 
            // label11
            // 
            label11.Location = new Point(34, 680);
            label11.Name = "label11";
            label11.Size = new Size(100, 23);
            label11.TabIndex = 5;
            label11.Text = "Parents' Phone";
            // 
            // label14
            // 
            label14.Location = new Point(34, 586);
            label14.Name = "label14";
            label14.Size = new Size(100, 23);
            label14.TabIndex = 6;
            label14.Text = "Phone";
            // 
            // dataOne
            // 
            dataOne.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataOne.ColumnHeadersHeight = 29;
            dataOne.Location = new Point(291, 211);
            dataOne.Name = "dataOne";
            dataOne.RowHeadersWidth = 51;
            dataOne.Size = new Size(1066, 653);
            dataOne.TabIndex = 15;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(34, 850);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(117, 40);
            btnInsert.TabIndex = 16;
            btnInsert.Text = "Insert";
            btnInsert.Click += btnInsert_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOrange;
            panel1.Controls.Add(labelTitle);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1370, 84);
            panel1.TabIndex = 17;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(500, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(254, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Enrollment Form";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkOrange;
            panel2.Location = new Point(0, 910);
            panel2.Name = "panel2";
            panel2.Size = new Size(1370, 84);
            panel2.TabIndex = 18;
            // 
            // birthDate
            // 
            birthDate.Location = new Point(34, 539);
            birthDate.Name = "birthDate";
            birthDate.Size = new Size(234, 27);
            birthDate.TabIndex = 11;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(34, 132);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(234, 27);
            txtStudentID.TabIndex = 7;
            // 
            // comboStudentEN
            // 
            comboStudentEN.Location = new Point(34, 241);
            comboStudentEN.Name = "comboStudentEN";
            comboStudentEN.Size = new Size(234, 27);
            comboStudentEN.TabIndex = 8;
            // 
            // comboStudentKH
            // 
            comboStudentKH.Location = new Point(34, 339);
            comboStudentKH.Name = "comboStudentKH";
            comboStudentKH.Size = new Size(234, 27);
            comboStudentKH.TabIndex = 9;
            // 
            // comboGender
            // 
            comboGender.Location = new Point(34, 431);
            comboGender.Name = "comboGender";
            comboGender.Size = new Size(234, 28);
            comboGender.TabIndex = 10;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(34, 621);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(234, 27);
            txtPhone.TabIndex = 12;
            // 
            // txtParentPhone
            // 
            txtParentPhone.Location = new Point(34, 715);
            txtParentPhone.Name = "txtParentPhone";
            txtParentPhone.Size = new Size(234, 27);
            txtParentPhone.TabIndex = 13;
            // 
            // comboStatus
            // 
            comboStatus.Location = new Point(34, 800);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(234, 28);
            comboStatus.TabIndex = 14;
            // 
            // label3
            // 
            label3.Location = new Point(34, 301);
            label3.Name = "label3";
            label3.Size = new Size(159, 23);
            label3.TabIndex = 19;
            label3.Text = "Student Name (KH)";
            label3.Click += label3_Click;
            // 
            // EnrollmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 1000);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label9);
            Controls.Add(label11);
            Controls.Add(label14);
            Controls.Add(txtStudentID);
            Controls.Add(comboStudentEN);
            Controls.Add(comboStudentKH);
            Controls.Add(comboGender);
            Controls.Add(birthDate);
            Controls.Add(txtPhone);
            Controls.Add(txtParentPhone);
            Controls.Add(comboStatus);
            Controls.Add(dataOne);
            Controls.Add(btnInsert);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "EnrollmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EnrollmentForm";
            Load += EnrollmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataOne).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1, label2, label4, label5, label9, label11, label14, labelTitle;
        private TextBox txtStudentID, comboStudentEN, comboStudentKH, txtPhone, txtParentPhone;
        private ComboBox comboGender, comboStatus;
        private DateTimePicker birthDate;
        private DataGridView dataOne;
        private Button btnInsert;
        private Panel panel1, panel2;
        private Label label3;
    }
}
