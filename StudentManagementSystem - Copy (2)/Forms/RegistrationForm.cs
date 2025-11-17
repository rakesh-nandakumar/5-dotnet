using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Forms
{
    public partial class RegistrationForm : Form
    {
        private DatabaseHelper dbHelper;

        // GroupBoxes
        private GroupBox RegistrationGroupBox = null!;
        private GroupBox BasicDetailsGroupBox = null!;
        private GroupBox ContactDetailsGroupBox = null!;
        private GroupBox ParentDetailsGroupBox = null!;

        // Controls
        private Label RegNoLabel = null!;
        private ComboBox RegNoComboBox = null!;
        private Label FirstNameLabel = null!;
        private TextBox FirstNameTextBox = null!;
        private Label LastNameLabel = null!;
        private TextBox LastNameTextBox = null!;
        private Label DateOfBirthLabel = null!;
        private DateTimePicker DOBDateTimePicker = null!;
        private Label GenderLabel = null!;
        private RadioButton MaleRadioButton = null!;
        private RadioButton FemaleRadioButton = null!;
        private Label AddressLabel = null!;
        private TextBox AddressTextBox = null!;
        private Label EmailLabel = null!;
        private TextBox EmailTextBox = null!;
        private Label MobilePhoneLabel = null!;
        private TextBox MobilePhoneTextBox = null!;
        private Label HomePhoneLabel = null!;
        private TextBox HomePhoneTextBox = null!;
        private Label ParentNameLabel = null!;
        private TextBox ParentNameTextBox = null!;
        private Label NICLabel = null!;
        private TextBox NICTextBox = null!;
        private Label ContactNoLabel = null!;
        private TextBox ContactNoTextBox = null!;

        // Buttons
        private Button RegisterButton = null!;
        private Button UpdateButton = null!;
        private Button ClearButton = null!;
        private Button DeleteButton = null!;

        // LinkLabels
        private LinkLabel LogoutLinkLabel = null!;
        private LinkLabel ExitLinkLabel = null!;

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
            this.BackColor = Color.White;
            this.WindowState = FormWindowState.Normal;

            // GroupBox Registration (Main Container)
            RegistrationGroupBox = new GroupBox();
            RegistrationGroupBox.Text = "Student Registration";
            RegistrationGroupBox.Location = new Point(20, 20);
            RegistrationGroupBox.Size = new Size(840, 630);
            RegistrationGroupBox.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Controls.Add(RegistrationGroupBox);

            // Label & ComboBox Registration Number
            RegNoLabel = new Label();
            RegNoLabel.Text = "Registration No:";
            RegNoLabel.Location = new Point(30, 40);
            RegNoLabel.Size = new Size(150, 25);
            RegNoLabel.Font = new Font("Arial", 12);
            RegistrationGroupBox.Controls.Add(RegNoLabel);

            RegNoComboBox = new ComboBox();
            RegNoComboBox.Location = new Point(190, 38);
            RegNoComboBox.Size = new Size(200, 25);
            RegNoComboBox.Font = new Font("Arial", 12);
            RegNoComboBox.SelectedIndexChanged += RegNoComboBox_SelectedIndexChanged;
            RegistrationGroupBox.Controls.Add(RegNoComboBox);

            // GroupBox Basic Details
            BasicDetailsGroupBox = new GroupBox();
            BasicDetailsGroupBox.Text = "Basic Details";
            BasicDetailsGroupBox.Location = new Point(30, 80);
            BasicDetailsGroupBox.Size = new Size(780, 180);
            BasicDetailsGroupBox.Font = new Font("Arial", 12, FontStyle.Bold);
            RegistrationGroupBox.Controls.Add(BasicDetailsGroupBox);

            // First Name
            FirstNameLabel = new Label();
            FirstNameLabel.Text = "First Name:";
            FirstNameLabel.Location = new Point(30, 40);
            FirstNameLabel.Size = new Size(100, 25);
            FirstNameLabel.Font = new Font("Arial", 12);
            BasicDetailsGroupBox.Controls.Add(FirstNameLabel);

            FirstNameTextBox = new TextBox();
            FirstNameTextBox.Location = new Point(160, 38);
            FirstNameTextBox.Size = new Size(200, 25);
            FirstNameTextBox.Font = new Font("Arial", 12);
            BasicDetailsGroupBox.Controls.Add(FirstNameTextBox);

            // Last Name
            LastNameLabel = new Label();
            LastNameLabel.Text = "Last Name:";
            LastNameLabel.Location = new Point(420, 40);
            LastNameLabel.Size = new Size(100, 25);
            LastNameLabel.Font = new Font("Arial", 12);
            BasicDetailsGroupBox.Controls.Add(LastNameLabel);

            LastNameTextBox = new TextBox();
            LastNameTextBox.Location = new Point(550, 38);
            LastNameTextBox.Size = new Size(200, 25);
            LastNameTextBox.Font = new Font("Arial", 12);
            BasicDetailsGroupBox.Controls.Add(LastNameTextBox);

            // Date of Birth
            DateOfBirthLabel = new Label();
            DateOfBirthLabel.Text = "Date of Birth:";
            DateOfBirthLabel.Location = new Point(30, 85);
            DateOfBirthLabel.Size = new Size(100, 25);
            DateOfBirthLabel.Font = new Font("Arial", 12);
            BasicDetailsGroupBox.Controls.Add(DateOfBirthLabel);

            DOBDateTimePicker = new DateTimePicker();
            DOBDateTimePicker.Location = new Point(160, 83);
            DOBDateTimePicker.Size = new Size(200, 25);
            DOBDateTimePicker.Font = new Font("Arial", 12);
            DOBDateTimePicker.Format = DateTimePickerFormat.Short;
            BasicDetailsGroupBox.Controls.Add(DOBDateTimePicker);

            // Gender
            GenderLabel = new Label();
            GenderLabel.Text = "Gender:";
            GenderLabel.Location = new Point(30, 130);
            GenderLabel.Size = new Size(100, 25);
            GenderLabel.Font = new Font("Arial", 12);
            BasicDetailsGroupBox.Controls.Add(GenderLabel);

            MaleRadioButton = new RadioButton();
            MaleRadioButton.Text = "Male";
            MaleRadioButton.Location = new Point(160, 130);
            MaleRadioButton.Size = new Size(80, 25);
            MaleRadioButton.Font = new Font("Arial", 12);
            BasicDetailsGroupBox.Controls.Add(MaleRadioButton);

            FemaleRadioButton = new RadioButton();
            FemaleRadioButton.Text = "Female";
            FemaleRadioButton.Location = new Point(260, 130);
            FemaleRadioButton.Size = new Size(100, 25);
            FemaleRadioButton.Font = new Font("Arial", 12);
            BasicDetailsGroupBox.Controls.Add(FemaleRadioButton);

            // GroupBox Contact Details
            ContactDetailsGroupBox = new GroupBox();
            ContactDetailsGroupBox.Text = "Contact Details";
            ContactDetailsGroupBox.Location = new Point(30, 270);
            ContactDetailsGroupBox.Size = new Size(780, 180);
            ContactDetailsGroupBox.Font = new Font("Arial", 12, FontStyle.Bold);
            RegistrationGroupBox.Controls.Add(ContactDetailsGroupBox);

            // Address
            AddressLabel = new Label();
            AddressLabel.Text = "Address:";
            AddressLabel.Location = new Point(30, 40);
            AddressLabel.Size = new Size(100, 25);
            AddressLabel.Font = new Font("Arial", 12);
            ContactDetailsGroupBox.Controls.Add(AddressLabel);

            AddressTextBox = new TextBox();
            AddressTextBox.Location = new Point(160, 38);
            AddressTextBox.Size = new Size(590, 60);
            AddressTextBox.Multiline = true;
            AddressTextBox.ScrollBars = ScrollBars.Vertical;
            AddressTextBox.Font = new Font("Arial", 12);
            ContactDetailsGroupBox.Controls.Add(AddressTextBox);

            // Email
            EmailLabel = new Label();
            EmailLabel.Text = "Email:";
            EmailLabel.Location = new Point(30, 115);
            EmailLabel.Size = new Size(100, 25);
            EmailLabel.Font = new Font("Arial", 12);
            ContactDetailsGroupBox.Controls.Add(EmailLabel);

            EmailTextBox = new TextBox();
            EmailTextBox.Location = new Point(160, 113);
            EmailTextBox.Size = new Size(200, 25);
            EmailTextBox.Font = new Font("Arial", 12);
            ContactDetailsGroupBox.Controls.Add(EmailTextBox);

            // Mobile Phone
            MobilePhoneLabel = new Label();
            MobilePhoneLabel.Text = "Mobile Phone:";
            MobilePhoneLabel.Location = new Point(420, 115);
            MobilePhoneLabel.Size = new Size(120, 25);
            MobilePhoneLabel.Font = new Font("Arial", 12);
            ContactDetailsGroupBox.Controls.Add(MobilePhoneLabel);

            MobilePhoneTextBox = new TextBox();
            MobilePhoneTextBox.Location = new Point(550, 113);
            MobilePhoneTextBox.Size = new Size(200, 25);
            MobilePhoneTextBox.Font = new Font("Arial", 12);
            ContactDetailsGroupBox.Controls.Add(MobilePhoneTextBox);

            // Home Phone
            HomePhoneLabel = new Label();
            HomePhoneLabel.Text = "Home Phone:";
            HomePhoneLabel.Location = new Point(30, 145);
            HomePhoneLabel.Size = new Size(120, 25);
            HomePhoneLabel.Font = new Font("Arial", 12);
            ContactDetailsGroupBox.Controls.Add(HomePhoneLabel);

            HomePhoneTextBox = new TextBox();
            HomePhoneTextBox.Location = new Point(160, 143);
            HomePhoneTextBox.Size = new Size(200, 25);
            HomePhoneTextBox.Font = new Font("Arial", 12);
            ContactDetailsGroupBox.Controls.Add(HomePhoneTextBox);

            // GroupBox Parent Details
            ParentDetailsGroupBox = new GroupBox();
            ParentDetailsGroupBox.Text = "Parent Details";
            ParentDetailsGroupBox.Location = new Point(30, 460);
            ParentDetailsGroupBox.Size = new Size(780, 100);
            ParentDetailsGroupBox.Font = new Font("Arial", 12, FontStyle.Bold);
            RegistrationGroupBox.Controls.Add(ParentDetailsGroupBox);

            // Parent Name
            ParentNameLabel = new Label();
            ParentNameLabel.Text = "Parent Name:";
            ParentNameLabel.Location = new Point(30, 35);
            ParentNameLabel.Size = new Size(120, 25);
            ParentNameLabel.Font = new Font("Arial", 12);
            ParentDetailsGroupBox.Controls.Add(ParentNameLabel);

            ParentNameTextBox = new TextBox();
            ParentNameTextBox.Location = new Point(160, 33);
            ParentNameTextBox.Size = new Size(200, 25);
            ParentNameTextBox.Font = new Font("Arial", 12);
            ParentDetailsGroupBox.Controls.Add(ParentNameTextBox);

            // NIC
            NICLabel = new Label();
            NICLabel.Text = "NIC:";
            NICLabel.Location = new Point(420, 35);
            NICLabel.Size = new Size(120, 25);
            NICLabel.Font = new Font("Arial", 12);
            ParentDetailsGroupBox.Controls.Add(NICLabel);

            NICTextBox = new TextBox();
            NICTextBox.Location = new Point(550, 33);
            NICTextBox.Size = new Size(200, 25);
            NICTextBox.Font = new Font("Arial", 12);
            ParentDetailsGroupBox.Controls.Add(NICTextBox);

            // Contact No
            ContactNoLabel = new Label();
            ContactNoLabel.Text = "Contact No:";
            ContactNoLabel.Location = new Point(30, 65);
            ContactNoLabel.Size = new Size(120, 25);
            ContactNoLabel.Font = new Font("Arial", 12);
            ParentDetailsGroupBox.Controls.Add(ContactNoLabel);

            ContactNoTextBox = new TextBox();
            ContactNoTextBox.Location = new Point(160, 63);
            ContactNoTextBox.Size = new Size(200, 25);
            ContactNoTextBox.Font = new Font("Arial", 12);
            ParentDetailsGroupBox.Controls.Add(ContactNoTextBox);

            // Buttons - Register
            RegisterButton = new Button();
            RegisterButton.Text = "Register";
            RegisterButton.Location = new Point(30, 575);
            RegisterButton.Size = new Size(120, 35);
            RegisterButton.BackColor = Color.FromArgb(40, 167, 69);
            RegisterButton.ForeColor = Color.White;
            RegisterButton.Font = new Font("Arial", 12, FontStyle.Bold);
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.Click += RegisterButton_Click;
            RegistrationGroupBox.Controls.Add(RegisterButton);

            // Button Update
            UpdateButton = new Button();
            UpdateButton.Text = "Update";
            UpdateButton.Location = new Point(170, 575);
            UpdateButton.Size = new Size(120, 35);
            UpdateButton.BackColor = Color.FromArgb(30, 58, 138);
            UpdateButton.ForeColor = Color.White;
            UpdateButton.Font = new Font("Arial", 12, FontStyle.Bold);
            UpdateButton.FlatStyle = FlatStyle.Flat;
            UpdateButton.Click += UpdateButton_Click;
            RegistrationGroupBox.Controls.Add(UpdateButton);

            // Button Clear
            ClearButton = new Button();
            ClearButton.Text = "Clear";
            ClearButton.Location = new Point(310, 575);
            ClearButton.Size = new Size(120, 35);
            ClearButton.BackColor = Color.FromArgb(245, 158, 11);
            ClearButton.ForeColor = Color.White;
            ClearButton.Font = new Font("Arial", 12, FontStyle.Bold);
            ClearButton.FlatStyle = FlatStyle.Flat;
            ClearButton.Click += ClearButton_Click;
            RegistrationGroupBox.Controls.Add(ClearButton);

            // Button Delete
            DeleteButton = new Button();
            DeleteButton.Text = "Delete";
            DeleteButton.Location = new Point(450, 575);
            DeleteButton.Size = new Size(120, 35);
            DeleteButton.BackColor = Color.FromArgb(220, 53, 69);
            DeleteButton.ForeColor = Color.White;
            DeleteButton.Font = new Font("Arial", 12, FontStyle.Bold);
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.Click += DeleteButton_Click;
            RegistrationGroupBox.Controls.Add(DeleteButton);

            // LinkLabel Logout
            LogoutLinkLabel = new LinkLabel();
            LogoutLinkLabel.Text = "Logout";
            LogoutLinkLabel.Location = new Point(720, 665);
            LogoutLinkLabel.Size = new Size(60, 20);
            LogoutLinkLabel.Font = new Font("Arial", 12);
            LogoutLinkLabel.LinkClicked += LogoutLinkLabel_LinkClicked;
            this.Controls.Add(LogoutLinkLabel);

            // LinkLabel Exit
            ExitLinkLabel = new LinkLabel();
            ExitLinkLabel.Text = "Exit";
            ExitLinkLabel.Location = new Point(810, 665);
            ExitLinkLabel.Size = new Size(40, 20);
            ExitLinkLabel.Font = new Font("Arial", 12);
            ExitLinkLabel.LinkClicked += ExitLinkLabel_LinkClicked;
            this.Controls.Add(ExitLinkLabel);

            this.ResumeLayout();
        }

        private void LoadRegistrationNumbers()
        {
            RegNoComboBox.Items.Clear();
            List<int> regNumbers = dbHelper.GetAllRegNumbers();
            foreach (int regNo in regNumbers)
            {
                RegNoComboBox.Items.Add(regNo);
            }
        }

        private void RegNoComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (RegNoComboBox.SelectedItem != null)
            {
                int regNo = (int)RegNoComboBox.SelectedItem;
                Student? student = dbHelper.GetStudentByRegNo(regNo);

                if (student != null)
                {
                    FirstNameTextBox.Text = student.FirstName;
                    LastNameTextBox.Text = student.LastName;
                    DOBDateTimePicker.Value = student.DateOfBirth;
                    
                    if (student.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                        MaleRadioButton.Checked = true;
                    else if (student.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                        FemaleRadioButton.Checked = true;

                    AddressTextBox.Text = student.Address;
                    EmailTextBox.Text = student.Email;
                    MobilePhoneTextBox.Text = student.MobilePhone.ToString();
                    HomePhoneTextBox.Text = student.HomePhone.ToString();
                    ParentNameTextBox.Text = student.ParentName;
                    NICTextBox.Text = student.NIC;
                    ContactNoTextBox.Text = student.ContactNo.ToString();
                }
            }
        }

        private void RegisterButton_Click(object? sender, EventArgs e)
        {
            // Validate required fields
            if (!ValidateInputFields(true))
                return;

            // Get registration number
            if (!int.TryParse(RegNoComboBox.Text, out int regNo))
            {
                MessageBox.Show("Please enter a valid Registration Number", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RegNoComboBox.Focus();
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
            Student student = CreateStudentFromFormData(regNo);

            // Insert into database
            if (dbHelper.InsertStudent(student))
            {
                MessageBox.Show("Student registered successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegistrationNumbers();
                ClearAllFields();
            }
            else
            {
                MessageBox.Show("Failed to add record", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButton_Click(object? sender, EventArgs e)
        {
            // Validate registration number is selected
            if (RegNoComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Registration Number to update", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate required fields
            if (!ValidateInputFields(false))
                return;

            int regNo = (int)RegNoComboBox.SelectedItem;

            // Create student object
            Student student = CreateStudentFromFormData(regNo);

            // Update in database
            if (dbHelper.UpdateStudent(student))
            {
                MessageBox.Show("Student information updated successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegistrationNumbers();
            }
            else
            {
                MessageBox.Show("Failed to update record", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            // Validate registration number is selected
            if (RegNoComboBox.SelectedItem == null)
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
                int regNo = (int)RegNoComboBox.SelectedItem;

                if (dbHelper.DeleteStudent(regNo))
                {
                    MessageBox.Show("Student record deleted successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRegistrationNumbers();
                    ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Failed to delete record", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearButton_Click(object? sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void LogoutLinkLabel_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void ExitLinkLabel_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
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

        private bool ValidateInputFields(bool isNewRegistration)
        {
            // Validate Registration Number (only for new registration)
            if (isNewRegistration && string.IsNullOrWhiteSpace(RegNoComboBox.Text))
            {
                MessageBox.Show("Registration Number is required.\n\nPlease enter a valid registration number.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RegNoComboBox.Focus();
                return false;
            }

            // Validate Registration Number format (must be numeric)
            if (isNewRegistration)
            {
                if (!int.TryParse(RegNoComboBox.Text, out int regNo))
                {
                    MessageBox.Show("Registration Number must be a valid number.\n\nExample: 1001, 1002, etc.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RegNoComboBox.Focus();
                    return false;
                }

                if (regNo <= 0)
                {
                    MessageBox.Show("Registration Number must be a positive number.\n\nPlease enter a number greater than 0.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RegNoComboBox.Focus();
                    return false;
                }
            }

            // Validate First Name
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                MessageBox.Show("First Name is required.\n\nPlease enter the student's first name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FirstNameTextBox.Focus();
                return false;
            }

            // Validate First Name format (only letters and spaces)
            if (!System.Text.RegularExpressions.Regex.IsMatch(FirstNameTextBox.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FirstNameTextBox.Focus();
                return false;
            }

            // Validate First Name length
            if (FirstNameTextBox.Text.Trim().Length < 2)
            {
                MessageBox.Show("First Name must be at least 2 characters long.\n\nPlease enter a valid first name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FirstNameTextBox.Focus();
                return false;
            }

            if (FirstNameTextBox.Text.Trim().Length > 50)
            {
                MessageBox.Show("First Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FirstNameTextBox.Focus();
                return false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                MessageBox.Show("Last Name is required.\n\nPlease enter the student's last name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LastNameTextBox.Focus();
                return false;
            }

            // Validate Last Name format (only letters and spaces)
            if (!System.Text.RegularExpressions.Regex.IsMatch(LastNameTextBox.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LastNameTextBox.Focus();
                return false;
            }

            // Validate Last Name length
            if (LastNameTextBox.Text.Trim().Length < 2)
            {
                MessageBox.Show("Last Name must be at least 2 characters long.\n\nPlease enter a valid last name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LastNameTextBox.Focus();
                return false;
            }

            if (LastNameTextBox.Text.Trim().Length > 50)
            {
                MessageBox.Show("Last Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LastNameTextBox.Focus();
                return false;
            }

            // Validate Date of Birth
            DateTime today = DateTime.Today;
            DateTime minDate = today.AddYears(-100); // Maximum age 100 years
            DateTime maxDate = today.AddYears(-5);   // Minimum age 5 years

            if (DOBDateTimePicker.Value > today)
            {
                MessageBox.Show("Date of Birth cannot be in the future.\n\nPlease select a valid date.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DOBDateTimePicker.Focus();
                return false;
            }

            if (DOBDateTimePicker.Value < minDate)
            {
                MessageBox.Show("Date of Birth is too far in the past.\n\nPlease select a valid date (within last 100 years).", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DOBDateTimePicker.Focus();
                return false;
            }

            if (DOBDateTimePicker.Value > maxDate)
            {
                MessageBox.Show("Student must be at least 5 years old.\n\nPlease select an earlier date of birth.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DOBDateTimePicker.Focus();
                return false;
            }

            // Validate Gender
            if (!MaleRadioButton.Checked && !FemaleRadioButton.Checked)
            {
                MessageBox.Show("Gender is required.\n\nPlease select either Male or Female.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MaleRadioButton.Focus();
                return false;
            }

            // Validate Email (if provided)
            if (!string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                string email = EmailTextBox.Text.Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, 
                    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    MessageBox.Show("Please enter a valid email address.\n\nExample: student@example.com", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EmailTextBox.Focus();
                    return false;
                }

                if (email.Length > 50)
                {
                    MessageBox.Show("Email cannot exceed 50 characters.\n\nPlease enter a shorter email address.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EmailTextBox.Focus();
                    return false;
                }
            }

            // Validate Mobile Phone (if provided)
            if (!string.IsNullOrWhiteSpace(MobilePhoneTextBox.Text))
            {
                if (!int.TryParse(MobilePhoneTextBox.Text.Trim(), out int mobilePhone))
                {
                    MessageBox.Show("Mobile Phone must be a valid number.\n\nPlease enter only digits (e.g., 771234567).", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MobilePhoneTextBox.Focus();
                    return false;
                }

                string mobileStr = MobilePhoneTextBox.Text.Trim();
                if (mobileStr.Length < 9 || mobileStr.Length > 10)
                {
                    MessageBox.Show("Mobile Phone must be 9-10 digits.\n\nExample: 771234567 or 0771234567", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MobilePhoneTextBox.Focus();
                    return false;
                }

                if (mobilePhone <= 0)
                {
                    MessageBox.Show("Mobile Phone must be a positive number.\n\nPlease enter a valid phone number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MobilePhoneTextBox.Focus();
                    return false;
                }
            }

            // Validate Home Phone (if provided)
            if (!string.IsNullOrWhiteSpace(HomePhoneTextBox.Text))
            {
                if (!int.TryParse(HomePhoneTextBox.Text.Trim(), out int homePhone))
                {
                    MessageBox.Show("Home Phone must be a valid number.\n\nPlease enter only digits (e.g., 112345678).", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    HomePhoneTextBox.Focus();
                    return false;
                }

                string homeStr = HomePhoneTextBox.Text.Trim();
                if (homeStr.Length < 9 || homeStr.Length > 10)
                {
                    MessageBox.Show("Home Phone must be 9-10 digits.\n\nExample: 112345678 or 0112345678", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    HomePhoneTextBox.Focus();
                    return false;
                }

                if (homePhone <= 0)
                {
                    MessageBox.Show("Home Phone must be a positive number.\n\nPlease enter a valid phone number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    HomePhoneTextBox.Focus();
                    return false;
                }
            }

            // Validate Address length (if provided)
            if (!string.IsNullOrWhiteSpace(AddressTextBox.Text) && AddressTextBox.Text.Trim().Length > 50)
            {
                MessageBox.Show("Address cannot exceed 50 characters.\n\nPlease enter a shorter address.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddressTextBox.Focus();
                return false;
            }

            // Validate Parent Name (if provided)
            if (!string.IsNullOrWhiteSpace(ParentNameTextBox.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(ParentNameTextBox.Text.Trim(), @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Parent Name can only contain letters and spaces.\n\nPlease remove any numbers or special characters.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ParentNameTextBox.Focus();
                    return false;
                }

                if (ParentNameTextBox.Text.Trim().Length < 2)
                {
                    MessageBox.Show("Parent Name must be at least 2 characters long.\n\nPlease enter a valid name.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ParentNameTextBox.Focus();
                    return false;
                }

                if (ParentNameTextBox.Text.Trim().Length > 50)
                {
                    MessageBox.Show("Parent Name cannot exceed 50 characters.\n\nPlease enter a shorter name.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ParentNameTextBox.Focus();
                    return false;
                }
            }

            // Validate NIC (if provided)
            if (!string.IsNullOrWhiteSpace(NICTextBox.Text))
            {
                string nic = NICTextBox.Text.Trim();
                
                // NIC format: 12 digits or 9 digits + V (old format)
                if (!System.Text.RegularExpressions.Regex.IsMatch(nic, @"^(\d{9}[VvXx]|\d{12})$"))
                {
                    MessageBox.Show("NIC format is invalid.\n\nAccepted formats:\n- Old: 9 digits + V (e.g., 123456789V)\n- New: 12 digits (e.g., 200012345678)", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NICTextBox.Focus();
                    return false;
                }

                if (nic.Length > 50)
                {
                    MessageBox.Show("NIC cannot exceed 50 characters.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NICTextBox.Focus();
                    return false;
                }
            }

            // Validate Contact No (if provided)
            if (!string.IsNullOrWhiteSpace(ContactNoTextBox.Text))
            {
                if (!int.TryParse(ContactNoTextBox.Text.Trim(), out int contactNo))
                {
                    MessageBox.Show("Contact Number must be a valid number.\n\nPlease enter only digits.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ContactNoTextBox.Focus();
                    return false;
                }

                string contactStr = ContactNoTextBox.Text.Trim();
                if (contactStr.Length < 9 || contactStr.Length > 10)
                {
                    MessageBox.Show("Contact Number must be 9-10 digits.\n\nExample: 771234567 or 0771234567", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ContactNoTextBox.Focus();
                    return false;
                }

                if (contactNo <= 0)
                {
                    MessageBox.Show("Contact Number must be a positive number.\n\nPlease enter a valid contact number.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ContactNoTextBox.Focus();
                    return false;
                }
            }

            return true;
        }

        private Student CreateStudentFromFormData(int regNo)
        {
            Student student = new Student();
            student.RegNo = regNo;
            student.FirstName = FirstNameTextBox.Text.Trim();
            student.LastName = LastNameTextBox.Text.Trim();
            student.DateOfBirth = DOBDateTimePicker.Value;
            student.Gender = MaleRadioButton.Checked ? "Male" : "Female";
            student.Address = AddressTextBox.Text.Trim();
            student.Email = EmailTextBox.Text.Trim();

            // Parse numeric fields
            int.TryParse(MobilePhoneTextBox.Text, out int mobilePhone);
            student.MobilePhone = mobilePhone;

            int.TryParse(HomePhoneTextBox.Text, out int homePhone);
            student.HomePhone = homePhone;

            student.ParentName = ParentNameTextBox.Text.Trim();
            student.NIC = NICTextBox.Text.Trim();

            int.TryParse(ContactNoTextBox.Text, out int contactNo);
            student.ContactNo = contactNo;

            return student;
        }

        private void ClearAllFields()
        {
            RegNoComboBox.SelectedIndex = -1;
            RegNoComboBox.Text = "";
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            DOBDateTimePicker.Value = DateTime.Now;
            MaleRadioButton.Checked = false;
            FemaleRadioButton.Checked = false;
            AddressTextBox.Clear();
            EmailTextBox.Clear();
            MobilePhoneTextBox.Clear();
            HomePhoneTextBox.Clear();
            ParentNameTextBox.Clear();
            NICTextBox.Clear();
            ContactNoTextBox.Clear();
            RegNoComboBox.Focus();
        }
    }
}
