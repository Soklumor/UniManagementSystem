namespace SchoolManagementSystemTest.Forms
{
    partial class StudentForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Picture = new PictureBox();
            checkBoxStopStop = new CheckBox();
            checkBoxStudy = new CheckBox();
            label20 = new Label();
            btnLogout = new Button();
            btnNew = new Button();
            btnUpdate = new Button();
            btnInsert = new Button();
            dgvStudent = new DataGridView();
            label15 = new Label();
            SearchBar = new TextBox();
            txtStuDepartent = new TextBox();
            txtStuPhone = new TextBox();
            txtStuPatentPhone = new TextBox();
            txtStuEmail = new TextBox();
            txtStuAddr = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label6 = new Label();
            txtStuBirthDate = new TextBox();
            txtStuGender = new TextBox();
            txtStuNameEN = new TextBox();
            txtStuNameKH = new TextBox();
            txtStudentID = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            ID = new Label();
            StaffID = new Label();
            textStuEnterYear = new TextBox();
            label7 = new Label();
            label16 = new Label();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)Picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).BeginInit();
            SuspendLayout();
            // 
            // Picture
            // 
            Picture.Location = new Point(906, 59);
            Picture.Name = "Picture";
            Picture.Size = new Size(106, 120);
            Picture.TabIndex = 124;
            Picture.TabStop = false;
            // 
            // checkBoxStopStop
            // 
            checkBoxStopStop.AutoSize = true;
            checkBoxStopStop.Location = new Point(334, 452);
            checkBoxStopStop.Name = "checkBoxStopStop";
            checkBoxStopStop.Size = new Size(103, 24);
            checkBoxStopStop.TabIndex = 123;
            checkBoxStopStop.Text = "Stop Study";
            checkBoxStopStop.UseVisualStyleBackColor = true;
            // 
            // checkBoxStudy
            // 
            checkBoxStudy.AutoSize = true;
            checkBoxStudy.Location = new Point(248, 452);
            checkBoxStudy.Name = "checkBoxStudy";
            checkBoxStudy.Size = new Size(68, 24);
            checkBoxStudy.TabIndex = 122;
            checkBoxStudy.Text = "Study";
            checkBoxStudy.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(136, 452);
            label20.Name = "label20";
            label20.Size = new Size(52, 20);
            label20.TabIndex = 121;
            label20.Text = "Status:";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Firebrick;
            btnLogout.ForeColor = SystemColors.ButtonHighlight;
            btnLogout.Location = new Point(817, 516);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(129, 47);
            btnLogout.TabIndex = 120;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(255, 128, 0);
            btnNew.ForeColor = SystemColors.ButtonFace;
            btnNew.Location = new Point(610, 516);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(129, 47);
            btnNew.TabIndex = 119;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Navy;
            btnUpdate.ForeColor = SystemColors.ButtonHighlight;
            btnUpdate.Location = new Point(400, 516);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(129, 47);
            btnUpdate.TabIndex = 118;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.Green;
            btnInsert.ForeColor = SystemColors.ButtonHighlight;
            btnInsert.Location = new Point(200, 516);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(124, 47);
            btnInsert.TabIndex = 117;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // dgvStudent
            // 
            dgvStudent.BackgroundColor = SystemColors.ButtonFace;
            dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudent.Location = new Point(545, 194);
            dgvStudent.Name = "dgvStudent";
            dgvStudent.RowHeadersWidth = 51;
            dgvStudent.Size = new Size(467, 278);
            dgvStudent.TabIndex = 116;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(548, 138);
            label15.Name = "label15";
            label15.Size = new Size(56, 20);
            label15.TabIndex = 115;
            label15.Text = "Search:";
            // 
            // SearchBar
            // 
            SearchBar.Location = new Point(610, 135);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(290, 27);
            SearchBar.TabIndex = 114;
            // 
            // txtStuDepartent
            // 
            txtStuDepartent.Location = new Point(248, 386);
            txtStuDepartent.Name = "txtStuDepartent";
            txtStuDepartent.Size = new Size(261, 27);
            txtStuDepartent.TabIndex = 113;
            // 
            // txtStuPhone
            // 
            txtStuPhone.Location = new Point(248, 353);
            txtStuPhone.Name = "txtStuPhone";
            txtStuPhone.Size = new Size(261, 27);
            txtStuPhone.TabIndex = 112;
            // 
            // txtStuPatentPhone
            // 
            txtStuPatentPhone.Location = new Point(248, 320);
            txtStuPatentPhone.Name = "txtStuPatentPhone";
            txtStuPatentPhone.Size = new Size(261, 27);
            txtStuPatentPhone.TabIndex = 111;
            // 
            // txtStuEmail
            // 
            txtStuEmail.Location = new Point(248, 287);
            txtStuEmail.Name = "txtStuEmail";
            txtStuEmail.Size = new Size(261, 27);
            txtStuEmail.TabIndex = 110;
            // 
            // txtStuAddr
            // 
            txtStuAddr.Location = new Point(248, 254);
            txtStuAddr.Name = "txtStuAddr";
            txtStuAddr.Size = new Size(261, 27);
            txtStuAddr.TabIndex = 109;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(134, 294);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 108;
            label8.Text = "Email:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(643, 126);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 107;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(136, 389);
            label10.Name = "label10";
            label10.Size = new Size(92, 20);
            label10.TabIndex = 106;
            label10.Text = "Department:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(136, 360);
            label11.Name = "label11";
            label11.Size = new Size(53, 20);
            label11.TabIndex = 105;
            label11.Text = "Phone:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(133, 327);
            label12.Name = "label12";
            label12.Size = new Size(98, 20);
            label12.TabIndex = 104;
            label12.Text = "Parent Phone:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(259, 393);
            label13.Name = "label13";
            label13.Size = new Size(0, 20);
            label13.TabIndex = 103;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(133, 261);
            label14.Name = "label14";
            label14.Size = new Size(65, 20);
            label14.TabIndex = 102;
            label14.Text = "Address:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(134, 232);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 101;
            label6.Text = "Birth Address:";
            // 
            // txtStuBirthDate
            // 
            txtStuBirthDate.Location = new Point(248, 187);
            txtStuBirthDate.Name = "txtStuBirthDate";
            txtStuBirthDate.Size = new Size(261, 27);
            txtStuBirthDate.TabIndex = 100;
            // 
            // txtStuGender
            // 
            txtStuGender.Location = new Point(248, 152);
            txtStuGender.Name = "txtStuGender";
            txtStuGender.Size = new Size(261, 27);
            txtStuGender.TabIndex = 98;
            // 
            // txtStuNameEN
            // 
            txtStuNameEN.Location = new Point(248, 119);
            txtStuNameEN.Name = "txtStuNameEN";
            txtStuNameEN.Size = new Size(261, 27);
            txtStuNameEN.TabIndex = 97;
            // 
            // txtStuNameKH
            // 
            txtStuNameKH.Location = new Point(248, 86);
            txtStuNameKH.Name = "txtStuNameKH";
            txtStuNameKH.Size = new Size(261, 27);
            txtStuNameKH.TabIndex = 96;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(248, 52);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(261, 27);
            txtStudentID.TabIndex = 95;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(133, 92);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 94;
            label3.Text = "Name KH:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(133, 188);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 93;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(134, 194);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 92;
            label5.Text = "Birth Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 161);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 91;
            label2.Text = "Gender:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 126);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 90;
            label1.Text = "Name EN:";
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Location = new Point(259, 126);
            ID.Name = "ID";
            ID.Size = new Size(0, 20);
            ID.TabIndex = 89;
            // 
            // StaffID
            // 
            StaffID.AutoSize = true;
            StaffID.Location = new Point(134, 59);
            StaffID.Name = "StaffID";
            StaffID.Size = new Size(82, 20);
            StaffID.TabIndex = 88;
            StaffID.Text = "Student ID:";
            // 
            // textStuEnterYear
            // 
            textStuEnterYear.Location = new Point(248, 419);
            textStuEnterYear.Name = "textStuEnterYear";
            textStuEnterYear.Size = new Size(261, 27);
            textStuEnterYear.TabIndex = 127;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(136, 422);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 126;
            label7.Text = "Enter Year:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(259, 426);
            label16.Name = "label16";
            label16.Size = new Size(0, 20);
            label16.TabIndex = 125;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(248, 220);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(261, 27);
            dateTimePicker1.TabIndex = 128;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1140, 676);
            Controls.Add(dateTimePicker1);
            Controls.Add(textStuEnterYear);
            Controls.Add(label7);
            Controls.Add(label16);
            Controls.Add(Picture);
            Controls.Add(checkBoxStopStop);
            Controls.Add(checkBoxStudy);
            Controls.Add(label20);
            Controls.Add(btnLogout);
            Controls.Add(btnNew);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(dgvStudent);
            Controls.Add(label15);
            Controls.Add(SearchBar);
            Controls.Add(txtStuDepartent);
            Controls.Add(txtStuPhone);
            Controls.Add(txtStuPatentPhone);
            Controls.Add(txtStuEmail);
            Controls.Add(txtStuAddr);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(label6);
            Controls.Add(txtStuBirthDate);
            Controls.Add(txtStuGender);
            Controls.Add(txtStuNameEN);
            Controls.Add(txtStuNameKH);
            Controls.Add(txtStudentID);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ID);
            Controls.Add(StaffID);
            Name = "StudentForm";
            Text = "StudentForm";
            ((System.ComponentModel.ISupportInitialize)Picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Picture;
        private CheckBox checkBoxStopStop;
        private CheckBox checkBoxStudy;
        private Label label20;
        private Button btnLogout;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnInsert;
        private DataGridView dgvStudent;
        private Label label15;
        private TextBox SearchBar;
        private TextBox txtStuDepartent;
        private TextBox txtStuPhone;
        private TextBox txtStuPatentPhone;
        private TextBox txtStuEmail;
        private TextBox txtStuAddr;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label6;
        private TextBox txtStuBirthDate;
        private TextBox txtStuGender;
        private TextBox txtStuNameEN;
        private TextBox txtStuNameKH;
        private TextBox txtStudentID;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label2;
        private Label label1;
        private Label ID;
        private Label StaffID;
        private TextBox textStuEnterYear;
        private Label label7;
        private Label label16;
        private DateTimePicker dateTimePicker1;
    }
}