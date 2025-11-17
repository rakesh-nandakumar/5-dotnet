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

            // Form properties
            this.Text = "Login - Skills International";
            this.Size = new Size(420, 380);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // PictureBox Logo
            pictureBoxLogo = new PictureBox();
            pictureBoxLogo.Location = new Point(140, 20);
            pictureBoxLogo.Size = new Size(120, 120);
            pictureBoxLogo.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxLogo.BackColor = Color.LightGray;
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(pictureBoxLogo);

            // Label Title
            labelTitle = new Label();
            labelTitle.Text = "Skills International";
            labelTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            labelTitle.Location = new Point(90, 150);
            labelTitle.Size = new Size(250, 35);
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.ForeColor = Color.FromArgb(0, 102, 204);
            this.Controls.Add(labelTitle);

            // GroupBox Login
            groupBoxLogin = new GroupBox();
            groupBoxLogin.Text = "Login";
            groupBoxLogin.Location = new Point(50, 195);
            groupBoxLogin.Size = new Size(310, 100);
            groupBoxLogin.Font = new Font("Arial", 10, FontStyle.Bold);
            this.Controls.Add(groupBoxLogin);

            // Label Username
            labelUsername = new Label();
            labelUsername.Text = "Username:";
            labelUsername.Location = new Point(20, 30);
            labelUsername.Size = new Size(80, 20);
            groupBoxLogin.Controls.Add(labelUsername);

            // TextBox Username
            textBoxUsername = new TextBox();
            textBoxUsername.Location = new Point(110, 28);
            textBoxUsername.Size = new Size(180, 25);
            textBoxUsername.Font = new Font("Arial", 10);
            groupBoxLogin.Controls.Add(textBoxUsername);

            // Label Password
            labelPassword = new Label();
            labelPassword.Text = "Password:";
            labelPassword.Location = new Point(20, 65);
            labelPassword.Size = new Size(80, 20);
            groupBoxLogin.Controls.Add(labelPassword);

            // TextBox Password
            textBoxPassword = new TextBox();
            textBoxPassword.Location = new Point(110, 63);
            textBoxPassword.Size = new Size(180, 25);
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Font = new Font("Arial", 10);
            groupBoxLogin.Controls.Add(textBoxPassword);

            // Button Login
            buttonLogin = new Button();
            buttonLogin.Text = "Login";
            buttonLogin.Location = new Point(50, 305);
            buttonLogin.Size = new Size(90, 30);
            buttonLogin.BackColor = Color.FromArgb(0, 102, 204);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Font = new Font("Arial", 10, FontStyle.Bold);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Click += ButtonLogin_Click;
            this.Controls.Add(buttonLogin);

            // Button Clear
            buttonClear = new Button();
            buttonClear.Text = "Clear";
            buttonClear.Location = new Point(160, 305);
            buttonClear.Size = new Size(90, 30);
            buttonClear.BackColor = Color.FromArgb(255, 153, 0);
            buttonClear.ForeColor = Color.White;
            buttonClear.Font = new Font("Arial", 10, FontStyle.Bold);
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Click += ButtonClear_Click;
            this.Controls.Add(buttonClear);

            // Button Exit
            buttonExit = new Button();
            buttonExit.Text = "Exit";
            buttonExit.Location = new Point(270, 305);
            buttonExit.Size = new Size(90, 30);
            buttonExit.BackColor = Color.FromArgb(220, 53, 69);
            buttonExit.ForeColor = Color.White;
            buttonExit.Font = new Font("Arial", 10, FontStyle.Bold);
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Click += ButtonExit_Click;
            this.Controls.Add(buttonExit);

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
