using StudentManagementSystem.Data;

namespace StudentManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private DatabaseHelper dbHelper;

        // Controls
        private PictureBox pictureBoxLogo = null!;
        private GroupBox groupBoxLogin = null!;
        private Label labelTitle = null!;
        private Label labelUsername = null!;
        private Label labelPassword = null!;
        private TextBox textBoxUsername = null!;
        private TextBox textBoxPassword = null!;
        private Button buttonLogin = null!;
        private Button buttonClear = null!;
        private Button buttonExit = null!;

        public LoginForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties - Modern sleek design
            this.Text = "Login - Skills International";
            this.Size = new Size(500, 550);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 242, 245); // Light gray background

            // Header Panel (Dark gradient effect)
            Panel headerPanel = new Panel();
            headerPanel.Location = new Point(0, 0);
            headerPanel.Size = new Size(500, 180);
            headerPanel.BackColor = Color.FromArgb(25, 118, 210); // Material Blue
            this.Controls.Add(headerPanel);

            // PictureBox Logo - Centered in header
            pictureBoxLogo = new PictureBox();
            pictureBoxLogo.Location = new Point(175, 20);
            pictureBoxLogo.Size = new Size(150, 90);
            pictureBoxLogo.BorderStyle = BorderStyle.None;
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            
            // Load company logo image
            string companyLogoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "company_logo.png");
            if (File.Exists(companyLogoPath))
            {
                pictureBoxLogo.Image = Image.FromFile(companyLogoPath);
            }
            
            headerPanel.Controls.Add(pictureBoxLogo);

            // Label Title - Welcome message
            labelTitle = new Label();
            labelTitle.Text = "Welcome Back!";
            labelTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            labelTitle.Location = new Point(0, 120);
            labelTitle.Size = new Size(500, 40);
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.ForeColor = Color.White;
            labelTitle.BackColor = Color.Transparent;
            headerPanel.Controls.Add(labelTitle);

            // Main content panel with shadow effect
            Panel contentPanel = new Panel();
            contentPanel.Location = new Point(40, 200);
            contentPanel.Size = new Size(420, 260);
            contentPanel.BackColor = Color.White;
            this.Controls.Add(contentPanel);

            // GroupBox Login - Modern flat style
            groupBoxLogin = new GroupBox();
            groupBoxLogin.Text = "";
            groupBoxLogin.Location = new Point(30, 20);
            groupBoxLogin.Size = new Size(360, 180);
            groupBoxLogin.Font = new Font("Segoe UI", 10);
            groupBoxLogin.FlatStyle = FlatStyle.Flat;
            contentPanel.Controls.Add(groupBoxLogin);

            // Label Username - Modern style
            labelUsername = new Label();
            labelUsername.Text = "USERNAME";
            labelUsername.Location = new Point(20, 20);
            labelUsername.Size = new Size(320, 20);
            labelUsername.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            labelUsername.ForeColor = Color.FromArgb(100, 100, 100);
            groupBoxLogin.Controls.Add(labelUsername);

            // TextBox Username - Modern with border
            textBoxUsername = new TextBox();
            textBoxUsername.Location = new Point(20, 45);
            textBoxUsername.Size = new Size(320, 35);
            textBoxUsername.Font = new Font("Segoe UI", 12);
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            groupBoxLogin.Controls.Add(textBoxUsername);

            // Label Password - Modern style
            labelPassword = new Label();
            labelPassword.Text = "PASSWORD";
            labelPassword.Location = new Point(20, 90);
            labelPassword.Size = new Size(320, 20);
            labelPassword.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            labelPassword.ForeColor = Color.FromArgb(100, 100, 100);
            groupBoxLogin.Controls.Add(labelPassword);

            // TextBox Password - Modern with border
            textBoxPassword = new TextBox();
            textBoxPassword.Location = new Point(20, 115);
            textBoxPassword.Size = new Size(320, 35);
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Font = new Font("Segoe UI", 12);
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            groupBoxLogin.Controls.Add(textBoxPassword);

            // Button Login - Large primary button
            buttonLogin = new Button();
            buttonLogin.Text = "LOGIN";
            buttonLogin.Location = new Point(30, 215);
            buttonLogin.Size = new Size(360, 45);
            buttonLogin.BackColor = Color.FromArgb(76, 175, 80); // Material Green
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.Click += ButtonLogin_Click;
            contentPanel.Controls.Add(buttonLogin);

            // Bottom button panel
            Panel bottomPanel = new Panel();
            bottomPanel.Location = new Point(40, 470);
            bottomPanel.Size = new Size(420, 40);
            bottomPanel.BackColor = Color.Transparent;
            this.Controls.Add(bottomPanel);

            // Button Clear - Secondary button
            buttonClear = new Button();
            buttonClear.Text = "CLEAR";
            buttonClear.Location = new Point(0, 0);
            buttonClear.Size = new Size(200, 38);
            buttonClear.BackColor = Color.FromArgb(158, 158, 158); // Gray
            buttonClear.ForeColor = Color.White;
            buttonClear.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.Cursor = Cursors.Hand;
            buttonClear.Click += ButtonClear_Click;
            bottomPanel.Controls.Add(buttonClear);

            // Button Exit - Danger button
            buttonExit = new Button();
            buttonExit.Text = "EXIT";
            buttonExit.Location = new Point(220, 0);
            buttonExit.Size = new Size(200, 38);
            buttonExit.BackColor = Color.FromArgb(244, 67, 54); // Material Red
            buttonExit.ForeColor = Color.White;
            buttonExit.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.Cursor = Cursors.Hand;
            buttonExit.Click += ButtonExit_Click;
            bottomPanel.Controls.Add(buttonExit);

            this.ResumeLayout();
        }

        private void ButtonLogin_Click(object? sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter username", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter password", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return;
            }

            // Validate credentials
            if (dbHelper.ValidateUser(username, password))
            {
                // Login successful
                this.Hide();
                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.FormClosed += (s, args) => this.Close();
                registrationForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();
                textBoxUsername.Focus();
            }
        }

        private void ButtonClear_Click(object? sender, EventArgs e)
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxUsername.Focus();
        }

        private void ButtonExit_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?", 
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
