namespace SchoolManagementSystemTest
{
    partial class FormResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnReload = new Button();
            logout = new PictureBox();
            label8 = new Label();
            panel3 = new Panel();
            dataOne = new DataGridView();
            studentID = new TextBox();
            label3 = new Label();
            label4 = new Label();
            btnSave = new Button();
            label10 = new Label();
            label1 = new Label();
            studentName = new TextBox();
            label2 = new Label();
            label5 = new Label();
            btnInsert = new Button();
            className = new TextBox();
            departmentName = new TextBox();
            label7 = new Label();
            comboDepartment = new ComboBox();
            label11 = new Label();
            comboClass = new ComboBox();
            begindate = new DateTimePicker();
            enddate = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataOne).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOrange;
            panel1.Controls.Add(btnReload);
            panel1.Controls.Add(logout);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(-1, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1200, 63);
            panel1.TabIndex = 0;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(26, 12);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(86, 44);
            btnReload.TabIndex = 38;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            // 
            // logout
            // 
            logout.BackgroundImage = Properties.Resources.power;
            logout.BackgroundImageLayout = ImageLayout.Zoom;
            logout.Image = Properties.Resources.power;
            logout.Location = new Point(1105, 19);
            logout.Name = "logout";
            logout.Size = new Size(83, 30);
            logout.TabIndex = 21;
            logout.TabStop = false;
            logout.Click += Logout;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label8.Location = new Point(516, 19);
            label8.Name = "label8";
            label8.Size = new Size(165, 32);
            label8.TabIndex = 20;
            label8.Text = "VIEW RESULT";
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkOrange;
            panel3.Location = new Point(-1, 665);
            panel3.Name = "panel3";
            panel3.Size = new Size(1200, 63);
            panel3.TabIndex = 2;
            // 
            // dataOne
            // 
            dataOne.AllowUserToAddRows = false;
            dataOne.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataOne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOne.Location = new Point(232, 126);
            dataOne.Name = "dataOne";
            dataOne.Size = new Size(939, 528);
            dataOne.TabIndex = 2;
            // 
            // studentID
            // 
            studentID.Location = new Point(13, 126);
            studentID.Multiline = true;
            studentID.Name = "studentID";
            studentID.ReadOnly = true;
            studentID.Size = new Size(209, 34);
            studentID.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(13, 101);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 8;
            label3.Text = "Student_ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(13, 468);
            label4.Name = "label4";
            label4.Size = new Size(155, 21);
            label4.TabIndex = 10;
            label4.Text = "Department_Name";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(13, 577);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 44);
            btnSave.TabIndex = 19;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.Location = new Point(13, 349);
            label10.Name = "label10";
            label10.Size = new Size(101, 21);
            label10.TabIndex = 24;
            label10.Text = "Class_Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(13, 225);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 26;
            label1.Text = "Student_Name";
            // 
            // studentName
            // 
            studentName.Location = new Point(13, 250);
            studentName.Multiline = true;
            studentName.Name = "studentName";
            studentName.ReadOnly = true;
            studentName.Size = new Size(209, 34);
            studentName.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(764, 69);
            label2.Name = "label2";
            label2.Size = new Size(97, 21);
            label2.TabIndex = 28;
            label2.Text = "Begin_Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(995, 69);
            label5.Name = "label5";
            label5.Size = new Size(82, 21);
            label5.TabIndex = 30;
            label5.Text = "End_Date";
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(121, 577);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(101, 44);
            btnInsert.TabIndex = 31;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // className
            // 
            className.Location = new Point(13, 372);
            className.Multiline = true;
            className.Name = "className";
            className.ReadOnly = true;
            className.Size = new Size(209, 34);
            className.TabIndex = 32;
            // 
            // departmentName
            // 
            departmentName.Location = new Point(13, 492);
            departmentName.Multiline = true;
            departmentName.Name = "departmentName";
            departmentName.ReadOnly = true;
            departmentName.Size = new Size(209, 34);
            departmentName.TabIndex = 33;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(232, 67);
            label7.Name = "label7";
            label7.Size = new Size(109, 21);
            label7.TabIndex = 42;
            label7.Text = "Departments";
            // 
            // comboDepartment
            // 
            comboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDepartment.Font = new Font("Segoe UI", 12F);
            comboDepartment.FormattingEnabled = true;
            comboDepartment.Location = new Point(232, 91);
            comboDepartment.Name = "comboDepartment";
            comboDepartment.Size = new Size(180, 29);
            comboDepartment.TabIndex = 39;
            comboDepartment.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.Location = new Point(517, 67);
            label11.Name = "label11";
            label11.Size = new Size(64, 21);
            label11.TabIndex = 44;
            label11.Text = "Classes";
            // 
            // comboClass
            // 
            comboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            comboClass.Font = new Font("Segoe UI", 12F);
            comboClass.FormattingEnabled = true;
            comboClass.Location = new Point(517, 91);
            comboClass.Name = "comboClass";
            comboClass.Size = new Size(180, 29);
            comboClass.TabIndex = 43;
            comboClass.TabStop = false;
            // 
            // begindate
            // 
            begindate.Font = new Font("Segoe UI", 11F);
            begindate.Location = new Point(764, 93);
            begindate.Name = "begindate";
            begindate.Size = new Size(177, 27);
            begindate.TabIndex = 46;
            // 
            // enddate
            // 
            enddate.Font = new Font("Segoe UI", 11F);
            enddate.Location = new Point(993, 94);
            enddate.Name = "enddate";
            enddate.Size = new Size(177, 27);
            enddate.TabIndex = 47;
            // 
            // FormResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 715);
            Controls.Add(btnInsert);
            Controls.Add(enddate);
            Controls.Add(begindate);
            Controls.Add(label11);
            Controls.Add(comboClass);
            Controls.Add(label7);
            Controls.Add(comboDepartment);
            Controls.Add(departmentName);
            Controls.Add(className);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(panel3);
            Controls.Add(label1);
            Controls.Add(studentName);
            Controls.Add(label10);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(studentID);
            Controls.Add(dataOne);
            Controls.Add(panel1);
            KeyPreview = true;
            Name = "FormResult";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ResultForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logout).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataOne).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dataOne;
        private TextBox studentID;
        private Label label3;
        private Label label4;
        private Button btnSave;
        private Label label8;
        private Label label10;
        private Panel panel3;
        private Label label1;
        private TextBox studentName;
        private Label label2;
        private Label label5;
        private Button btnInsert;
        private TextBox className;
        private TextBox departmentName;
        private Label label7;
        private ComboBox comboDepartment;
        private Label label11;
        private ComboBox comboClass;
        private DateTimePicker begindate;
        private DateTimePicker enddate;
        private PictureBox logout;
        private Button btnReload;
    }
}