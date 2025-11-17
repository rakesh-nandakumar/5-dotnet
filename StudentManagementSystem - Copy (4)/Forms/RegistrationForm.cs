using System.Configuration;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Forms
{
    public partial class RegistrationForm : Form
    {
        private DatabaseHelper dbHelper;

        // GroupBoxes - Abbreviated naming (grp_)
        private GroupBox grp_Registration = null!;
        private GroupBox grp_BasicDetails = null!;
        private GroupBox grp_ContactDetails = null!;
        private GroupBox grp_ParentDetails = null!;

        // Controls - Abbreviated naming (lbl_, cmb_, txt_, dtp_, rad_)
        private Label lbl_RegNo = null!;
        private ComboBox cmb_RegNo = null!;
        private Label lbl_FirstName = null!;
        private TextBox txt_FirstName = null!;
        private Label lbl_LastName = null!;
        private TextBox txt_LastName = null!;
        private Label lbl_DOB = null!;
        private DateTimePicker dtp_DOB = null!;
        private Label lbl_Gender = null!;
        private RadioButton rad_Male = null!;
        private RadioButton rad_Female = null!;
        private Label lbl_Address = null!;
        private TextBox txt_Address = null!;
        private Label lbl_Email = null!;
        private TextBox txt_Email = null!;
        private Label lbl_Mobile = null!;
        private TextBox txt_Mobile = null!;
        private Label lbl_HomePhone = null!;
        private TextBox txt_HomePhone = null!;
        private Label lbl_ParentName = null!;
        private TextBox txt_ParentName = null!;
        private Label lbl_NIC = null!;
        private TextBox txt_NIC = null!;
        private Label lbl_ContactNo = null!;
        private TextBox txt_ContactNo = null!;

        // Buttons - Abbreviated naming (btn_)
        private Button btn_Register = null!;
        private Button btn_Update = null!;
        private Button btn_Clear = null!;
        private Button btn_Delete = null!;

        // LinkLabels - Abbreviated naming (lnk_)
        private LinkLabel lnk_Logout = null!;
        private LinkLabel linkLabelExit = null!;

        public RegistrationForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadRegistrationNumbers();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Student Registration - Skills International";
            this.Size = new Size(900, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.WindowState = FormWindowState.Normal;

            // GroupBox Registration (Main Container)
            grp_Registration = new GroupBox();
            grp_Registration.Text = "Student Registration";
            grp_Registration.Location = new Point(20, 20);
            grp_Registration.Size = new Size(840, 630);
            grp_Registration.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Controls.Add(grp_Registration);

            // Label & ComboBox Registration Number
            lbl_RegNo = new Label();
            lbl_RegNo.Text = "Registration No:";
            lbl_RegNo.Location = new Point(30, 40);
            lbl_RegNo.Size = new Size(150, 25);
            lbl_RegNo.Font = new Font("Arial", 10);
            grp_Registration.Controls.Add(lbl_RegNo);

            cmb_RegNo = new ComboBox();
            cmb_RegNo.Location = new Point(190, 38);
            cmb_RegNo.Size = new Size(200, 25);
            cmb_RegNo.Font = new Font("Arial", 10);
            cmb_RegNo.SelectedIndexChanged += ComboBoxRegNo_SelectedIndexChanged;
            grp_Registration.Controls.Add(cmb_RegNo);

            // GroupBox Basic Details
            grp_BasicDetails = new GroupBox();
            grp_BasicDetails.Text = "Basic Details";
            grp_BasicDetails.Location = new Point(30, 80);
            grp_BasicDetails.Size = new Size(780, 180);
            grp_BasicDetails.Font = new Font("Arial", 10, FontStyle.Bold);
            grp_Registration.Controls.Add(grp_BasicDetails);

            // First Name
            lbl_FirstName = new Label();
            lbl_FirstName.Text = "First Name:";
            lbl_FirstName.Location = new Point(30, 40);
            lbl_FirstName.Size = new Size(100, 25);
            lbl_FirstName.Font = new Font("Arial", 10);
            grp_BasicDetails.Controls.Add(lbl_FirstName);

            txt_FirstName = new TextBox();
            txt_FirstName.Location = new Point(160, 38);
            txt_FirstName.Size = new Size(200, 25);
            txt_FirstName.Font = new Font("Arial", 10);
            grp_BasicDetails.Controls.Add(txt_FirstName);

            // Last Name
            lbl_LastName = new Label();
            lbl_LastName.Text = "Last Name:";
            lbl_LastName.Location = new Point(420, 40);
            lbl_LastName.Size = new Size(100, 25);
            lbl_LastName.Font = new Font("Arial", 10);
            grp_BasicDetails.Controls.Add(lbl_LastName);

            txt_LastName = new TextBox();
            txt_LastName.Location = new Point(550, 38);
            txt_LastName.Size = new Size(200, 25);
            txt_LastName.Font = new Font("Arial", 10);
            grp_BasicDetails.Controls.Add(txt_LastName);

            // Date of Birth
            lbl_DOB = new Label();
            lbl_DOB.Text = "Date of Birth:";
            lbl_DOB.Location = new Point(30, 85);
            lbl_DOB.Size = new Size(100, 25);
            lbl_DOB.Font = new Font("Arial", 10);
            grp_BasicDetails.Controls.Add(lbl_DOB);

            dtp_DOB = new DateTimePicker();
            dtp_DOB.Location = new Point(160, 83);
            dtp_DOB.Size = new Size(200, 25);
            dtp_DOB.Font = new Font("Arial", 10);
            dtp_DOB.Format = DateTimePickerFormat.Short;
            grp_BasicDetails.Controls.Add(dtp_DOB);

            // Gender
            lbl_Gender = new Label();
            lbl_Gender.Text = "Gender:";
            lbl_Gender.Location = new Point(30, 130);
            lbl_Gender.Size = new Size(100, 25);
            lbl_Gender.Font = new Font("Arial", 10);
            grp_BasicDetails.Controls.Add(lbl_Gender);

            rad_Male = new RadioButton();
            rad_Male.Text = "Male";
            rad_Male.Location = new Point(160, 130);
            rad_Male.Size = new Size(80, 25);
            rad_Male.Font = new Font("Arial", 10);
            grp_BasicDetails.Controls.Add(rad_Male);

            rad_Female = new RadioButton();
            rad_Female.Text = "Female";
            rad_Female.Location = new Point(260, 130);
            rad_Female.Size = new Size(100, 25);
            rad_Female.Font = new Font("Arial", 10);
            grp_BasicDetails.Controls.Add(rad_Female);

            // GroupBox Contact Details
            grp_ContactDetails = new GroupBox();
            grp_ContactDetails.Text = "Contact Details";
            grp_ContactDetails.Location = new Point(30, 270);
            grp_ContactDetails.Size = new Size(780, 180);
            grp_ContactDetails.Font = new Font("Arial", 10, FontStyle.Bold);
            grp_Registration.Controls.Add(grp_ContactDetails);

            // Address
            lbl_Address = new Label();
            lbl_Address.Text = "Address:";
            lbl_Address.Location = new Point(30, 40);
            lbl_Address.Size = new Size(100, 25);
            lbl_Address.Font = new Font("Arial", 10);
            grp_ContactDetails.Controls.Add(lbl_Address);

            txt_Address = new TextBox();
            txt_Address.Location = new Point(160, 38);
            txt_Address.Size = new Size(590, 60);
            txt_Address.Multiline = true;
            txt_Address.ScrollBars = ScrollBars.Vertical;
            txt_Address.Font = new Font("Arial", 10);
            grp_ContactDetails.Controls.Add(txt_Address);

            // Email
            lbl_Email = new Label();
            lbl_Email.Text = "Email:";
            lbl_Email.Location = new Point(30, 115);
            lbl_Email.Size = new Size(100, 25);
            lbl_Email.Font = new Font("Arial", 10);
            grp_ContactDetails.Controls.Add(lbl_Email);

            txt_Email = new TextBox();
            txt_Email.Location = new Point(160, 113);
            txt_Email.Size = new Size(200, 25);
            txt_Email.Font = new Font("Arial", 10);
            grp_ContactDetails.Controls.Add(txt_Email);

            // Mobile Phone
            lbl_Mobile = new Label();
            lbl_Mobile.Text = "Mobile Phone:";
            lbl_Mobile.Location = new Point(420, 115);
            lbl_Mobile.Size = new Size(120, 25);
            lbl_Mobile.Font = new Font("Arial", 10);
            grp_ContactDetails.Controls.Add(lbl_Mobile);

            txt_Mobile = new TextBox();
            txt_Mobile.Location = new Point(550, 113);
            txt_Mobile.Size = new Size(200, 25);
            txt_Mobile.Font = new Font("Arial", 10);
            grp_ContactDetails.Controls.Add(txt_Mobile);

            // Home Phone
            lbl_HomePhone = new Label();
            lbl_HomePhone.Text = "Home Phone:";
            lbl_HomePhone.Location = new Point(30, 145);
            lbl_HomePhone.Size = new Size(120, 25);
            lbl_HomePhone.Font = new Font("Arial", 10);
            grp_ContactDetails.Controls.Add(lbl_HomePhone);

            txt_HomePhone = new TextBox();
            txt_HomePhone.Location = new Point(160, 143);
            txt_HomePhone.Size = new Size(200, 25);
            txt_HomePhone.Font = new Font("Arial", 10);
            grp_ContactDetails.Controls.Add(txt_HomePhone);

            // GroupBox Parent Details
            grp_ParentDetails = new GroupBox();
            grp_ParentDetails.Text = "Parent Details";
            grp_ParentDetails.Location = new Point(30, 460);
            grp_ParentDetails.Size = new Size(780, 100);
            grp_ParentDetails.Font = new Font("Arial", 10, FontStyle.Bold);
            grp_Registration.Controls.Add(grp_ParentDetails);

            // Parent Name
            lbl_ParentName = new Label();
            lbl_ParentName.Text = "Parent Name:";
            lbl_ParentName.Location = new Point(30, 35);
            lbl_ParentName.Size = new Size(120, 25);
            lbl_ParentName.Font = new Font("Arial", 10);
            grp_ParentDetails.Controls.Add(lbl_ParentName);

            txt_ParentName = new TextBox();
            txt_ParentName.Location = new Point(160, 33);
            txt_ParentName.Size = new Size(200, 25);
            txt_ParentName.Font = new Font("Arial", 10);
            grp_ParentDetails.Controls.Add(txt_ParentName);

            // NIC
            lbl_NIC = new Label();
            lbl_NIC.Text = "NIC:";
            lbl_NIC.Location = new Point(420, 35);
            lbl_NIC.Size = new Size(120, 25);
            lbl_NIC.Font = new Font("Arial", 10);
            grp_ParentDetails.Controls.Add(lbl_NIC);

            txt_NIC = new TextBox();
            txt_NIC.Location = new Point(550, 33);
            txt_NIC.Size = new Size(200, 25);
            txt_NIC.Font = new Font("Arial", 10);
            grp_ParentDetails.Controls.Add(txt_NIC);

            // Contact No
            lbl_ContactNo = new Label();
            lbl_ContactNo.Text = "Contact No:";
            lbl_ContactNo.Location = new Point(30, 65);
            lbl_ContactNo.Size = new Size(120, 25);
            lbl_ContactNo.Font = new Font("Arial", 10);
            grp_ParentDetails.Controls.Add(lbl_ContactNo);

            txt_ContactNo = new TextBox();
            txt_ContactNo.Location = new Point(160, 63);
            txt_ContactNo.Size = new Size(200, 25);
            txt_ContactNo.Font = new Font("Arial", 10);
            grp_ParentDetails.Controls.Add(txt_ContactNo);

            // Buttons - Register
            btn_Register = new Button();
            btn_Register.Text = "Register";
            btn_Register.Location = new Point(30, 575);
            btn_Register.Size = new Size(120, 35);
            btn_Register.BackColor = Color.FromArgb(40, 167, 69);
            btn_Register.ForeColor = Color.White;
            btn_Register.Font = new Font("Arial", 10, FontStyle.Bold);
            btn_Register.FlatStyle = FlatStyle.Flat;
            btn_Register.Click += ButtonRegister_Click;
            grp_Registration.Controls.Add(btn_Register);

            // Button Update
            btn_Update = new Button();
            btn_Update.Text = "Update";
            btn_Update.Location = new Point(170, 575);
            btn_Update.Size = new Size(120, 35);
            btn_Update.BackColor = Color.FromArgb(0, 102, 204);
            btn_Update.ForeColor = Color.White;
            btn_Update.Font = new Font("Arial", 10, FontStyle.Bold);
            btn_Update.FlatStyle = FlatStyle.Flat;
            btn_Update.Click += ButtonUpdate_Click;
            grp_Registration.Controls.Add(btn_Update);

            // Button Clear
            btn_Clear = new Button();
            btn_Clear.Text = "Clear";
            btn_Clear.Location = new Point(310, 575);
            btn_Clear.Size = new Size(120, 35);
            btn_Clear.BackColor = Color.FromArgb(255, 153, 0);
            btn_Clear.ForeColor = Color.White;
            btn_Clear.Font = new Font("Arial", 10, FontStyle.Bold);
            btn_Clear.FlatStyle = FlatStyle.Flat;
            btn_Clear.Click += ButtonClear_Click;
            grp_Registration.Controls.Add(btn_Clear);

            // Button Delete
            btn_Delete = new Button();
            btn_Delete.Text = "Delete";
            btn_Delete.Location = new Point(450, 575);
            btn_Delete.Size = new Size(120, 35);
            btn_Delete.BackColor = Color.FromArgb(220, 53, 69);
            btn_Delete.ForeColor = Color.White;
            btn_Delete.Font = new Font("Arial", 10, FontStyle.Bold);
            btn_Delete.FlatStyle = FlatStyle.Flat;
            btn_Delete.Click += ButtonDelete_Click;
            grp_Registration.Controls.Add(btn_Delete);

            // LinkLabel Logout
            lnk_Logout = new LinkLabel();
            lnk_Logout.Text = "Logout";
            lnk_Logout.Location = new Point(720, 665);
            lnk_Logout.Size = new Size(60, 20);
            lnk_Logout.Font = new Font("Arial", 10);
            lnk_Logout.LinkClicked += LinkLabelLogout_LinkClicked;
            this.Controls.Add(lnk_Logout);

            // LinkLabel Exit
            linkLabelExit = new LinkLabel();
            linkLabelExit.Text = "Exit";
            linkLabelExit.Location = new Point(810, 665);
            linkLabelExit.Size = new Size(40, 20);
            linkLabelExit.Font = new Font("Arial", 10);
            linkLabelExit.LinkClicked += LinkLabelExit_LinkClicked;
            this.Controls.Add(linkLabelExit);

            this.ResumeLayout();
        }

        private void LoadRegistrationNumbers()
        {
            cmb_RegNo.Items.Clear();
            List<int> regNumbers = dbHelper.GetAllRegNumbers();
            foreach (int regNo in regNumbers)
            {
                cmb_RegNo.Items.Add(regNo);
            }
        }

        private void ComboBoxRegNo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmb_RegNo.SelectedItem != null)
            {
                int regNo = (int)cmb_RegNo.SelectedItem;
                Student? student = dbHelper.GetStudentByRegNo(regNo);

                if (student != null)
                {
                    txt_FirstName.Text = student.FirstName;
                    txt_LastName.Text = student.LastName;
                    dtp_DOB.Value = student.DateOfBirth;
                    
                    if (student.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                        rad_Male.Checked = true;
                    else if (student.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                        rad_Female.Checked = true;

                    txt_Address.Text = student.Address;
                    txt_Email.Text = student.Email;
                    txt_Mobile.Text = student.MobilePhone.ToString();
                    txt_HomePhone.Text = student.HomePhone.ToString();
                    txt_ParentName.Text = student.ParentName;
                    txt_NIC.Text = student.NIC;
                    txt_ContactNo.Text = student.ContactNo.ToString();
                }
            }
        }

        private void ButtonRegister_Click(object? sender, EventArgs e)
        {
            // Validate required fields
            if (!ValidateInputs(true))
                return;

            // Get registration number with TryParse - Version 4 style
            if (!int.TryParse(cmb_RegNo.Text, out int regNo))
            {
                MessageBox.Show("Valid Registration Number required", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_RegNo.Focus();
                return;
            }

            // Check if registration number already exists
            if (dbHelper.RegNoExists(regNo))
            {
                MessageBox.Show("Registration Number exists. Use Update instead.", 
                    "Duplicate Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create student object
            Student student = CreateStudentFromForm(regNo);

            // Insert into database
            if (dbHelper.InsertStudent(student))
            {
                MessageBox.Show("Registration completed", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegistrationNumbers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Registration failed", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUpdate_Click(object? sender, EventArgs e)
        {
            // Validate registration number is selected
            if (cmb_RegNo.SelectedItem == null)
            {
                MessageBox.Show("Select Registration Number to update", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate required fields
            if (!ValidateInputs(false))
                return;

            int regNo = (int)cmb_RegNo.SelectedItem;

            // Create student object
            Student student = CreateStudentFromForm(regNo);

            // Update in database
            if (dbHelper.UpdateStudent(student))
            {
                MessageBox.Show("Update completed", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegistrationNumbers();
            }
            else
            {
                MessageBox.Show("Update failed", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDelete_Click(object? sender, EventArgs e)
        {
            // Validate registration number is selected
            if (cmb_RegNo.SelectedItem == null)
            {
                MessageBox.Show("Select Registration Number to delete", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmation dialog
            DialogResult result = MessageBox.Show(
                "Delete this record?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int regNo = (int)cmb_RegNo.SelectedItem;

                if (dbHelper.DeleteStudent(regNo))
                {
                    MessageBox.Show("Delete completed", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRegistrationNumbers();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Delete failed", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void LinkLabelLogout_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void LinkLabelExit_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
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

        private bool ValidateInputs(bool isNewRegistration)
        {
            // Validate Registration Number (only for new registration)
            if (isNewRegistration && string.IsNullOrWhiteSpace(cmb_RegNo.Text))
            {
                MessageBox.Show("Registration Number is required.\n\nPlease enter a valid registration number.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_RegNo.Focus();
                return false;
            }

            // Validate Registration Number format (must be numeric)
            if (isNewRegistration)
            {
                if (!int.TryParse(cmb_RegNo.Text, out int regNo))
                {
                    MessageBox.Show("Registration Number must be a valid number.\n\nExample: 1001, 1002, etc.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmb_RegNo.Focus();
                    return false;
                }

                if (regNo <= 0)
                {
                    MessageBox.Show("Registration Number must be a positive number.\n\nPlease enter a number greater than 0.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmb_RegNo.Focus();
                    return false;
                }
            }

            // Validate First Name
            if (string.IsNullOrWhiteSpace(txt_FirstName.Text))
            {
                MessageBox.Show("First Name is required.\n\nPlease enter the student's first name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_FirstName.Focus();
                return false;
            }

            // Validate First Name format (only letters and spaces)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txt_FirstName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_FirstName.Focus();
                return false;
            }

            // Validate First Name length
            if (txt_FirstName.Text.Trim().Length < 2)
            {
                MessageBox.Show("First Name must be at least 2 characters long.\n\nPlease enter a valid first name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_FirstName.Focus();
                return false;
            }

            if (txt_FirstName.Text.Trim().Length > 50)
            {
                MessageBox.Show("First Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_FirstName.Focus();
                return false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(txt_LastName.Text))
            {
                MessageBox.Show("Last Name is required.\n\nPlease enter the student's last name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_LastName.Focus();
                return false;
            }

            // Validate Last Name format (only letters and spaces)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txt_LastName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_LastName.Focus();
                return false;
            }

            // Validate Last Name length
            if (txt_LastName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Last Name must be at least 2 characters long.\n\nPlease enter a valid last name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_LastName.Focus();
                return false;
            }

            if (txt_LastName.Text.Trim().Length > 50)
            {
                MessageBox.Show("Last Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_LastName.Focus();
                return false;
            }

            // Validate Date of Birth
            DateTime today = DateTime.Today;
            DateTime minDate = today.AddYears(-100); // Maximum age 100 years
            DateTime maxDate = today.AddYears(-5);   // Minimum age 5 years

            if (dtp_DOB.Value > today)
            {
                MessageBox.Show("Date of Birth cannot be in the future.\n\nPlease select a valid date.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_DOB.Focus();
                return false;
            }

            if (dtp_DOB.Value < minDate)
            {
                MessageBox.Show("Date of Birth is too far in the past.\n\nPlease select a valid date (within last 100 years).", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_DOB.Focus();
                return false;
            }

            if (dtp_DOB.Value > maxDate)
            {
                MessageBox.Show("Student must be at least 5 years old.\n\nPlease select an earlier date of birth.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_DOB.Focus();
                return false;
            }

            // Validate Gender
            if (!rad_Male.Checked && !rad_Female.Checked)
            {
                MessageBox.Show("Gender is required.\n\nPlease select either Male or Female.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rad_Male.Focus();
                return false;
            }

            // Validate Email (if provided)
            if (!string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                string email = txt_Email.Text.Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, 
                    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    MessageBox.Show("Please enter a valid email address.\n\nExample: student@example.com", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Email.Focus();
                    return false;
                }

                if (email.Length > 50)
                {
                    MessageBox.Show("Email cannot exceed 50 characters.\n\nPlease enter a shorter email address.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Email.Focus();
                    return false;
                }
            }

            // Validate Mobile Phone (if provided)
            if (!string.IsNullOrWhiteSpace(txt_Mobile.Text))
            {
                if (!int.TryParse(txt_Mobile.Text.Trim(), out int mobilePhone))
                {
                    MessageBox.Show("Mobile Phone must be a valid number.\n\nPlease enter only digits (e.g., 771234567).", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Mobile.Focus();
                    return false;
                }

                string mobileStr = txt_Mobile.Text.Trim();
                if (mobileStr.Length < 9 || mobileStr.Length > 10)
                {
                    MessageBox.Show("Mobile Phone must be 9-10 digits.\n\nExample: 771234567 or 0771234567", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Mobile.Focus();
                    return false;
                }

                if (mobilePhone <= 0)
                {
                    MessageBox.Show("Mobile Phone must be a positive number.\n\nPlease enter a valid phone number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Mobile.Focus();
                    return false;
                }
            }

            // Validate Home Phone (if provided)
            if (!string.IsNullOrWhiteSpace(txt_HomePhone.Text))
            {
                if (!int.TryParse(txt_HomePhone.Text.Trim(), out int homePhone))
                {
                    MessageBox.Show("Home Phone must be a valid number.\n\nPlease enter only digits (e.g., 112345678).", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_HomePhone.Focus();
                    return false;
                }

                string homeStr = txt_HomePhone.Text.Trim();
                if (homeStr.Length < 9 || homeStr.Length > 10)
                {
                    MessageBox.Show("Home Phone must be 9-10 digits.\n\nExample: 112345678 or 0112345678", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_HomePhone.Focus();
                    return false;
                }

                if (homePhone <= 0)
                {
                    MessageBox.Show("Home Phone must be a positive number.\n\nPlease enter a valid phone number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_HomePhone.Focus();
                    return false;
                }
            }

            // Validate Address length (if provided)
            if (!string.IsNullOrWhiteSpace(txt_Address.Text) && txt_Address.Text.Trim().Length > 50)
            {
                MessageBox.Show("Address cannot exceed 50 characters.\n\nPlease enter a shorter address.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Address.Focus();
                return false;
            }

            // Validate Parent Name (if provided)
            if (!string.IsNullOrWhiteSpace(txt_ParentName.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txt_ParentName.Text.Trim(), @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Parent Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ParentName.Focus();
                    return false;
                }

                if (txt_ParentName.Text.Trim().Length < 2)
                {
                    MessageBox.Show("Parent Name must be at least 2 characters long.\n\nPlease enter a valid name.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ParentName.Focus();
                    return false;
                }

                if (txt_ParentName.Text.Trim().Length > 50)
                {
                    MessageBox.Show("Parent Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ParentName.Focus();
                    return false;
                }
            }

            // Validate NIC (if provided)
            if (!string.IsNullOrWhiteSpace(txt_NIC.Text))
            {
                string nic = txt_NIC.Text.Trim();
                
                // NIC format: 12 digits or 9 digits + V (old format)
                if (!System.Text.RegularExpressions.Regex.IsMatch(nic, @"^(\d{9}[VvXx]|\d{12})$"))
                {
                    MessageBox.Show("NIC format is invalid.\n\nAccepted formats:\n- Old: 9 digits + V (e.g., 123456789V)\n- New: 12 digits (e.g., 200012345678)", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_NIC.Focus();
                    return false;
                }

                if (nic.Length > 50)
                {
                    MessageBox.Show("NIC cannot exceed 50 characters.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_NIC.Focus();
                    return false;
                }
            }

            // Validate Contact No (if provided)
            if (!string.IsNullOrWhiteSpace(txt_ContactNo.Text))
            {
                if (!int.TryParse(txt_ContactNo.Text.Trim(), out int contactNo))
                {
                    MessageBox.Show("Contact Number must be a valid number.\n\nPlease enter only digits.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ContactNo.Focus();
                    return false;
                }

                string contactStr = txt_ContactNo.Text.Trim();
                if (contactStr.Length < 9 || contactStr.Length > 10)
                {
                    MessageBox.Show("Contact Number must be 9-10 digits.\n\nExample: 771234567 or 0771234567", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ContactNo.Focus();
                    return false;
                }

                if (contactNo <= 0)
                {
                    MessageBox.Show("Contact Number must be a positive number.\n\nPlease enter a valid contact number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ContactNo.Focus();
                    return false;
                }
            }

            return true;
        }

        private Student CreateStudentFromForm(int regNo)
        {
            Student student = new Student();
            student.RegNo = regNo;
            student.FirstName = txt_FirstName.Text.Trim();
            student.LastName = txt_LastName.Text.Trim();
            student.DateOfBirth = dtp_DOB.Value;
            student.Gender = rad_Male.Checked ? "Male" : "Female";
            student.Address = txt_Address.Text.Trim();
            student.Email = txt_Email.Text.Trim();

            // Parse numeric fields
            int.TryParse(txt_Mobile.Text, out int mobilePhone);
            student.MobilePhone = mobilePhone;

            int.TryParse(txt_HomePhone.Text, out int homePhone);
            student.HomePhone = homePhone;

            student.ParentName = txt_ParentName.Text.Trim();
            student.NIC = txt_NIC.Text.Trim();

            int.TryParse(txt_ContactNo.Text, out int contactNo);
            student.ContactNo = contactNo;

            return student;
        }

        private void ClearForm()
        {
            // LINQ approach - Version 4 characteristic
            cmb_RegNo.SelectedIndex = -1;
            cmb_RegNo.Text = "";
            
            // Clear all textboxes using LINQ
            this.Controls.OfType<GroupBox>().ToList().ForEach(grp => 
                grp.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear())
            );
            
            dtp_DOB.Value = DateTime.Now;
            rad_Male.Checked = false;
            rad_Female.Checked = false;
            cmb_RegNo.Focus();
        }
    }
}
