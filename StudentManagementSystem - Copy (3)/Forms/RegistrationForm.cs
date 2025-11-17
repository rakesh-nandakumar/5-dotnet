using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Data.SqlClient;

namespace StudentManagementSystem.Forms
{
    public partial class RegistrationForm : Form
    {
        // Using DBConnection singleton - Version 3 style
        private ErrorProvider errorProvider = new ErrorProvider();

        // GroupBoxes
        private GroupBox grpRegistration = null!;
        private GroupBox grpBasicDetails = null!;
        private GroupBox grpContactDetails = null!;
        private GroupBox grpParentDetails = null!;

        // Controls
        private Label lblRegNo = null!;
        private ComboBox cmbRegNo = null!;
        private Label lblFirstName = null!;
        private TextBox txtFirstName = null!;
        private Label lblLastName = null!;
        private TextBox txtLastName = null!;
        private Label lblDateOfBirth = null!;
        private DateTimePicker dtpDOB = null!;
        private Label lblGender = null!;
        private RadioButton radMale = null!;
        private RadioButton radFemale = null!;
        private Label lblAddress = null!;
        private TextBox txtAddress = null!;
        private Label lblEmail = null!;
        private TextBox txtEmail = null!;
        private Label lblMobilePhone = null!;
        private TextBox txtMobilePhone = null!;
        private Label lblHomePhone = null!;
        private TextBox txtHomePhone = null!;
        private Label lblParentName = null!;
        private TextBox txtParentName = null!;
        private Label lblNIC = null!;
        private TextBox txtNIC = null!;
        private Label lblContactNo = null!;
        private TextBox txtContactNo = null!;

        // Buttons
        private Button btnRegister = null!;
        private Button btnUpdate = null!;
        private Button btnClear = null!;
        private Button btnDelete = null!;

        // LinkLabels
        private LinkLabel lnkLogout = null!;
        private LinkLabel lnkExit = null!;

        // DBHelper using singleton internally
        private DBHelper dbHelper = new DBHelper();

