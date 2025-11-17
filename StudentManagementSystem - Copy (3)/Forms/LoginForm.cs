using StudentManagementSystem.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        // ErrorProvider for validation - Version 3 style
        private ErrorProvider errorProvider = new ErrorProvider();

        // Controls - Hungarian notation
        private PictureBox pbxLogo = null!;
        private GroupBox grpLogin = null!;
        private Label lblTitle = null!;
        private Label lblUsername = null!;
        private Label lblPassword = null!;
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Button btnLogin = null!;
        private Button btnClear = null!;
        private Button btnExit = null!;

        public LoginForm()
        {
            InitializeComponent();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Login - Skills International";
            this.Size = new Size(420, 380);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(248, 249, 250);

            // PictureBox Logo
            pbxLogo = new PictureBox();
            pbxLogo.Location = new Point(140, 20);
            pbxLogo.Size = new Size(120, 120);
            pbxLogo.BorderStyle = BorderStyle.FixedSingle;
            pbxLogo.BackColor = Color.White;
            pbxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            
            // Load logo image
            string logoFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo_image.png");
            if (File.Exists(logoFilePath))
            {
                pbxLogo.Image = Image.FromFile(logoFilePath);
            }
            
            this.Controls.Add(pbxLogo);

            // Label Title
            lblTitle = new Label();
            lblTitle.Text = "Skills International";
            lblTitle.Font = new Font("Calibri", 16, FontStyle.Bold);
            lblTitle.Location = new Point(90, 150);
            lblTitle.Size = new Size(250, 35);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.ForeColor = Color.Black;
            this.Controls.Add(lblTitle);

            // GroupBox Login
            grpLogin = new GroupBox();
            grpLogin.Text = "Login";
            grpLogin.Location = new Point(50, 195);
            grpLogin.Size = new Size(310, 100);
            grpLogin.Font = new Font("Calibri", 10, FontStyle.Bold);
            this.Controls.Add(grpLogin);

            // Label Username
            lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(20, 30);
            lblUsername.Size = new Size(80, 20);
            grpLogin.Controls.Add(lblUsername);

            // TextBox Username
            txtUsername = new TextBox();
            txtUsername.Location = new Point(110, 28);
            txtUsername.Size = new Size(180, 25);
            txtUsername.Font = new Font("Calibri", 10);
            grpLogin.Controls.Add(txtUsername);

            // Label Password
            lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(20, 65);
            lblPassword.Size = new Size(80, 20);
            grpLogin.Controls.Add(lblPassword);

            // TextBox Password
            txtPassword = new TextBox();
            txtPassword.Location = new Point(110, 63);
            txtPassword.Size = new Size(180, 25);
            txtPassword.PasswordChar = '*';
            txtPassword.Font = new Font("Calibri", 10);
            grpLogin.Controls.Add(txtPassword);

            // Button Login
            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(50, 305);
            btnLogin.Size = new Size(90, 30);
            btnLogin.BackColor = Color.Black;
            btnLogin.ForeColor = Color.FromArgb(248, 249, 250);
            btnLogin.Font = new Font("Calibri", 10, FontStyle.Bold);
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Click += btnLogin_Click;
            this.Controls.Add(btnLogin);

            // Button Clear
            btnClear = new Button();
            btnClear.Text = "Clear";
            btnClear.Location = new Point(160, 305);
            btnClear.Size = new Size(90, 30);
            btnClear.BackColor = Color.DimGray;
            btnClear.ForeColor = Color.FromArgb(248, 249, 250);
            btnClear.Font = new Font("Calibri", 10, FontStyle.Bold);
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Click += btnClear_Click;
            this.Controls.Add(btnClear);

            // Button Exit
            btnExit = new Button();
            btnExit.Text = "Exit";
            btnExit.Location = new Point(270, 305);
            btnExit.Size = new Size(90, 30);
            btnExit.BackColor = Color.DarkGray;
            btnExit.ForeColor = Color.FromArgb(248, 249, 250);
            btnExit.Font = new Font("Calibri", 10, FontStyle.Bold);
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Click += btnExit_Click;
            this.Controls.Add(btnExit);

            this.ResumeLayout();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string strUsername = txtUsername.Text.Trim();
            string strPassword = txtPassword.Text;

            // Validate with ErrorProvider - Version 3 style
            if (!ValidateInput(txtUsername, "Username"))
            {
                txtUsername.Focus();
                return;
            }

            if (!ValidateInput(txtPassword, "Password"))
            {
                txtPassword.Focus();
                return;
            }

            // Validate credentials using singleton DBConnection
            if (ValidateUserCredentials(strUsername, strPassword))
            {
                // Login successful
                MessageBox.Show("Access Granted", "Login", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.FormClosed += (s, args) => this.Close();
                registrationForm.Show();
            }
            else
            {
                MessageBox.Show("Access denied", "Login", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        // Validation with ErrorProvider - Version 3 style
        private bool ValidateInput(TextBox textBox, string fieldName)
        {
            if (textBox.Text.Trim() == "")
            {
                errorProvider.SetError(textBox, $"{fieldName} is required");
                return false;
            }
            errorProvider.SetError(textBox, "");
            return true;
        }

        // Singleton DBConnection usage
        private bool ValidateUserCredentials(string strUsername, string strPassword)
        {
            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", strUsername);
                        cmd.Parameters.AddWithValue("@password", strPassword);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // Clear using loop - Version 3 style
        private void btnClear_Click(object? sender, EventArgs e)
        {
            foreach (Control ctrl in grpLogin.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
                    errorProvider.SetError(ctrl, "");
                }
            }
            txtUsername.Focus();
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Exit application?", 
                "Confirm Exit", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
