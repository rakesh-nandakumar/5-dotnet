using StudentManagementSystem.Data;

namespace StudentManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private DatabaseHelper dbHelper;

        // Controls
        private PictureBox LogoPictureBox = null!;
        private GroupBox LoginGroupBox = null!;
        private Label TitleLabel = null!;
        private Label UsernameLabel = null!;
        private Label PasswordLabel = null!;
        private TextBox UsernameTextBox = null!;
        private TextBox PasswordTextBox = null!;
        private Button LoginButton = null!;
        private Button ClearButton = null!;
        private Button ExitButton = null!;

        public LoginForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
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
            this.BackColor = Color.White;

            // PictureBox Logo
            LogoPictureBox = new PictureBox();
            LogoPictureBox.Location = new Point(140, 20);
            LogoPictureBox.Size = new Size(120, 120);
            LogoPictureBox.BorderStyle = BorderStyle.FixedSingle;
            LogoPictureBox.BackColor = Color.White;
            LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            
            // Load logo image
            string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "school_logo.png");
            if (File.Exists(logoPath))
            {
                LogoPictureBox.Image = Image.FromFile(logoPath);
            }
            
            this.Controls.Add(LogoPictureBox);

            // Label Title
            TitleLabel = new Label();
            TitleLabel.Text = "Skills International";
            TitleLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            TitleLabel.Location = new Point(90, 150);
            TitleLabel.Size = new Size(250, 35);
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            TitleLabel.ForeColor = Color.FromArgb(30, 58, 138);
            this.Controls.Add(TitleLabel);

            // GroupBox Login
            LoginGroupBox = new GroupBox();
            LoginGroupBox.Text = "Login";
            LoginGroupBox.Location = new Point(50, 195);
            LoginGroupBox.Size = new Size(310, 100);
            LoginGroupBox.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Controls.Add(LoginGroupBox);

            // Label Username
            UsernameLabel = new Label();
            UsernameLabel.Text = "Username:";
            UsernameLabel.Location = new Point(20, 30);
            UsernameLabel.Size = new Size(80, 20);
            LoginGroupBox.Controls.Add(UsernameLabel);

            // TextBox Username
            UsernameTextBox = new TextBox();
            UsernameTextBox.Location = new Point(110, 28);
            UsernameTextBox.Size = new Size(180, 25);
            UsernameTextBox.Font = new Font("Arial", 12);
            LoginGroupBox.Controls.Add(UsernameTextBox);

            // Label Password
            PasswordLabel = new Label();
            PasswordLabel.Text = "Password:";
            PasswordLabel.Location = new Point(20, 65);
            PasswordLabel.Size = new Size(80, 20);
            LoginGroupBox.Controls.Add(PasswordLabel);

            // TextBox Password
            PasswordTextBox = new TextBox();
            PasswordTextBox.Location = new Point(110, 63);
            PasswordTextBox.Size = new Size(180, 25);
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Font = new Font("Arial", 12);
            LoginGroupBox.Controls.Add(PasswordTextBox);

            // Button Login
            LoginButton = new Button();
            LoginButton.Text = "Login";
            LoginButton.Location = new Point(50, 305);
            LoginButton.Size = new Size(90, 30);
            LoginButton.BackColor = Color.FromArgb(30, 58, 138);
            LoginButton.ForeColor = Color.White;
            LoginButton.Font = new Font("Arial", 12, FontStyle.Bold);
            LoginButton.FlatStyle = FlatStyle.Standard;
            LoginButton.Click += LoginButton_Click;
            this.Controls.Add(LoginButton);

            // Button Clear
            ClearButton = new Button();
            ClearButton.Text = "Clear";
            ClearButton.Location = new Point(160, 305);
            ClearButton.Size = new Size(90, 30);
            ClearButton.BackColor = Color.FromArgb(245, 158, 11);
            ClearButton.ForeColor = Color.White;
            ClearButton.Font = new Font("Arial", 12, FontStyle.Bold);
            ClearButton.FlatStyle = FlatStyle.Standard;
            ClearButton.Click += ClearButton_Click;
            this.Controls.Add(ClearButton);

            // Button Exit
            ExitButton = new Button();
            ExitButton.Text = "Exit";
            ExitButton.Location = new Point(270, 305);
            ExitButton.Size = new Size(90, 30);
            ExitButton.BackColor = Color.FromArgb(30, 58, 138);
            ExitButton.ForeColor = Color.White;
            ExitButton.Font = new Font("Arial", 12, FontStyle.Bold);
            ExitButton.FlatStyle = FlatStyle.Standard;
            ExitButton.Click += ExitButton_Click;
            this.Controls.Add(ExitButton);

            this.ResumeLayout();
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            string EnteredUsername = UsernameTextBox.Text.Trim();
            string EnteredPassword = PasswordTextBox.Text;

            // Validate input using separate method
            if (!ValidateInputs())
                return;

            // Validate credentials using DatabaseHelper
            if (dbHelper.ValidateUser(EnteredUsername, EnteredPassword))
            {
                // Login successful
                MessageBox.Show("Welcome to Skills International", "Authentication Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.FormClosed += (s, args) => this.Close();
                registrationForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.", "Authentication Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Clear();
                UsernameTextBox.Focus();
            }
        }

        // Separate validation method - Version 2 style
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                ShowError("Please enter your username");
                UsernameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                ShowError("Please enter your password");
                PasswordTextBox.Focus();
                return false;
            }

            return true;
        }

        // Helper method to show errors
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Validation Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ClearButton_Click(object? sender, EventArgs e)
        {
            // Using Clear() method - Version 2 style
            UsernameTextBox.Clear();
            PasswordTextBox.Clear();
            UsernameTextBox.Focus();
        }

        private void ExitButton_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Do you wish to exit the application?", 
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