        public RegistrationForm()
        {
            InitializeComponent();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            LoadRegistrationNumbers();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Student Registration - Skills International";
            this.Size = new Size(900, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.WindowState = FormWindowState.Normal;

            // GroupBox Registration (Main Container)
            grpRegistration = new GroupBox();
            grpRegistration.Text = "Student Registration";
            grpRegistration.Location = new Point(20, 20);
            grpRegistration.Size = new Size(840, 630);
            grpRegistration.Font = new Font("Calibri", 10, FontStyle.Bold);
            this.Controls.Add(grpRegistration);

            // Label & ComboBox Registration Number
            lblRegNo = new Label();
            lblRegNo.Text = "Registration No:";
            lblRegNo.Location = new Point(30, 40);
            lblRegNo.Size = new Size(150, 25);
            lblRegNo.Font = new Font("Calibri", 10);
            grpRegistration.Controls.Add(lblRegNo);

            cmbRegNo = new ComboBox();
            cmbRegNo.Location = new Point(190, 38);
            cmbRegNo.Size = new Size(200, 25);
            cmbRegNo.Font = new Font("Calibri", 10);
            cmbRegNo.SelectedIndexChanged += cmbRegNo_SelectedIndexChanged;
            grpRegistration.Controls.Add(cmbRegNo);

            // GroupBox Basic Details
            grpBasicDetails = new GroupBox();
            grpBasicDetails.Text = "Basic Details";
            grpBasicDetails.Location = new Point(30, 80);
            grpBasicDetails.Size = new Size(780, 180);
            grpBasicDetails.Font = new Font("Calibri", 10, FontStyle.Bold);
            grpRegistration.Controls.Add(grpBasicDetails);

            // First Name
            lblFirstName = new Label();
            lblFirstName.Text = "First Name:";
            lblFirstName.Location = new Point(30, 40);
            lblFirstName.Size = new Size(100, 25);
            lblFirstName.Font = new Font("Calibri", 10);
            grpBasicDetails.Controls.Add(lblFirstName);

            txtFirstName = new TextBox();
            txtFirstName.Location = new Point(160, 38);
            txtFirstName.Size = new Size(200, 25);
            txtFirstName.Font = new Font("Calibri", 10);
            grpBasicDetails.Controls.Add(txtFirstName);

            // Last Name
            lblLastName = new Label();
            lblLastName.Text = "Last Name:";
            lblLastName.Location = new Point(420, 40);
            lblLastName.Size = new Size(100, 25);
            lblLastName.Font = new Font("Calibri", 10);
            grpBasicDetails.Controls.Add(lblLastName);

            txtLastName = new TextBox();
            txtLastName.Location = new Point(550, 38);
            txtLastName.Size = new Size(200, 25);
            txtLastName.Font = new Font("Calibri", 10);
            grpBasicDetails.Controls.Add(txtLastName);

            // Date of Birth
            lblDateOfBirth = new Label();
            lblDateOfBirth.Text = "Date of Birth:";
            lblDateOfBirth.Location = new Point(30, 85);
            lblDateOfBirth.Size = new Size(100, 25);
            lblDateOfBirth.Font = new Font("Calibri", 10);
            grpBasicDetails.Controls.Add(lblDateOfBirth);

            dtpDOB = new DateTimePicker();
            dtpDOB.Location = new Point(160, 83);
            dtpDOB.Size = new Size(200, 25);
            dtpDOB.Font = new Font("Calibri", 10);
            dtpDOB.Format = DateTimePickerFormat.Short;
            grpBasicDetails.Controls.Add(dtpDOB);

            // Gender
            lblGender = new Label();
            lblGender.Text = "Gender:";
            lblGender.Location = new Point(30, 130);
            lblGender.Size = new Size(100, 25);
            lblGender.Font = new Font("Calibri", 10);
            grpBasicDetails.Controls.Add(lblGender);

            radMale = new RadioButton();
            radMale.Text = "Male";
            radMale.Location = new Point(160, 130);
            radMale.Size = new Size(80, 25);
            radMale.Font = new Font("Calibri", 10);
            grpBasicDetails.Controls.Add(radMale);

            radFemale = new RadioButton();
            radFemale.Text = "Female";
            radFemale.Location = new Point(260, 130);
            radFemale.Size = new Size(100, 25);
            radFemale.Font = new Font("Calibri", 10);
            grpBasicDetails.Controls.Add(radFemale);

            // GroupBox Contact Details
            grpContactDetails = new GroupBox();
            grpContactDetails.Text = "Contact Details";
            grpContactDetails.Location = new Point(30, 270);
            grpContactDetails.Size = new Size(780, 180);
            grpContactDetails.Font = new Font("Calibri", 10, FontStyle.Bold);
            grpRegistration.Controls.Add(grpContactDetails);

            // Address
            lblAddress = new Label();
            lblAddress.Text = "Address:";
            lblAddress.Location = new Point(30, 40);
            lblAddress.Size = new Size(100, 25);
            lblAddress.Font = new Font("Calibri", 10);
            grpContactDetails.Controls.Add(lblAddress);

            txtAddress = new TextBox();
            txtAddress.Location = new Point(160, 38);
            txtAddress.Size = new Size(590, 60);
            txtAddress.Multiline = true;
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Font = new Font("Calibri", 10);
            grpContactDetails.Controls.Add(txtAddress);

            // Email
            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(30, 115);
            lblEmail.Size = new Size(100, 25);
            lblEmail.Font = new Font("Calibri", 10);
            grpContactDetails.Controls.Add(lblEmail);

            txtEmail = new TextBox();
            txtEmail.Location = new Point(160, 113);
            txtEmail.Size = new Size(200, 25);
            txtEmail.Font = new Font("Calibri", 10);
            grpContactDetails.Controls.Add(txtEmail);

            // Mobile Phone
            lblMobilePhone = new Label();
            lblMobilePhone.Text = "Mobile Phone:";
            lblMobilePhone.Location = new Point(420, 115);
            lblMobilePhone.Size = new Size(120, 25);
            lblMobilePhone.Font = new Font("Calibri", 10);
            grpContactDetails.Controls.Add(lblMobilePhone);

            txtMobilePhone = new TextBox();
            txtMobilePhone.Location = new Point(550, 113);
            txtMobilePhone.Size = new Size(200, 25);
            txtMobilePhone.Font = new Font("Calibri", 10);
            grpContactDetails.Controls.Add(txtMobilePhone);

            // Home Phone
            lblHomePhone = new Label();
            lblHomePhone.Text = "Home Phone:";
            lblHomePhone.Location = new Point(30, 145);
            lblHomePhone.Size = new Size(120, 25);
            lblHomePhone.Font = new Font("Calibri", 10);
            grpContactDetails.Controls.Add(lblHomePhone);

            txtHomePhone = new TextBox();
            txtHomePhone.Location = new Point(160, 143);
            txtHomePhone.Size = new Size(200, 25);
            txtHomePhone.Font = new Font("Calibri", 10);
            grpContactDetails.Controls.Add(txtHomePhone);

            // GroupBox Parent Details
            grpParentDetails = new GroupBox();
            grpParentDetails.Text = "Parent Details";
            grpParentDetails.Location = new Point(30, 460);
            grpParentDetails.Size = new Size(780, 100);
            grpParentDetails.Font = new Font("Calibri", 10, FontStyle.Bold);
            grpRegistration.Controls.Add(grpParentDetails);

            // Parent Name
            lblParentName = new Label();
            lblParentName.Text = "Parent Name:";
            lblParentName.Location = new Point(30, 35);
            lblParentName.Size = new Size(120, 25);
            lblParentName.Font = new Font("Calibri", 10);
            grpParentDetails.Controls.Add(lblParentName);

            txtParentName = new TextBox();
            txtParentName.Location = new Point(160, 33);
            txtParentName.Size = new Size(200, 25);
            txtParentName.Font = new Font("Calibri", 10);
            grpParentDetails.Controls.Add(txtParentName);

            // NIC
            lblNIC = new Label();
            lblNIC.Text = "NIC:";
            lblNIC.Location = new Point(420, 35);
            lblNIC.Size = new Size(120, 25);
            lblNIC.Font = new Font("Calibri", 10);
            grpParentDetails.Controls.Add(lblNIC);

            txtNIC = new TextBox();
            txtNIC.Location = new Point(550, 33);
            txtNIC.Size = new Size(200, 25);
            txtNIC.Font = new Font("Calibri", 10);
            grpParentDetails.Controls.Add(txtNIC);

            // Contact No
            lblContactNo = new Label();
            lblContactNo.Text = "Contact No:";
            lblContactNo.Location = new Point(30, 65);
            lblContactNo.Size = new Size(120, 25);
            lblContactNo.Font = new Font("Calibri", 10);
            grpParentDetails.Controls.Add(lblContactNo);

            txtContactNo = new TextBox();
            txtContactNo.Location = new Point(160, 63);
            txtContactNo.Size = new Size(200, 25);
            txtContactNo.Font = new Font("Calibri", 10);
            grpParentDetails.Controls.Add(txtContactNo);

            // Buttons - Register
            btnRegister = new Button();
            btnRegister.Text = "Register";
            btnRegister.Location = new Point(30, 575);
            btnRegister.Size = new Size(120, 35);
            btnRegister.BackColor = Color.FromArgb(40, 167, 69);
            btnRegister.ForeColor = Color.White;
            btnRegister.Font = new Font("Calibri", 10, FontStyle.Bold);
            btnRegister.FlatStyle = FlatStyle.Popup;
            btnRegister.Click += btnRegister_Click;
            grpRegistration.Controls.Add(btnRegister);

            // Button Update
            btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Location = new Point(170, 575);
            btnUpdate.Size = new Size(120, 35);
            btnUpdate.BackColor = Color.FromArgb(0, 102, 204);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Font = new Font("Calibri", 10, FontStyle.Bold);
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Click += btnUpdate_Click;
            grpRegistration.Controls.Add(btnUpdate);

            // Button Clear
            btnClear = new Button();
            btnClear.Text = "Clear";
            btnClear.Location = new Point(310, 575);
            btnClear.Size = new Size(120, 35);
            btnClear.BackColor = Color.FromArgb(255, 153, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Font = new Font("Calibri", 10, FontStyle.Bold);
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Click += btnClear_Click;
            grpRegistration.Controls.Add(btnClear);

            // Button Delete
            btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Location = new Point(450, 575);
            btnDelete.Size = new Size(120, 35);
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.ForeColor = Color.White;
            btnDelete.Font = new Font("Calibri", 10, FontStyle.Bold);
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Click += btnDelete_Click;
            grpRegistration.Controls.Add(btnDelete);

            // LinkLabel Logout
            lnkLogout = new LinkLabel();
            lnkLogout.Text = "Logout";
            lnkLogout.Location = new Point(720, 665);
            lnkLogout.Size = new Size(60, 20);
            lnkLogout.Font = new Font("Calibri", 10);
            lnkLogout.LinkClicked += lnkLogout_LinkClicked;
            this.Controls.Add(lnkLogout);

            // LinkLabel Exit
            lnkExit = new LinkLabel();
            lnkExit.Text = "Exit";
            lnkExit.Location = new Point(810, 665);
            lnkExit.Size = new Size(40, 20);
            lnkExit.Font = new Font("Calibri", 10);
            lnkExit.LinkClicked += lnkExit_LinkClicked;
            this.Controls.Add(lnkExit);

            this.ResumeLayout();
        }

        private void LoadRegistrationNumbers()
        {
            cmbRegNo.Items.Clear();
            List<int> regNumbers = dbHelper.GetAllRegNumbers();
            foreach (int regNo in regNumbers)
            {
                cmbRegNo.Items.Add(regNo);
            }
        }

        private void cmbRegNo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbRegNo.SelectedItem != null)
            {
                int regNo = (int)cmbRegNo.SelectedItem;
                Student? student = dbHelper.GetStudentByRegNo(regNo);

                if (student != null)
                {
                    txtFirstName.Text = student.FirstName;
                    txtLastName.Text = student.LastName;
                    dtpDOB.Value = student.DateOfBirth;
                    
                    if (student.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                        radMale.Checked = true;
                    else if (student.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                        radFemale.Checked = true;

                    txtAddress.Text = student.Address;
                    txtEmail.Text = student.Email;
                    txtMobilePhone.Text = student.MobilePhone.ToString();
                    txtHomePhone.Text = student.HomePhone.ToString();
                    txtParentName.Text = student.ParentName;
                    txtNIC.Text = student.NIC;
                    txtContactNo.Text = student.ContactNo.ToString();
                }
            }
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            // Validate required fields
            if (!ValidateInputs(true))
                return;

            // Get registration number
            if (!int.TryParse(cmbRegNo.Text, out int regNo))
            {
                MessageBox.Show("Please enter a valid Registration Number", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRegNo.Focus();
                return;
            }

            // Check if registration number already exists
            if (dbHelper.RegNoExists(regNo))
            {
                MessageBox.Show("This Registration Number already exists. Please use Update instead.", 
                    "Duplicate Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create student object
            Student student = CreateStudentFromForm(regNo);

            // Insert into database
            if (dbHelper.InsertStudent(student))
            {
                MessageBox.Show("New student added to database", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegistrationNumbers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add record", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            // Validate registration number is selected
            if (cmbRegNo.SelectedItem == null)
            {
                MessageBox.Show("Please select a Registration Number to update", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate required fields
            if (!ValidateInputs(false))
                return;

            int regNo = (int)cmbRegNo.SelectedItem;

            // Create student object
            Student student = CreateStudentFromForm(regNo);

            // Update in database
            if (dbHelper.UpdateStudent(student))
            {
                MessageBox.Show("Student data updated", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegistrationNumbers();
            }
            else
            {
                MessageBox.Show("Failed to update record", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            // Validate registration number is selected
            if (cmbRegNo.SelectedItem == null)
            {
                MessageBox.Show("Please select a Registration Number to delete", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this record?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int regNo = (int)cmbRegNo.SelectedItem;

                if (dbHelper.DeleteStudent(regNo))
                {
                    MessageBox.Show("Student record removed", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRegistrationNumbers();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete record", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void lnkLogout_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void lnkExit_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
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
            if (isNewRegistration && string.IsNullOrWhiteSpace(cmbRegNo.Text))
            {
                MessageBox.Show("Registration Number is required.\n\nPlease enter a valid registration number.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRegNo.Focus();
                return false;
            }

            // Validate Registration Number format (must be numeric)
            if (isNewRegistration)
            {
                if (!int.TryParse(cmbRegNo.Text, out int regNo))
                {
                    MessageBox.Show("Registration Number must be a valid number.\n\nExample: 1001, 1002, etc.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRegNo.Focus();
                    return false;
                }

                if (regNo <= 0)
                {
                    MessageBox.Show("Registration Number must be a positive number.\n\nPlease enter a number greater than 0.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRegNo.Focus();
                    return false;
                }
            }

            // Validate First Name
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.\n\nPlease enter the student's first name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            // Validate First Name format (only letters and spaces)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            // Validate First Name length
            if (txtFirstName.Text.Trim().Length < 2)
            {
                MessageBox.Show("First Name must be at least 2 characters long.\n\nPlease enter a valid first name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (txtFirstName.Text.Trim().Length > 50)
            {
                MessageBox.Show("First Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.\n\nPlease enter the student's last name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            // Validate Last Name format (only letters and spaces)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtLastName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            // Validate Last Name length
            if (txtLastName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Last Name must be at least 2 characters long.\n\nPlease enter a valid last name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (txtLastName.Text.Trim().Length > 50)
            {
                MessageBox.Show("Last Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            // Validate Date of Birth
            DateTime today = DateTime.Today;
            DateTime minDate = today.AddYears(-100); // Maximum age 100 years
            DateTime maxDate = today.AddYears(-5);   // Minimum age 5 years

            if (dtpDOB.Value > today)
            {
                MessageBox.Show("Date of Birth cannot be in the future.\n\nPlease select a valid date.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDOB.Focus();
                return false;
            }

            if (dtpDOB.Value < minDate)
            {
                MessageBox.Show("Date of Birth is too far in the past.\n\nPlease select a valid date (within last 100 years).", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDOB.Focus();
                return false;
            }

            if (dtpDOB.Value > maxDate)
            {
                MessageBox.Show("Student must be at least 5 years old.\n\nPlease select an earlier date of birth.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDOB.Focus();
                return false;
            }

            // Validate Gender
            if (!radMale.Checked && !radFemale.Checked)
            {
                MessageBox.Show("Gender is required.\n\nPlease select either Male or Female.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                radMale.Focus();
                return false;
            }

            // Validate Email (if provided)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                string email = txtEmail.Text.Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, 
                    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    MessageBox.Show("Please enter a valid email address.\n\nExample: student@example.com", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }

                if (email.Length > 50)
                {
                    MessageBox.Show("Email cannot exceed 50 characters.\n\nPlease enter a shorter email address.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Validate Mobile Phone (if provided)
            if (!string.IsNullOrWhiteSpace(txtMobilePhone.Text))
            {
                if (!int.TryParse(txtMobilePhone.Text.Trim(), out int mobilePhone))
                {
                    MessageBox.Show("Mobile Phone must be a valid number.\n\nPlease enter only digits (e.g., 771234567).", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobilePhone.Focus();
                    return false;
                }

                string mobileStr = txtMobilePhone.Text.Trim();
                if (mobileStr.Length < 9 || mobileStr.Length > 10)
                {
                    MessageBox.Show("Mobile Phone must be 9-10 digits.\n\nExample: 771234567 or 0771234567", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobilePhone.Focus();
                    return false;
                }

                if (mobilePhone <= 0)
                {
                    MessageBox.Show("Mobile Phone must be a positive number.\n\nPlease enter a valid phone number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobilePhone.Focus();
                    return false;
                }
            }

            // Validate Home Phone (if provided)
            if (!string.IsNullOrWhiteSpace(txtHomePhone.Text))
            {
                if (!int.TryParse(txtHomePhone.Text.Trim(), out int homePhone))
                {
                    MessageBox.Show("Home Phone must be a valid number.\n\nPlease enter only digits (e.g., 112345678).", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHomePhone.Focus();
                    return false;
                }

                string homeStr = txtHomePhone.Text.Trim();
                if (homeStr.Length < 9 || homeStr.Length > 10)
                {
                    MessageBox.Show("Home Phone must be 9-10 digits.\n\nExample: 112345678 or 0112345678", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHomePhone.Focus();
                    return false;
                }

                if (homePhone <= 0)
                {
                    MessageBox.Show("Home Phone must be a positive number.\n\nPlease enter a valid phone number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHomePhone.Focus();
                    return false;
                }
            }

            // Validate Address length (if provided)
            if (!string.IsNullOrWhiteSpace(txtAddress.Text) && txtAddress.Text.Trim().Length > 50)
            {
                MessageBox.Show("Address cannot exceed 50 characters.\n\nPlease enter a shorter address.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            // Validate Parent Name (if provided)
            if (!string.IsNullOrWhiteSpace(txtParentName.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtParentName.Text.Trim(), @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Parent Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtParentName.Focus();
                    return false;
                }

                if (txtParentName.Text.Trim().Length < 2)
                {
                    MessageBox.Show("Parent Name must be at least 2 characters long.\n\nPlease enter a valid name.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtParentName.Focus();
                    return false;
                }

                if (txtParentName.Text.Trim().Length > 50)
                {
                    MessageBox.Show("Parent Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtParentName.Focus();
                    return false;
                }
            }

            // Validate NIC (if provided)
            if (!string.IsNullOrWhiteSpace(txtNIC.Text))
            {
                string nic = txtNIC.Text.Trim();
                
                // NIC format: 12 digits or 9 digits + V (old format)
                if (!System.Text.RegularExpressions.Regex.IsMatch(nic, @"^(\d{9}[VvXx]|\d{12})$"))
                {
                    MessageBox.Show("NIC format is invalid.\n\nAccepted formats:\n- Old: 9 digits + V (e.g., 123456789V)\n- New: 12 digits (e.g., 200012345678)", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNIC.Focus();
                    return false;
                }

                if (nic.Length > 50)
                {
                    MessageBox.Show("NIC cannot exceed 50 characters.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNIC.Focus();
                    return false;
                }
            }

            // Validate Contact No (if provided)
            if (!string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                if (!int.TryParse(txtContactNo.Text.Trim(), out int contactNo))
                {
                    MessageBox.Show("Contact Number must be a valid number.\n\nPlease enter only digits.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactNo.Focus();
                    return false;
                }

                string contactStr = txtContactNo.Text.Trim();
                if (contactStr.Length < 9 || contactStr.Length > 10)
                {
                    MessageBox.Show("Contact Number must be 9-10 digits.\n\nExample: 771234567 or 0771234567", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactNo.Focus();
                    return false;
                }

                if (contactNo <= 0)
                {
                    MessageBox.Show("Contact Number must be a positive number.\n\nPlease enter a valid contact number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactNo.Focus();
                    return false;
                }
            }

            return true;
        }

        private Student CreateStudentFromForm(int regNo)
        {
            Student student = new Student();
            student.RegNo = regNo;
            student.FirstName = txtFirstName.Text.Trim();
            student.LastName = txtLastName.Text.Trim();
            student.DateOfBirth = dtpDOB.Value;
            student.Gender = radMale.Checked ? "Male" : "Female";
            student.Address = txtAddress.Text.Trim();
            student.Email = txtEmail.Text.Trim();

            // Parse numeric fields
            int.TryParse(txtMobilePhone.Text, out int mobilePhone);
            student.MobilePhone = mobilePhone;

            int.TryParse(txtHomePhone.Text, out int homePhone);
            student.HomePhone = homePhone;

            student.ParentName = txtParentName.Text.Trim();
            student.NIC = txtNIC.Text.Trim();

            int.TryParse(txtContactNo.Text, out int contactNo);
            student.ContactNo = contactNo;

            return student;
        }

        // Loop through controls to clear - Version 3 style
        private void ClearForm()
        {
            cmbRegNo.SelectedIndex = -1;
            cmbRegNo.Text = "";
            
            // Loop through controls in basic details
            foreach (Control ctrl in grpBasicDetails.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
            }
            
            // Loop through controls in contact details
            foreach (Control ctrl in grpContactDetails.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
            }
            
            // Loop through controls in parent details
            foreach (Control ctrl in grpParentDetails.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
            }
            
            dtpDOB.Value = DateTime.Now;
            radMale.Checked = false;
            radFemale.Checked = false;
            cmbRegNo.Focus();
        }
    }
}
