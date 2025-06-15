using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystemTest.Services;

namespace SchoolManagementSystemTest
{
    public partial class LoginForm : Form
    {
        private Label txtusername;
        private Label txtpass;
        private TextBox usernameText;
        private TextBox passwordText;
        private Button btnLogin;

        private readonly UserService _userService;
        private readonly IServiceProvider _serviceProvider;  // Added this field

        // Added IServiceProvider parameter here
        public LoginForm(UserService userService, IServiceProvider serviceProvider)
        {
            _userService = userService;
            _serviceProvider = serviceProvider;  // Assigned here
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            txtusername = new Label();
            txtpass = new Label();
            usernameText = new TextBox();
            passwordText = new TextBox();
            btnLogin = new Button();

            SuspendLayout();

            // Username label
            txtusername.AutoSize = true;
            txtusername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtusername.Location = new Point(54, 61);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(83, 21);
            txtusername.Text = "Username";

            // Password label
            txtpass.AutoSize = true;
            txtpass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtpass.Location = new Point(54, 135);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(79, 21);
            txtpass.Text = "Password";

            // Username textbox
            usernameText.Location = new Point(194, 63);
            usernameText.Name = "usernameText";
            usernameText.Size = new Size(365, 23);

            // Password textbox
            passwordText.Location = new Point(194, 133);
            passwordText.Name = "passwordText";
            passwordText.Size = new Size(365, 23);
            passwordText.UseSystemPasswordChar = true;

            // Login button
            btnLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.Location = new Point(239, 187);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(114, 35);
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += new EventHandler(btnLogin_Click);

            // Form settings
            ClientSize = new Size(644, 280);
            Controls.Add(btnLogin);
            Controls.Add(passwordText);
            Controls.Add(usernameText);
            Controls.Add(txtpass);
            Controls.Add(txtusername);
            Name = "LoginForm";
            Text = "Login";

            ResumeLayout(false);
            PerformLayout();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;

            var user = _userService.Authenticate(username, password);
            if (user != null)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
