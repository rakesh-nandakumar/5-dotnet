using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Forms
{
    public partial class RegistrationForm : Form
    {
        private DatabaseHelper dbHelper;

        // GroupBoxes
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

            // Form properties - Modern wide design
            this.Text = "Student Registration - Skills International";
            this.Size = new Size(1100, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.WindowState = FormWindowState.Normal;

            // Top header bar with gradient
            Panel headerBar = new Panel();
            headerBar.Location = new Point(0, 0);
            headerBar.Size = new Size(1100, 70);
            headerBar.BackColor = Color.FromArgb(25, 118, 210);
            this.Controls.Add(headerBar);

            // Title label in header
            Label titleLabel = new Label();
            titleLabel.Text = "STUDENT REGISTRATION SYSTEM";
            titleLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(30, 20);
            titleLabel.Size = new Size(500, 30);
            headerBar.Controls.Add(titleLabel);

            // LinkLabel Logout - Top right
            linkLabelLogout = new LinkLabel();
            linkLabelLogout.Text = "Logout";
            linkLabelLogout.Location = new Point(950, 25);
            linkLabelLogout.Size = new Size(60, 20);
            linkLabelLogout.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            linkLabelLogout.LinkColor = Color.White;
            linkLabelLogout.ActiveLinkColor = Color.LightGray;
            linkLabelLogout.LinkClicked += LinkLabelLogout_LinkClicked;
            headerBar.Controls.Add(linkLabelLogout);

            // LinkLabel Exit
            linkLabelExit = new LinkLabel();
            linkLabelExit.Text = "Exit";
            linkLabelExit.Location = new Point(1020, 25);
            linkLabelExit.Size = new Size(40, 20);
            linkLabelExit.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            linkLabelExit.LinkColor = Color.White;
            linkLabelExit.ActiveLinkColor = Color.LightGray;
            linkLabelExit.LinkClicked += LinkLabelExit_LinkClicked;
            headerBar.Controls.Add(linkLabelExit);

            // Main container panel
            Panel mainPanel = new Panel();
            mainPanel.Location = new Point(20, 90);
            mainPanel.Size = new Size(1050, 660);
            mainPanel.BackColor = Color.White;
            this.Controls.Add(mainPanel);

            // Registration number section - Top card
            Panel regNoPanel = new Panel();
            regNoPanel.Location = new Point(30, 20);
            regNoPanel.Size = new Size(990, 70);
            regNoPanel.BackColor = Color.FromArgb(250, 250, 250);
            mainPanel.Controls.Add(regNoPanel);

            labelRegNo = new Label();
            labelRegNo.Text = "REGISTRATION NUMBER";
            labelRegNo.Location = new Point(20, 15);
            labelRegNo.Size = new Size(180, 20);
            labelRegNo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            labelRegNo.ForeColor = Color.FromArgb(100, 100, 100);
            regNoPanel.Controls.Add(labelRegNo);

            comboBoxRegNo = new ComboBox();
            comboBoxRegNo.Location = new Point(220, 12);
            comboBoxRegNo.Size = new Size(250, 30);
            comboBoxRegNo.Font = new Font("Segoe UI", 11);
            comboBoxRegNo.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxRegNo.SelectedIndexChanged += ComboBoxRegNo_SelectedIndexChanged;
            regNoPanel.Controls.Add(comboBoxRegNo);

            // GroupBox Basic Details - Modern card style
            groupBoxBasicDetails = new GroupBox();
            groupBoxBasicDetails.Text = "  BASIC INFORMATION  ";
            groupBoxBasicDetails.Location = new Point(30, 110);
            groupBoxBasicDetails.Size = new Size(990, 160);
            groupBoxBasicDetails.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            groupBoxBasicDetails.ForeColor = Color.FromArgb(25, 118, 210);
            mainPanel.Controls.Add(groupBoxBasicDetails);

            // First Name
            labelFirstName = new Label();
            labelFirstName.Text = "First Name";
            labelFirstName.Location = new Point(30, 35);
            labelFirstName.Size = new Size(150, 20);
            labelFirstName.Font = new Font("Segoe UI", 9);
            labelFirstName.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxBasicDetails.Controls.Add(labelFirstName);

            textBoxFirstName = new TextBox();
            textBoxFirstName.Location = new Point(30, 58);
            textBoxFirstName.Size = new Size(220, 28);
            textBoxFirstName.Font = new Font("Segoe UI", 10);
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            groupBoxBasicDetails.Controls.Add(textBoxFirstName);

            // Last Name
            labelLastName = new Label();
            labelLastName.Text = "Last Name";
            labelLastName.Location = new Point(280, 35);
            labelLastName.Size = new Size(150, 20);
            labelLastName.Font = new Font("Segoe UI", 9);
            labelLastName.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxBasicDetails.Controls.Add(labelLastName);

            textBoxLastName = new TextBox();
            textBoxLastName.Location = new Point(280, 58);
            textBoxLastName.Size = new Size(220, 28);
            textBoxLastName.Font = new Font("Segoe UI", 10);
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            groupBoxBasicDetails.Controls.Add(textBoxLastName);

            // Date of Birth
            labelDateOfBirth = new Label();
            labelDateOfBirth.Text = "Date of Birth";
            labelDateOfBirth.Location = new Point(530, 35);
            labelDateOfBirth.Size = new Size(150, 20);
            labelDateOfBirth.Font = new Font("Segoe UI", 9);
            labelDateOfBirth.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxBasicDetails.Controls.Add(labelDateOfBirth);

            dateTimePickerDOB = new DateTimePicker();
            dateTimePickerDOB.Location = new Point(530, 58);
            dateTimePickerDOB.Size = new Size(220, 28);
            dateTimePickerDOB.Font = new Font("Segoe UI", 10);
            dateTimePickerDOB.Format = DateTimePickerFormat.Short;
            groupBoxBasicDetails.Controls.Add(dateTimePickerDOB);

            // Gender
            labelGender = new Label();
            labelGender.Text = "Gender";
            labelGender.Location = new Point(780, 35);
            labelGender.Size = new Size(150, 20);
            labelGender.Font = new Font("Segoe UI", 9);
            labelGender.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxBasicDetails.Controls.Add(labelGender);

            Panel genderPanel = new Panel();
            genderPanel.Location = new Point(780, 58);
            genderPanel.Size = new Size(180, 30);
            groupBoxBasicDetails.Controls.Add(genderPanel);

            radioButtonMale = new RadioButton();
            radioButtonMale.Text = "Male";
            radioButtonMale.Location = new Point(0, 5);
            radioButtonMale.Size = new Size(80, 20);
            radioButtonMale.Font = new Font("Segoe UI", 10);
            radioButtonMale.Checked = true;
            genderPanel.Controls.Add(radioButtonMale);

            radioButtonFemale = new RadioButton();
            radioButtonFemale.Text = "Female";
            radioButtonFemale.Location = new Point(90, 5);
            radioButtonFemale.Size = new Size(80, 20);
            radioButtonFemale.Font = new Font("Segoe UI", 10);
            genderPanel.Controls.Add(radioButtonFemale);

            // Address - Full width
            labelAddress = new Label();
            labelAddress.Text = "Address";
            labelAddress.Location = new Point(30, 100);
            labelAddress.Size = new Size(150, 20);
            labelAddress.Font = new Font("Segoe UI", 9);
            labelAddress.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxBasicDetails.Controls.Add(labelAddress);

            textBoxAddress = new TextBox();
            textBoxAddress.Location = new Point(30, 123);
            textBoxAddress.Size = new Size(930, 28);
            textBoxAddress.Font = new Font("Segoe UI", 10);
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            groupBoxBasicDetails.Controls.Add(textBoxAddress);

            // GroupBox Contact Details - Modern card style
            groupBoxContactDetails = new GroupBox();
            groupBoxContactDetails.Text = "  CONTACT INFORMATION  ";
            groupBoxContactDetails.Location = new Point(30, 285);
            groupBoxContactDetails.Size = new Size(990, 120);
            groupBoxContactDetails.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            groupBoxContactDetails.ForeColor = Color.FromArgb(25, 118, 210);
            mainPanel.Controls.Add(groupBoxContactDetails);

            // Email
            labelEmail = new Label();
            labelEmail.Text = "Email Address";
            labelEmail.Location = new Point(30, 35);
            labelEmail.Size = new Size(150, 20);
            labelEmail.Font = new Font("Segoe UI", 9);
            labelEmail.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxContactDetails.Controls.Add(labelEmail);

            textBoxEmail = new TextBox();
            textBoxEmail.Location = new Point(30, 58);
            textBoxEmail.Size = new Size(280, 28);
            textBoxEmail.Font = new Font("Segoe UI", 10);
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            groupBoxContactDetails.Controls.Add(textBoxEmail);

            // Mobile Phone
            labelMobilePhone = new Label();
            labelMobilePhone.Text = "Mobile Phone";
            labelMobilePhone.Location = new Point(340, 35);
            labelMobilePhone.Size = new Size(150, 20);
            labelMobilePhone.Font = new Font("Segoe UI", 9);
            labelMobilePhone.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxContactDetails.Controls.Add(labelMobilePhone);

            textBoxMobilePhone = new TextBox();
            textBoxMobilePhone.Location = new Point(340, 58);
            textBoxMobilePhone.Size = new Size(200, 28);
            textBoxMobilePhone.Font = new Font("Segoe UI", 10);
            textBoxMobilePhone.BorderStyle = BorderStyle.FixedSingle;
            groupBoxContactDetails.Controls.Add(textBoxMobilePhone);

            // Home Phone
            labelHomePhone = new Label();
            labelHomePhone.Text = "Home Phone";
            labelHomePhone.Location = new Point(570, 35);
            labelHomePhone.Size = new Size(150, 20);
            labelHomePhone.Font = new Font("Segoe UI", 9);
            labelHomePhone.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxContactDetails.Controls.Add(labelHomePhone);

            textBoxHomePhone = new TextBox();
            textBoxHomePhone.Location = new Point(570, 58);
            textBoxHomePhone.Size = new Size(200, 28);
            textBoxHomePhone.Font = new Font("Segoe UI", 10);
            textBoxHomePhone.BorderStyle = BorderStyle.FixedSingle;
            groupBoxContactDetails.Controls.Add(textBoxHomePhone);

            // GroupBox Parent Details - Modern card style
            groupBoxParentDetails = new GroupBox();
            groupBoxParentDetails.Text = "  PARENT / GUARDIAN INFORMATION  ";
            groupBoxParentDetails.Location = new Point(30, 420);
            groupBoxParentDetails.Size = new Size(990, 120);
            groupBoxParentDetails.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            groupBoxParentDetails.ForeColor = Color.FromArgb(25, 118, 210);
            mainPanel.Controls.Add(groupBoxParentDetails);

            // Parent Name
            labelParentName = new Label();
            labelParentName.Text = "Parent / Guardian Name";
            labelParentName.Location = new Point(30, 35);
            labelParentName.Size = new Size(180, 20);
            labelParentName.Font = new Font("Segoe UI", 9);
            labelParentName.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxParentDetails.Controls.Add(labelParentName);

            textBoxParentName = new TextBox();
            textBoxParentName.Location = new Point(30, 58);
            textBoxParentName.Size = new Size(280, 28);
            textBoxParentName.Font = new Font("Segoe UI", 10);
            textBoxParentName.BorderStyle = BorderStyle.FixedSingle;
            groupBoxParentDetails.Controls.Add(textBoxParentName);

            // NIC
            labelNIC = new Label();
            labelNIC.Text = "NIC";
            labelNIC.Location = new Point(340, 35);
            labelNIC.Size = new Size(150, 20);
            labelNIC.Font = new Font("Segoe UI", 9);
            labelNIC.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxParentDetails.Controls.Add(labelNIC);

            textBoxNIC = new TextBox();
            textBoxNIC.Location = new Point(340, 58);
            textBoxNIC.Size = new Size(200, 28);
            textBoxNIC.Font = new Font("Segoe UI", 10);
            textBoxNIC.BorderStyle = BorderStyle.FixedSingle;
            groupBoxParentDetails.Controls.Add(textBoxNIC);

            // Contact No
            labelContactNo = new Label();
            labelContactNo.Text = "Contact Number";
            labelContactNo.Location = new Point(570, 35);
            labelContactNo.Size = new Size(150, 20);
            labelContactNo.Font = new Font("Segoe UI", 9);
            labelContactNo.ForeColor = Color.FromArgb(80, 80, 80);
            groupBoxParentDetails.Controls.Add(labelContactNo);

            textBoxContactNo = new TextBox();
            textBoxContactNo.Location = new Point(570, 58);
            textBoxContactNo.Size = new Size(200, 28);
            textBoxContactNo.Font = new Font("Segoe UI", 10);
            textBoxContactNo.BorderStyle = BorderStyle.FixedSingle;
            groupBoxParentDetails.Controls.Add(textBoxContactNo);

            // Action buttons panel at bottom - Modern large buttons
            Panel buttonPanel = new Panel();
            buttonPanel.Location = new Point(30, 560);
            buttonPanel.Size = new Size(990, 70);
            buttonPanel.BackColor = Color.FromArgb(250, 250, 250);
            mainPanel.Controls.Add(buttonPanel);

            // Button Register - Primary action
            buttonRegister = new Button();
            buttonRegister.Text = "REGISTER STUDENT";
            buttonRegister.Location = new Point(20, 15);
            buttonRegister.Size = new Size(220, 45);
            buttonRegister.BackColor = Color.FromArgb(76, 175, 80); // Green
            buttonRegister.ForeColor = Color.White;
            buttonRegister.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.Cursor = Cursors.Hand;
            buttonRegister.Click += ButtonRegister_Click;
            buttonPanel.Controls.Add(buttonRegister);

            // Button Update
            buttonUpdate = new Button();
            buttonUpdate.Text = "UPDATE";
            buttonUpdate.Location = new Point(260, 15);
            buttonUpdate.Size = new Size(220, 45);
            buttonUpdate.BackColor = Color.FromArgb(33, 150, 243); // Blue
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.FlatAppearance.BorderSize = 0;
            buttonUpdate.Cursor = Cursors.Hand;
            buttonUpdate.Click += ButtonUpdate_Click;
            buttonPanel.Controls.Add(buttonUpdate);

            // Button Clear
            buttonClear = new Button();
            buttonClear.Text = "CLEAR";
            buttonClear.Location = new Point(500, 15);
            buttonClear.Size = new Size(220, 45);
            buttonClear.BackColor = Color.FromArgb(158, 158, 158); // Gray
            buttonClear.ForeColor = Color.White;
            buttonClear.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.Cursor = Cursors.Hand;
            buttonClear.Click += ButtonClear_Click;
            buttonPanel.Controls.Add(buttonClear);

            // Button Delete
            buttonDelete = new Button();
            buttonDelete.Text = "DELETE";
            buttonDelete.Location = new Point(740, 15);
            buttonDelete.Size = new Size(220, 45);
            buttonDelete.BackColor = Color.FromArgb(244, 67, 54); // Red
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.Click += ButtonDelete_Click;
            buttonPanel.Controls.Add(buttonDelete);

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
