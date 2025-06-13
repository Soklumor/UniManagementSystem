namespace SchoolManagementSystemTest.Forms
{
    partial class InsertScore
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
            dataOne = new DataGridView();
            comboClass = new ComboBox();
            comboDepartment = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label5 = new Label();
            btnSaveScores = new Button();
            btnUpdate = new Button();
            dateTime = new DateTimePicker();
            label1 = new Label();
            studentName = new TextBox();
            label2 = new Label();
            studentID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataOne).BeginInit();
            SuspendLayout();
            // 
            // dataOne
            // 
            dataOne.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataOne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOne.Location = new Point(260, 132);
            dataOne.Name = "dataOne";
            dataOne.Size = new Size(919, 531);
            dataOne.TabIndex = 3;
            // 
            // comboClass
            // 
            comboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            comboClass.Font = new Font("Segoe UI", 12F);
            comboClass.FormattingEnabled = true;
            comboClass.Location = new Point(28, 435);
            comboClass.Name = "comboClass";
            comboClass.Size = new Size(209, 29);
            comboClass.TabIndex = 6;
            comboClass.TabStop = false;
            // 
            // comboDepartment
            // 
            comboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDepartment.Font = new Font("Segoe UI", 12F);
            comboDepartment.FormattingEnabled = true;
            comboDepartment.Location = new Point(27, 344);
            comboDepartment.Name = "comboDepartment";
            comboDepartment.Size = new Size(208, 29);
            comboDepartment.TabIndex = 7;
            comboDepartment.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(28, 411);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 10;
            label3.Text = "Class";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(27, 320);
            label4.Name = "label4";
            label4.Size = new Size(102, 21);
            label4.TabIndex = 11;
            label4.Text = "Department";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOrange;
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1188, 63);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkOrange;
            panel2.Location = new Point(2, 669);
            panel2.Name = "panel2";
            panel2.Size = new Size(1188, 63);
            panel2.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(26, 504);
            label5.Name = "label5";
            label5.Size = new Size(88, 21);
            label5.TabIndex = 29;
            label5.Text = "ExamDate";
            // 
            // btnSaveScores
            // 
            btnSaveScores.Location = new Point(150, 605);
            btnSaveScores.Name = "btnSaveScores";
            btnSaveScores.Size = new Size(86, 44);
            btnSaveScores.TabIndex = 30;
            btnSaveScores.Text = "Save";
            btnSaveScores.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(28, 605);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 44);
            btnUpdate.TabIndex = 37;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // dateTime
            // 
            dateTime.Font = new Font("Segoe UI", 11F);
            dateTime.Location = new Point(27, 531);
            dateTime.Name = "dateTime";
            dateTime.Size = new Size(209, 27);
            dateTime.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(29, 221);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 42;
            label1.Text = "Student_Name";
            // 
            // studentName
            // 
            studentName.Location = new Point(28, 245);
            studentName.Multiline = true;
            studentName.Name = "studentName";
            studentName.ReadOnly = true;
            studentName.Size = new Size(209, 34);
            studentName.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(28, 108);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 40;
            label2.Text = "Student_ID";
            // 
            // studentID
            // 
            studentID.Location = new Point(27, 132);
            studentID.Multiline = true;
            studentID.Name = "studentID";
            studentID.ReadOnly = true;
            studentID.Size = new Size(209, 34);
            studentID.TabIndex = 39;
            // 
            // InsertScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 722);
            Controls.Add(label1);
            Controls.Add(studentName);
            Controls.Add(label2);
            Controls.Add(studentID);
            Controls.Add(dateTime);
            Controls.Add(btnUpdate);
            Controls.Add(btnSaveScores);
            Controls.Add(label5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboDepartment);
            Controls.Add(comboClass);
            Controls.Add(dataOne);
            Name = "InsertScore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Score";
            ((System.ComponentModel.ISupportInitialize)dataOne).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataOne;
        private ComboBox comboClass;
        private ComboBox comboDepartment;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Panel panel2;
        private Label label5;
        private Button btnSaveScores;
        private Button btnUpdate;
        private DateTimePicker dateTime;
        private Label label1;
        private TextBox studentName;
        private Label label2;
        private TextBox studentID;
    }
}