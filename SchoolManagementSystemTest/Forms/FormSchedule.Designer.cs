namespace SchoolManagementSystemTest.Forms
{
    partial class FormSchedule
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            Search = new TextBox();
            dataOne = new DataGridView();
            btnInsert = new Button();
            btnUpdate = new Button();
            TimeEnd = new DateTimePicker();
            TimeStart = new DateTimePicker();
            label13 = new Label();
            label12 = new Label();
            panel1 = new Panel();
            label10 = new Label();
            panel2 = new Panel();
            title = new TextBox();
            label9 = new Label();
            comboSubject = new ComboBox();
            comboClass = new ComboBox();
            comboDepartment = new ComboBox();
            comboday = new ComboBox();
            comboInstructor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataOne).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(30, 83);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 0;
            label1.Text = "Instructors";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(30, 331);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 1;
            label2.Text = "SubjectID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(30, 252);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 2;
            label3.Text = "ClassName";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(30, 163);
            label4.Name = "label4";
            label4.Size = new Size(102, 21);
            label4.TabIndex = 3;
            label4.Text = "Department";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(30, 409);
            label5.Name = "label5";
            label5.Size = new Size(40, 21);
            label5.TabIndex = 4;
            label5.Text = "Day";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(30, 487);
            label6.Name = "label6";
            label6.Size = new Size(61, 21);
            label6.TabIndex = 11;
            label6.Text = "Search";
            // 
            // Search
            // 
            Search.Location = new Point(30, 510);
            Search.Margin = new Padding(3, 2, 3, 2);
            Search.Multiline = true;
            Search.Name = "Search";
            Search.Size = new Size(205, 34);
            Search.TabIndex = 12;
            // 
            // dataOne
            // 
            dataOne.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataOne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOne.Location = new Point(263, 158);
            dataOne.Margin = new Padding(3, 2, 3, 2);
            dataOne.Name = "dataOne";
            dataOne.RowHeadersWidth = 51;
            dataOne.Size = new Size(924, 490);
            dataOne.TabIndex = 13;
            // 
            // btnInsert
            // 
            btnInsert.Font = new Font("Segoe UI", 12F);
            btnInsert.Location = new Point(140, 582);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(102, 39);
            btnInsert.TabIndex = 14;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 12F);
            btnUpdate.Location = new Point(30, 582);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(102, 39);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Save";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // TimeEnd
            // 
            TimeEnd.Font = new Font("Segoe UI", 12F);
            TimeEnd.Format = DateTimePickerFormat.Time;
            TimeEnd.Location = new Point(1047, 112);
            TimeEnd.Margin = new Padding(3, 2, 3, 2);
            TimeEnd.Name = "TimeEnd";
            TimeEnd.Size = new Size(140, 29);
            TimeEnd.TabIndex = 25;
            // 
            // TimeStart
            // 
            TimeStart.Font = new Font("Segoe UI", 12F);
            TimeStart.Format = DateTimePickerFormat.Time;
            TimeStart.Location = new Point(882, 112);
            TimeStart.Margin = new Padding(3, 2, 3, 2);
            TimeStart.Name = "TimeStart";
            TimeStart.Size = new Size(142, 29);
            TimeStart.TabIndex = 24;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label13.Location = new Point(1047, 83);
            label13.Name = "label13";
            label13.Size = new Size(81, 21);
            label13.TabIndex = 23;
            label13.Text = "Time End";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.Location = new Point(882, 84);
            label12.Name = "label12";
            label12.Size = new Size(88, 21);
            label12.TabIndex = 22;
            label12.Text = "Time Start";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOrange;
            panel1.Controls.Add(label10);
            panel1.Location = new Point(1, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1200, 63);
            panel1.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label10.Location = new Point(546, 16);
            label10.Name = "label10";
            label10.Size = new Size(133, 32);
            label10.TabIndex = 28;
            label10.Text = "SCHEDULE";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkOrange;
            panel2.Location = new Point(0, 658);
            panel2.Name = "panel2";
            panel2.Size = new Size(1200, 63);
            panel2.TabIndex = 27;
            // 
            // title
            // 
            title.Font = new Font("Segoe UI", 11F);
            title.Location = new Point(496, 107);
            title.Margin = new Padding(3, 2, 3, 2);
            title.Multiline = true;
            title.Name = "title";
            title.Size = new Size(366, 34);
            title.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.Location = new Point(496, 83);
            label9.Name = "label9";
            label9.Size = new Size(44, 21);
            label9.TabIndex = 29;
            label9.Text = "Title";
            // 
            // comboSubject
            // 
            comboSubject.Font = new Font("Segoe UI", 12F);
            comboSubject.FormattingEnabled = true;
            comboSubject.Location = new Point(30, 355);
            comboSubject.Name = "comboSubject";
            comboSubject.Size = new Size(205, 29);
            comboSubject.TabIndex = 31;
            // 
            // comboClass
            // 
            comboClass.Font = new Font("Segoe UI", 12F);
            comboClass.FormattingEnabled = true;
            comboClass.Location = new Point(30, 276);
            comboClass.Name = "comboClass";
            comboClass.Size = new Size(205, 29);
            comboClass.TabIndex = 32;
            // 
            // comboDepartment
            // 
            comboDepartment.Font = new Font("Segoe UI", 12F);
            comboDepartment.FormattingEnabled = true;
            comboDepartment.Location = new Point(30, 188);
            comboDepartment.Name = "comboDepartment";
            comboDepartment.Size = new Size(205, 29);
            comboDepartment.TabIndex = 33;
            // 
            // comboday
            // 
            comboday.Font = new Font("Segoe UI", 12F);
            comboday.FormattingEnabled = true;
            comboday.Location = new Point(30, 433);
            comboday.Name = "comboday";
            comboday.Size = new Size(205, 29);
            comboday.TabIndex = 34;
            // 
            // comboInstructor
            // 
            comboInstructor.Font = new Font("Segoe UI", 12F);
            comboInstructor.FormattingEnabled = true;
            comboInstructor.Location = new Point(30, 112);
            comboInstructor.Name = "comboInstructor";
            comboInstructor.Size = new Size(205, 29);
            comboInstructor.TabIndex = 35;
            // 
            // FormSchedule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 715);
            Controls.Add(comboInstructor);
            Controls.Add(comboday);
            Controls.Add(comboDepartment);
            Controls.Add(comboSubject);
            Controls.Add(label2);
            Controls.Add(comboClass);
            Controls.Add(title);
            Controls.Add(label9);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(TimeEnd);
            Controls.Add(TimeStart);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(dataOne);
            Controls.Add(Search);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSchedule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSchedule";
            Load += FormSchedule_Load;
            ((System.ComponentModel.ISupportInitialize)dataOne).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox Search;
        private DataGridView dataOne;
        private Button btnInsert;
        private Button btnUpdate;
        private DateTimePicker TimeEnd;
        private DateTimePicker TimeStart;
        private Label label13;
        private Label label12;
        private Panel panel1;
        private Panel panel2;
        private Label label8;
        private Label label10;
        private TextBox title;
        private Label label9;
        private ComboBox comboSubject;
        private ComboBox comboClass;
        private ComboBox comboDepartment;
        private ComboBox comboday;
        private ComboBox comboInstructor;
    }
}