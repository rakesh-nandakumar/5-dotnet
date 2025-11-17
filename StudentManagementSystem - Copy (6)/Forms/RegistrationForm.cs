using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Forms
{
    public partial class RegistrationForm : Form
    {
        private DatabaseHelper dbHelper;

        // GroupBoxes
        private GroupBox groupBoxRegistration = null!;
        private GroupBox groupBoxBasicDetails = null!;
        private GroupBox groupBoxContactDetails = null!;
        private GroupBox groupBoxParentDetails = null!;

        // Controls
        private Label labelRegNo = null!;
        private ComboBox comboBoxRegNo = null!;
        private Label labelFirstName = null!;
        private TextBox textBoxFirstName = null!;
        private Label labelLastName = null!;
        private TextBox textBoxLastName = null!;
        private Label labelDateOfBirth = null!;
        private DateTimePicker dateTimePickerDOB = null!;
        private Label labelGender = null!;
        private RadioButton radioButtonMale = null!;
        private RadioButton radioButtonFemale = null!;
        private Label labelAddress = null!;
        private TextBox textBoxAddress = null!;
        private Label labelEmail = null!;
        private TextBox textBoxEmail = null!;
        private Label labelMobilePhone = null!;
        private TextBox textBoxMobilePhone = null!;
        private Label labelHomePhone = null!;
        private TextBox textBoxHomePhone = null!;
        private Label labelParentName = null!;
        private TextBox textBoxParentName = null!;
        private Label labelNIC = null!;
        private TextBox textBoxNIC = null!;
        private Label labelContactNo = null!;
        private TextBox textBoxContactNo = null!;

        // Buttons
        private Button buttonRegister = null!;
        private Button buttonUpdate = null!;
        private Button buttonClear = null!;
        private Button buttonDelete = null!;

        // LinkLabels
        private LinkLabel linkLabelLogout = null!;
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
            groupBoxRegistration = new GroupBox();
            groupBoxRegistration.Text = "Student Registration";
            groupBoxRegistration.Location = new Point(20, 20);
            groupBoxRegistration.Size = new Size(840, 630);
            groupBoxRegistration.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Controls.Add(groupBoxRegistration);

            // Label & ComboBox Registration Number
            labelRegNo = new Label();
            labelRegNo.Text = "Registration No:";
            labelRegNo.Location = new Point(30, 40);
            labelRegNo.Size = new Size(150, 25);
            labelRegNo.Font = new Font("Arial", 10);
            groupBoxRegistration.Controls.Add(labelRegNo);

            comboBoxRegNo = new ComboBox();
            comboBoxRegNo.Location = new Point(190, 38);
            comboBoxRegNo.Size = new Size(200, 25);
            comboBoxRegNo.Font = new Font("Arial", 10);
            comboBoxRegNo.SelectedIndexChanged += ComboBoxRegNo_SelectedIndexChanged;
            groupBoxRegistration.Controls.Add(comboBoxRegNo);

            // GroupBox Basic Details
            groupBoxBasicDetails = new GroupBox();
            groupBoxBasicDetails.Text = "Basic Details";
            groupBoxBasicDetails.Location = new Point(30, 80);
            groupBoxBasicDetails.Size = new Size(780, 180);
            groupBoxBasicDetails.Font = new Font("Arial", 10, FontStyle.Bold);
            groupBoxRegistration.Controls.Add(groupBoxBasicDetails);

            // First Name
            labelFirstName = new Label();
            labelFirstName.Text = "First Name:";
            labelFirstName.Location = new Point(30, 40);
            labelFirstName.Size = new Size(100, 25);
            labelFirstName.Font = new Font("Arial", 10);
            groupBoxBasicDetails.Controls.Add(labelFirstName);

            textBoxFirstName = new TextBox();
            textBoxFirstName.Location = new Point(160, 38);
            textBoxFirstName.Size = new Size(200, 25);
            textBoxFirstName.Font = new Font("Arial", 10);
            groupBoxBasicDetails.Controls.Add(textBoxFirstName);

            // Last Name
            labelLastName = new Label();
            labelLastName.Text = "Last Name:";
            labelLastName.Location = new Point(420, 40);
            labelLastName.Size = new Size(100, 25);
            labelLastName.Font = new Font("Arial", 10);
            groupBoxBasicDetails.Controls.Add(labelLastName);

            textBoxLastName = new TextBox();
            textBoxLastName.Location = new Point(550, 38);
            textBoxLastName.Size = new Size(200, 25);
            textBoxLastName.Font = new Font("Arial", 10);
            groupBoxBasicDetails.Controls.Add(textBoxLastName);

            // Date of Birth
            labelDateOfBirth = new Label();
            labelDateOfBirth.Text = "Date of Birth:";
            labelDateOfBirth.Location = new Point(30, 85);
            labelDateOfBirth.Size = new Size(100, 25);
            labelDateOfBirth.Font = new Font("Arial", 10);
            groupBoxBasicDetails.Controls.Add(labelDateOfBirth);

            dateTimePickerDOB = new DateTimePicker();
            dateTimePickerDOB.Location = new Point(160, 83);
            dateTimePickerDOB.Size = new Size(200, 25);
            dateTimePickerDOB.Font = new Font("Arial", 10);
            dateTimePickerDOB.Format = DateTimePickerFormat.Short;
            groupBoxBasicDetails.Controls.Add(dateTimePickerDOB);

            // Gender
            labelGender = new Label();
            labelGender.Text = "Gender:";
            labelGender.Location = new Point(30, 130);
            labelGender.Size = new Size(100, 25);
            labelGender.Font = new Font("Arial", 10);
            groupBoxBasicDetails.Controls.Add(labelGender);

            radioButtonMale = new RadioButton();
            radioButtonMale.Text = "Male";
            radioButtonMale.Location = new Point(160, 130);
            radioButtonMale.Size = new Size(80, 25);
            radioButtonMale.Font = new Font("Arial", 10);
            groupBoxBasicDetails.Controls.Add(radioButtonMale);

            radioButtonFemale = new RadioButton();
            radioButtonFemale.Text = "Female";
            radioButtonFemale.Location = new Point(260, 130);
            radioButtonFemale.Size = new Size(100, 25);
            radioButtonFemale.Font = new Font("Arial", 10);
            groupBoxBasicDetails.Controls.Add(radioButtonFemale);

            // GroupBox Contact Details
            groupBoxContactDetails = new GroupBox();
            groupBoxContactDetails.Text = "Contact Details";
            groupBoxContactDetails.Location = new Point(30, 270);
            groupBoxContactDetails.Size = new Size(780, 180);
            groupBoxContactDetails.Font = new Font("Arial", 10, FontStyle.Bold);
            groupBoxRegistration.Controls.Add(groupBoxContactDetails);

            // Address
            labelAddress = new Label();
            labelAddress.Text = "Address:";
            labelAddress.Location = new Point(30, 40);
            labelAddress.Size = new Size(100, 25);
            labelAddress.Font = new Font("Arial", 10);
            groupBoxContactDetails.Controls.Add(labelAddress);

            textBoxAddress = new TextBox();
            textBoxAddress.Location = new Point(160, 38);
            textBoxAddress.Size = new Size(590, 60);
            textBoxAddress.Multiline = true;
            textBoxAddress.ScrollBars = ScrollBars.Vertical;
            textBoxAddress.Font = new Font("Arial", 10);
            groupBoxContactDetails.Controls.Add(textBoxAddress);

            // Email
            labelEmail = new Label();
            labelEmail.Text = "Email:";
            labelEmail.Location = new Point(30, 115);
            labelEmail.Size = new Size(100, 25);
            labelEmail.Font = new Font("Arial", 10);
            groupBoxContactDetails.Controls.Add(labelEmail);

            textBoxEmail = new TextBox();
            textBoxEmail.Location = new Point(160, 113);
            textBoxEmail.Size = new Size(200, 25);
            textBoxEmail.Font = new Font("Arial", 10);
            groupBoxContactDetails.Controls.Add(textBoxEmail);

            // Mobile Phone
            labelMobilePhone = new Label();
            labelMobilePhone.Text = "Mobile Phone:";
            labelMobilePhone.Location = new Point(420, 115);
            labelMobilePhone.Size = new Size(120, 25);
            labelMobilePhone.Font = new Font("Arial", 10);
            groupBoxContactDetails.Controls.Add(labelMobilePhone);

            textBoxMobilePhone = new TextBox();
            textBoxMobilePhone.Location = new Point(550, 113);
            textBoxMobilePhone.Size = new Size(200, 25);
            textBoxMobilePhone.Font = new Font("Arial", 10);
            groupBoxContactDetails.Controls.Add(textBoxMobilePhone);

            // Home Phone
            labelHomePhone = new Label();
            labelHomePhone.Text = "Home Phone:";
            labelHomePhone.Location = new Point(30, 145);
            labelHomePhone.Size = new Size(120, 25);
            labelHomePhone.Font = new Font("Arial", 10);
            groupBoxContactDetails.Controls.Add(labelHomePhone);

            textBoxHomePhone = new TextBox();
            textBoxHomePhone.Location = new Point(160, 143);
            textBoxHomePhone.Size = new Size(200, 25);
            textBoxHomePhone.Font = new Font("Arial", 10);
            groupBoxContactDetails.Controls.Add(textBoxHomePhone);

            // GroupBox Parent Details
            groupBoxParentDetails = new GroupBox();
            groupBoxParentDetails.Text = "Parent Details";
            groupBoxParentDetails.Location = new Point(30, 460);
            groupBoxParentDetails.Size = new Size(780, 100);
            groupBoxParentDetails.Font = new Font("Arial", 10, FontStyle.Bold);
            groupBoxRegistration.Controls.Add(groupBoxParentDetails);

            // Parent Name
            labelParentName = new Label();
            labelParentName.Text = "Parent Name:";
            labelParentName.Location = new Point(30, 35);
            labelParentName.Size = new Size(120, 25);
            labelParentName.Font = new Font("Arial", 10);
            groupBoxParentDetails.Controls.Add(labelParentName);

            textBoxParentName = new TextBox();
            textBoxParentName.Location = new Point(160, 33);
            textBoxParentName.Size = new Size(200, 25);
            textBoxParentName.Font = new Font("Arial", 10);
            groupBoxParentDetails.Controls.Add(textBoxParentName);

            // NIC
            labelNIC = new Label();
            labelNIC.Text = "NIC:";
            labelNIC.Location = new Point(420, 35);
            labelNIC.Size = new Size(120, 25);
            labelNIC.Font = new Font("Arial", 10);
            groupBoxParentDetails.Controls.Add(labelNIC);

            textBoxNIC = new TextBox();
            textBoxNIC.Location = new Point(550, 33);
            textBoxNIC.Size = new Size(200, 25);
            textBoxNIC.Font = new Font("Arial", 10);
            groupBoxParentDetails.Controls.Add(textBoxNIC);

            // Contact No
            labelContactNo = new Label();
            labelContactNo.Text = "Contact No:";
            labelContactNo.Location = new Point(30, 65);
            labelContactNo.Size = new Size(120, 25);
            labelContactNo.Font = new Font("Arial", 10);
            groupBoxParentDetails.Controls.Add(labelContactNo);

            textBoxContactNo = new TextBox();
            textBoxContactNo.Location = new Point(160, 63);
            textBoxContactNo.Size = new Size(200, 25);
            textBoxContactNo.Font = new Font("Arial", 10);
            groupBoxParentDetails.Controls.Add(textBoxContactNo);

            // Buttons - Register
            buttonRegister = new Button();
            buttonRegister.Text = "Register";
            buttonRegister.Location = new Point(30, 575);
            buttonRegister.Size = new Size(120, 35);
            buttonRegister.BackColor = Color.FromArgb(40, 167, 69);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.Font = new Font("Arial", 10, FontStyle.Bold);
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Click += ButtonRegister_Click;
            groupBoxRegistration.Controls.Add(buttonRegister);

            // Button Update
            buttonUpdate = new Button();
            buttonUpdate.Text = "Update";
            buttonUpdate.Location = new Point(170, 575);
            buttonUpdate.Size = new Size(120, 35);
            buttonUpdate.BackColor = Color.FromArgb(0, 102, 204);
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Font = new Font("Arial", 10, FontStyle.Bold);
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.Click += ButtonUpdate_Click;
            groupBoxRegistration.Controls.Add(buttonUpdate);

            // Button Clear
            buttonClear = new Button();
            buttonClear.Text = "Clear";
            buttonClear.Location = new Point(310, 575);
            buttonClear.Size = new Size(120, 35);
            buttonClear.BackColor = Color.FromArgb(255, 153, 0);
            buttonClear.ForeColor = Color.White;
            buttonClear.Font = new Font("Arial", 10, FontStyle.Bold);
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Click += ButtonClear_Click;
            groupBoxRegistration.Controls.Add(buttonClear);

            // Button Delete
            buttonDelete = new Button();
            buttonDelete.Text = "Delete";
            buttonDelete.Location = new Point(450, 575);
            buttonDelete.Size = new Size(120, 35);
            buttonDelete.BackColor = Color.FromArgb(220, 53, 69);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Font = new Font("Arial", 10, FontStyle.Bold);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Click += ButtonDelete_Click;
            groupBoxRegistration.Controls.Add(buttonDelete);

            // LinkLabel Logout
            linkLabelLogout = new LinkLabel();
            linkLabelLogout.Text = "Logout";
            linkLabelLogout.Location = new Point(720, 665);
            linkLabelLogout.Size = new Size(60, 20);
            linkLabelLogout.Font = new Font("Arial", 10);
            linkLabelLogout.LinkClicked += LinkLabelLogout_LinkClicked;
            this.Controls.Add(linkLabelLogout);

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
            comboBoxRegNo.Items.Clear();
            List<int> regNumbers = dbHelper.GetAllRegNumbers();
            foreach (int regNo in regNumbers)
            {
                comboBoxRegNo.Items.Add(regNo);
            }
        }

        private void ComboBoxRegNo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxRegNo.SelectedItem != null)
            {
                int regNo = (int)comboBoxRegNo.SelectedItem;
                Student? student = dbHelper.GetStudentByRegNo(regNo);

                if (student != null)
                {
                    textBoxFirstName.Text = student.FirstName;
                    textBoxLastName.Text = student.LastName;
                    dateTimePickerDOB.Value = student.DateOfBirth;
                    
                    if (student.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                        radioButtonMale.Checked = true;
                    else if (student.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                        radioButtonFemale.Checked = true;

                    textBoxAddress.Text = student.Address;
                    textBoxEmail.Text = student.Email;
                    textBoxMobilePhone.Text = student.MobilePhone.ToString();
                    textBoxHomePhone.Text = student.HomePhone.ToString();
                    textBoxParentName.Text = student.ParentName;
                    textBoxNIC.Text = student.NIC;
                    textBoxContactNo.Text = student.ContactNo.ToString();
                }
            }
        }

        private void ButtonRegister_Click(object? sender, EventArgs e)
        {
            // Validate required fields
            if (!ValidateInputs(true))
                return;

            // Get registration number
            if (!int.TryParse(comboBoxRegNo.Text, out int regNo))
            {
                MessageBox.Show("Please enter a valid Registration Number", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxRegNo.Focus();
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
                MessageBox.Show("Record Added Successfully", "Success", 
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

        private void ButtonUpdate_Click(object? sender, EventArgs e)
        {
            // Validate registration number is selected
            if (comboBoxRegNo.SelectedItem == null)
            {
                MessageBox.Show("Please select a Registration Number to update", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate required fields
            if (!ValidateInputs(false))
                return;

            int regNo = (int)comboBoxRegNo.SelectedItem;

            // Create student object
            Student student = CreateStudentFromForm(regNo);

            // Update in database
            if (dbHelper.UpdateStudent(student))
            {
                MessageBox.Show("Record Updated Successfully", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegistrationNumbers();
            }
            else
            {
                MessageBox.Show("Failed to update record", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDelete_Click(object? sender, EventArgs e)
        {
            // Validate registration number is selected
            if (comboBoxRegNo.SelectedItem == null)
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
                int regNo = (int)comboBoxRegNo.SelectedItem;

                if (dbHelper.DeleteStudent(regNo))
                {
                    MessageBox.Show("Record Deleted Successfully", "Success", 
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
            if (isNewRegistration && string.IsNullOrWhiteSpace(comboBoxRegNo.Text))
            {
                MessageBox.Show("Registration Number is required.\n\nPlease enter a valid registration number.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxRegNo.Focus();
                return false;
            }

            // Validate Registration Number format (must be numeric)
            if (isNewRegistration)
            {
                if (!int.TryParse(comboBoxRegNo.Text, out int regNo))
                {
                    MessageBox.Show("Registration Number must be a valid number.\n\nExample: 1001, 1002, etc.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxRegNo.Focus();
                    return false;
                }

                if (regNo <= 0)
                {
                    MessageBox.Show("Registration Number must be a positive number.\n\nPlease enter a number greater than 0.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxRegNo.Focus();
                    return false;
                }
            }

            // Validate First Name
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("First Name is required.\n\nPlease enter the student's first name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Focus();
                return false;
            }

            // Validate First Name format (only letters and spaces)
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxFirstName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Focus();
                return false;
            }

            // Validate First Name length
            if (textBoxFirstName.Text.Trim().Length < 2)
            {
                MessageBox.Show("First Name must be at least 2 characters long.\n\nPlease enter a valid first name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Focus();
                return false;
            }

            if (textBoxFirstName.Text.Trim().Length > 50)
            {
                MessageBox.Show("First Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Focus();
                return false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Last Name is required.\n\nPlease enter the student's last name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Focus();
                return false;
            }

            // Validate Last Name format (only letters and spaces)
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxLastName.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Focus();
                return false;
            }

            // Validate Last Name length
            if (textBoxLastName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Last Name must be at least 2 characters long.\n\nPlease enter a valid last name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Focus();
                return false;
            }

            if (textBoxLastName.Text.Trim().Length > 50)
            {
                MessageBox.Show("Last Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Focus();
                return false;
            }

            // Validate Date of Birth
            DateTime today = DateTime.Today;
            DateTime minDate = today.AddYears(-100); // Maximum age 100 years
            DateTime maxDate = today.AddYears(-5);   // Minimum age 5 years

            if (dateTimePickerDOB.Value > today)
            {
                MessageBox.Show("Date of Birth cannot be in the future.\n\nPlease select a valid date.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerDOB.Focus();
                return false;
            }

            if (dateTimePickerDOB.Value < minDate)
            {
                MessageBox.Show("Date of Birth is too far in the past.\n\nPlease select a valid date (within last 100 years).", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerDOB.Focus();
                return false;
            }

            if (dateTimePickerDOB.Value > maxDate)
            {
                MessageBox.Show("Student must be at least 5 years old.\n\nPlease select an earlier date of birth.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerDOB.Focus();
                return false;
            }

            // Validate Gender
            if (!radioButtonMale.Checked && !radioButtonFemale.Checked)
            {
                MessageBox.Show("Gender is required.\n\nPlease select either Male or Female.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                radioButtonMale.Focus();
                return false;
            }

            // Validate Email (if provided)
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                string email = textBoxEmail.Text.Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, 
                    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    MessageBox.Show("Please enter a valid email address.\n\nExample: student@example.com", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEmail.Focus();
                    return false;
                }

                if (email.Length > 50)
                {
                    MessageBox.Show("Email cannot exceed 50 characters.\n\nPlease enter a shorter email address.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEmail.Focus();
                    return false;
                }
            }

            // Validate Mobile Phone (if provided)
            if (!string.IsNullOrWhiteSpace(textBoxMobilePhone.Text))
            {
                if (!int.TryParse(textBoxMobilePhone.Text.Trim(), out int mobilePhone))
                {
                    MessageBox.Show("Mobile Phone must be a valid number.\n\nPlease enter only digits (e.g., 771234567).", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMobilePhone.Focus();
                    return false;
                }

                string mobileStr = textBoxMobilePhone.Text.Trim();
                if (mobileStr.Length < 9 || mobileStr.Length > 10)
                {
                    MessageBox.Show("Mobile Phone must be 9-10 digits.\n\nExample: 771234567 or 0771234567", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMobilePhone.Focus();
                    return false;
                }

                if (mobilePhone <= 0)
                {
                    MessageBox.Show("Mobile Phone must be a positive number.\n\nPlease enter a valid phone number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxMobilePhone.Focus();
                    return false;
                }
            }

            // Validate Home Phone (if provided)
            if (!string.IsNullOrWhiteSpace(textBoxHomePhone.Text))
            {
                if (!int.TryParse(textBoxHomePhone.Text.Trim(), out int homePhone))
                {
                    MessageBox.Show("Home Phone must be a valid number.\n\nPlease enter only digits (e.g., 112345678).", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxHomePhone.Focus();
                    return false;
                }

                string homeStr = textBoxHomePhone.Text.Trim();
                if (homeStr.Length < 9 || homeStr.Length > 10)
                {
                    MessageBox.Show("Home Phone must be 9-10 digits.\n\nExample: 112345678 or 0112345678", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxHomePhone.Focus();
                    return false;
                }

                if (homePhone <= 0)
                {
                    MessageBox.Show("Home Phone must be a positive number.\n\nPlease enter a valid phone number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxHomePhone.Focus();
                    return false;
                }
            }

            // Validate Address length (if provided)
            if (!string.IsNullOrWhiteSpace(textBoxAddress.Text) && textBoxAddress.Text.Trim().Length > 50)
            {
                MessageBox.Show("Address cannot exceed 50 characters.\n\nPlease enter a shorter address.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxAddress.Focus();
                return false;
            }

            // Validate Parent Name (if provided)
            if (!string.IsNullOrWhiteSpace(textBoxParentName.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxParentName.Text.Trim(), @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Parent Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxParentName.Focus();
                    return false;
                }

                if (textBoxParentName.Text.Trim().Length < 2)
                {
                    MessageBox.Show("Parent Name must be at least 2 characters long.\n\nPlease enter a valid name.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxParentName.Focus();
                    return false;
                }

                if (textBoxParentName.Text.Trim().Length > 50)
                {
                    MessageBox.Show("Parent Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxParentName.Focus();
                    return false;
                }
            }

            // Validate NIC (if provided)
            if (!string.IsNullOrWhiteSpace(textBoxNIC.Text))
            {
                string nic = textBoxNIC.Text.Trim();
                
                // NIC format: 12 digits or 9 digits + V (old format)
                if (!System.Text.RegularExpressions.Regex.IsMatch(nic, @"^(\d{9}[VvXx]|\d{12})$"))
                {
                    MessageBox.Show("NIC format is invalid.\n\nAccepted formats:\n- Old: 9 digits + V (e.g., 123456789V)\n- New: 12 digits (e.g., 200012345678)", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNIC.Focus();
                    return false;
                }

                if (nic.Length > 50)
                {
                    MessageBox.Show("NIC cannot exceed 50 characters.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNIC.Focus();
                    return false;
                }
            }

            // Validate Contact No (if provided)
            if (!string.IsNullOrWhiteSpace(textBoxContactNo.Text))
            {
                if (!int.TryParse(textBoxContactNo.Text.Trim(), out int contactNo))
                {
                    MessageBox.Show("Contact Number must be a valid number.\n\nPlease enter only digits.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxContactNo.Focus();
                    return false;
                }

                string contactStr = textBoxContactNo.Text.Trim();
                if (contactStr.Length < 9 || contactStr.Length > 10)
                {
                    MessageBox.Show("Contact Number must be 9-10 digits.\n\nExample: 771234567 or 0771234567", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxContactNo.Focus();
                    return false;
                }

                if (contactNo <= 0)
                {
                    MessageBox.Show("Contact Number must be a positive number.\n\nPlease enter a valid contact number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxContactNo.Focus();
                    return false;
                }
            }

            return true;
        }

        private Student CreateStudentFromForm(int regNo)
        {
            Student student = new Student();
            student.RegNo = regNo;
            student.FirstName = textBoxFirstName.Text.Trim();
            student.LastName = textBoxLastName.Text.Trim();
            student.DateOfBirth = dateTimePickerDOB.Value;
            student.Gender = radioButtonMale.Checked ? "Male" : "Female";
            student.Address = textBoxAddress.Text.Trim();
            student.Email = textBoxEmail.Text.Trim();

            // Parse numeric fields
            int.TryParse(textBoxMobilePhone.Text, out int mobilePhone);
            student.MobilePhone = mobilePhone;

            int.TryParse(textBoxHomePhone.Text, out int homePhone);
            student.HomePhone = homePhone;

            student.ParentName = textBoxParentName.Text.Trim();
            student.NIC = textBoxNIC.Text.Trim();

            int.TryParse(textBoxContactNo.Text, out int contactNo);
            student.ContactNo = contactNo;

            return student;
        }

        private void ClearForm()
        {
            comboBoxRegNo.SelectedIndex = -1;
            comboBoxRegNo.Text = "";
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            dateTimePickerDOB.Value = DateTime.Now;
            radioButtonMale.Checked = false;
            radioButtonFemale.Checked = false;
            textBoxAddress.Clear();
            textBoxEmail.Clear();
            textBoxMobilePhone.Clear();
            textBoxHomePhone.Clear();
            textBoxParentName.Clear();
            textBoxNIC.Clear();
            textBoxContactNo.Clear();
            comboBoxRegNo.Focus();
        }
    }
}
