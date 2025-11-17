using System.Configuration;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private DatabaseHelper dbHelper;

        // Controls - Abbreviated naming convention (btn_, txt_, lbl_, pbx_, grp_)
        private PictureBox pbx_Logo = null!;
        private GroupBox grp_Login = null!;
        private Label lbl_Title = null!;
        private Label lbl_Username = null!;
        private Label lbl_Password = null!;
        private TextBox txt_Username = null!;
        private TextBox txt_Password = null!;
        private Button btn_Login = null!;
        private Button btn_Clear = null!;
        private Button btn_Exit = null!;

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
            this.BackColor = ColorTranslator.FromHtml("#14B8A6");  // Teal background

            // PictureBox Logo
            pbx_Logo = new PictureBox();
            pbx_Logo.Location = new Point(140, 20);
            pbx_Logo.Size = new Size(120, 120);
            pbx_Logo.BorderStyle = BorderStyle.None;
            pbx_Logo.BackColor = Color.White;
            pbx_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            
            // Load brand logo image
            string brandLogoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "brand_logo.png");
            if (File.Exists(brandLogoPath))
            {
                pbx_Logo.Image = Image.FromFile(brandLogoPath);
            }
            
            this.Controls.Add(pbx_Logo);

            // Label Title
            lbl_Title = new Label();
            lbl_Title.Text = "Skills International";
            lbl_Title.Font = new Font("Verdana", 16, FontStyle.Bold);
            lbl_Title.Location = new Point(70, 150);
            lbl_Title.Size = new Size(280, 35);
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Title.ForeColor = Color.White;
            this.Controls.Add(lbl_Title);

            // GroupBox Login
            grp_Login = new GroupBox();
            grp_Login.Text = "Login";
            grp_Login.Location = new Point(50, 195);
            grp_Login.Size = new Size(310, 100);
            grp_Login.Font = new Font("Verdana", 10, FontStyle.Bold);
            grp_Login.ForeColor = Color.White;
            this.Controls.Add(grp_Login);

            // Label Username
            lbl_Username = new Label();
            lbl_Username.Text = "Username:";
            lbl_Username.Location = new Point(20, 30);
            lbl_Username.Size = new Size(85, 20);
            lbl_Username.Font = new Font("Verdana", 10);
            grp_Login.Controls.Add(lbl_Username);

            // TextBox Username
            txt_Username = new TextBox();
            txt_Username.Location = new Point(110, 28);
            txt_Username.Size = new Size(180, 25);
            txt_Username.Font = new Font("Verdana", 10);
            grp_Login.Controls.Add(txt_Username);

            // Label Password
            lbl_Password = new Label();
            lbl_Password.Text = "Password:";
            lbl_Password.Location = new Point(20, 65);
            lbl_Password.Size = new Size(85, 20);
            lbl_Password.Font = new Font("Verdana", 10);
            grp_Login.Controls.Add(lbl_Password);

            // TextBox Password
            txt_Password = new TextBox();
            txt_Password.Location = new Point(110, 63);
            txt_Password.Size = new Size(180, 25);
            txt_Password.PasswordChar = '●';  // Bullet character
            txt_Password.Font = new Font("Verdana", 10);
            grp_Login.Controls.Add(txt_Password);

            // Button Login
            btn_Login = new Button();
            btn_Login.Text = "Login";
            btn_Login.Location = new Point(50, 305);
            btn_Login.Size = new Size(90, 35);
            btn_Login.BackColor = ColorTranslator.FromHtml("#F97316");  // Orange
            btn_Login.ForeColor = Color.White;
            btn_Login.Font = new Font("Verdana", 11, FontStyle.Bold);
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.FlatAppearance.BorderSize = 2;
            btn_Login.FlatAppearance.BorderColor = Color.White;
            btn_Login.Click += btn_Login_Click;
            this.Controls.Add(btn_Login);

            // Button Clear
            btn_Clear = new Button();
            btn_Clear.Text = "Clear";
            btn_Clear.Location = new Point(160, 305);
            btn_Clear.Size = new Size(90, 35);
            btn_Clear.BackColor = ColorTranslator.FromHtml("#0F766E");  // Dark teal
            btn_Clear.ForeColor = Color.White;
            btn_Clear.Font = new Font("Verdana", 11, FontStyle.Bold);
            btn_Clear.FlatStyle = FlatStyle.Flat;
            btn_Clear.FlatAppearance.BorderSize = 2;
            btn_Clear.FlatAppearance.BorderColor = Color.White;
            btn_Clear.Click += btn_Clear_Click;
            this.Controls.Add(btn_Clear);

            // Button Exit
            btn_Exit = new Button();
            btn_Exit.Text = "Exit";
            btn_Exit.Location = new Point(270, 305);
            btn_Exit.Size = new Size(90, 35);
            btn_Exit.BackColor = Color.FromArgb(220, 53, 69);
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Font = new Font("Verdana", 11, FontStyle.Bold);
            btn_Exit.FlatStyle = FlatStyle.Flat;
            btn_Exit.FlatAppearance.BorderSize = 2;
            btn_Exit.FlatAppearance.BorderColor = Color.White;
            btn_Exit.Click += btn_Exit_Click;
            this.Controls.Add(btn_Exit);

            this.ResumeLayout();
        }

        private void btn_Login_Click(object? sender, EventArgs e)
        {
            string uname = txt_Username.Text.Trim();
            string pwd = txt_Password.Text;

            // TryParse validation - Version 4 style (validate non-empty with TryParse pattern)
            if (!TryValidateInput(uname, "Username"))
            {
                txt_Username.Focus();
                return;
            }

            if (!TryValidateInput(pwd, "Password"))
            {
                txt_Password.Focus();
                return;
            }

            // Validate credentials
            if (dbHelper.ValidateUser(uname, pwd))
            {
                MessageBox.Show("Login completed successfully", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.FormClosed += (s, args) => this.Close();
                registrationForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials provided", "Login Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Password.Clear();
                txt_Username.Focus();
            }
        }

        // TryParse validation pattern - Version 4 characteristic
        private bool TryValidateInput(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show($"{fieldName} is required", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_Clear_Click(object? sender, EventArgs e)
        {
            // LINQ approach - Version 4 characteristic
            this.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            grp_Login.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            txt_Username.Focus();
        }

        private void btn_Exit_Click(object? sender, EventArgs e)
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
