using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using StudentManagementSystem.Data;
using StudentManagementSystem.Helpers;

namespace StudentManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseRepository database_repository;

        public LoginForm()
        {
            InitializeComponent();
            database_repository = new DatabaseRepository();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Load logo
            string logo_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "institution_logo.png");
            if (File.Exists(logo_path))
            {
                picture_box_logo.Image = Image.FromFile(logo_path);
                picture_box_logo.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string user_name = text_box_username.Text;
            string pass_word = text_box_password.Text;

            if (string.IsNullOrWhiteSpace(user_name) || string.IsNullOrWhiteSpace(pass_word))
            {
                FormManager.ShowWarningMessage("Please enter both username and password", "Input Required");
                return;
            }

            bool authentication_result = database_repository.AuthenticateUser(user_name, pass_word);

            if (authentication_result)
            {
                FormManager.ShowInformationMessage("Authentication completed successfully!", "Login Successful");
                RegistrationForm registration_form = new RegistrationForm();
                registration_form.Show();
                this.Hide();
            }
            else
            {
                FormManager.ShowErrorMessage("Authentication failed. Invalid credentials.", "Login Failed");
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            text_box_username.ResetText();
            text_box_password.ResetText();
            text_box_username.Focus();
        }

        private void InitializeComponent()
        {
            this.group_box_login = new System.Windows.Forms.GroupBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.text_box_password = new System.Windows.Forms.TextBox();
            this.text_box_username = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.picture_box_logo = new System.Windows.Forms.PictureBox();
            this.group_box_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // group_box_login
            // 
            this.group_box_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.group_box_login.Controls.Add(this.button_clear);
            this.group_box_login.Controls.Add(this.button_login);
            this.group_box_login.Controls.Add(this.text_box_password);
            this.group_box_login.Controls.Add(this.text_box_username);
            this.group_box_login.Controls.Add(this.label_password);
            this.group_box_login.Controls.Add(this.label_username);
            this.group_box_login.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.group_box_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.group_box_login.Location = new System.Drawing.Point(40, 180);
            this.group_box_login.Name = "group_box_login";
            this.group_box_login.Size = new System.Drawing.Size(400, 220);
            this.group_box_login.TabIndex = 0;
            this.group_box_login.TabStop = false;
            this.group_box_login.Text = "Login Credentials";
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(231)))), ((int)(((byte)(183)))));
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.ForeColor = System.Drawing.Color.White;
            this.button_clear.Location = new System.Drawing.Point(225, 160);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(140, 40);
            this.button_clear.TabIndex = 5;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(181)))), ((int)(((byte)(253)))));
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Location = new System.Drawing.Point(35, 160);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(140, 40);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // text_box_password
            // 
            this.text_box_password.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_password.Location = new System.Drawing.Point(150, 105);
            this.text_box_password.Name = "text_box_password";
            this.text_box_password.PasswordChar = '*';
            this.text_box_password.Size = new System.Drawing.Size(215, 24);
            this.text_box_password.TabIndex = 3;
            // 
            // text_box_username
            // 
            this.text_box_username.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_username.Location = new System.Drawing.Point(150, 55);
            this.text_box_username.Name = "text_box_username";
            this.text_box_username.Size = new System.Drawing.Size(215, 24);
            this.text_box_username.TabIndex = 2;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.label_password.Location = new System.Drawing.Point(35, 108);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(73, 17);
            this.label_password.TabIndex = 1;
            this.label_password.Text = "Password:";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.label_username.Location = new System.Drawing.Point(35, 58);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(76, 17);
            this.label_username.TabIndex = 0;
            this.label_username.Text = "Username:";
            // 
            // picture_box_logo
            // 
            this.picture_box_logo.Location = new System.Drawing.Point(140, 20);
            this.picture_box_logo.Name = "picture_box_logo";
            this.picture_box_logo.Size = new System.Drawing.Size(200, 140);
            this.picture_box_logo.TabIndex = 1;
            this.picture_box_logo.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(480, 440);
            this.Controls.Add(this.picture_box_logo);
            this.Controls.Add(this.group_box_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Management System - Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.group_box_login.ResumeLayout(false);
            this.group_box_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box_logo)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox group_box_login;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox text_box_password;
        private System.Windows.Forms.TextBox text_box_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.PictureBox picture_box_logo;
    }
}
