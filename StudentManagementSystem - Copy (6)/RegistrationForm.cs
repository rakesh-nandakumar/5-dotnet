using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StudentManagementSystem.Data;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Models;

namespace StudentManagementSystem
{
    public partial class RegistrationForm : Form
    {
        private readonly DatabaseRepository database_repository;

        public RegistrationForm()
        {
            InitializeComponent();
            database_repository = new DatabaseRepository();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            LoadRegistrationNumbers();
        }

        private void LoadRegistrationNumbers()
        {
            List<int> registration_numbers = database_repository.GetAllRegistrationNumbers();
            combo_box_reg_no.Items.Clear();
            foreach (int reg_number in registration_numbers)
            {
                combo_box_reg_no.Items.Add(reg_number);
            }
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            var required_fields = new[] { text_box_first_name, text_box_last_name, text_box_address, 
                                         text_box_email, text_box_mobile, text_box_home, text_box_parent_name, 
                                         text_box_nic, text_box_contact };
            
            if (required_fields.Any(t => string.IsNullOrWhiteSpace(t.Text)))
            {
                FormManager.ShowWarningMessage("Please fill in all required fields", "Validation Error");
                return;
            }

            string reg_no_text = combo_box_reg_no.Text;
            if (string.IsNullOrWhiteSpace(reg_no_text) || !int.TryParse(reg_no_text, out int reg_no))
            {
                FormManager.ShowWarningMessage("Please enter a valid registration number", "Validation Error");
                return;
            }

            if (database_repository.CheckIfRegistrationExists(reg_no))
            {
                FormManager.ShowWarningMessage("This registration number already exists", "Duplicate Entry");
                return;
            }

            Student student_data = new Student
            {
                RegNo = reg_no,
                FirstName = text_box_first_name.Text,
                LastName = text_box_last_name.Text,
                DateOfBirth = date_time_picker_dob.Value,
                Gender = radio_button_male.Checked ? "Male" : "Female",
                Address = text_box_address.Text,
                Email = text_box_email.Text,
                MobilePhone = int.Parse(text_box_mobile.Text),
                HomePhone = int.Parse(text_box_home.Text),
                ParentName = text_box_parent_name.Text,
                NIC = text_box_nic.Text,
                ContactNo = int.Parse(text_box_contact.Text)
            };

            bool result = database_repository.AddNewStudent(student_data);

            if (result)
            {
                FormManager.ShowInformationMessage("Record has been added successfully", "Registration Complete");
                ClearAllFields();
                LoadRegistrationNumbers();
            }
            else
            {
                FormManager.ShowErrorMessage("Failed to register student", "Registration Error");
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string reg_no_text = combo_box_reg_no.Text;
            if (string.IsNullOrWhiteSpace(reg_no_text) || !int.TryParse(reg_no_text, out int reg_no))
            {
                FormManager.ShowWarningMessage("Please select a valid registration number", "Validation Error");
                return;
            }

            var required_fields = new[] { text_box_first_name, text_box_last_name, text_box_address, 
                                         text_box_email, text_box_mobile, text_box_home, text_box_parent_name, 
                                         text_box_nic, text_box_contact };
            
            if (required_fields.Any(t => string.IsNullOrWhiteSpace(t.Text)))
            {
                FormManager.ShowWarningMessage("Please fill in all required fields", "Validation Error");
                return;
            }

            Student student_data = new Student
            {
                RegNo = reg_no,
                FirstName = text_box_first_name.Text,
                LastName = text_box_last_name.Text,
                DateOfBirth = date_time_picker_dob.Value,
                Gender = radio_button_male.Checked ? "Male" : "Female",
                Address = text_box_address.Text,
                Email = text_box_email.Text,
                MobilePhone = int.Parse(text_box_mobile.Text),
                HomePhone = int.Parse(text_box_home.Text),
                ParentName = text_box_parent_name.Text,
                NIC = text_box_nic.Text,
                ContactNo = int.Parse(text_box_contact.Text)
            };

            bool result = database_repository.ModifyStudentRecord(student_data);

            if (result)
            {
                FormManager.ShowInformationMessage("Record has been updated successfully", "Update Complete");
                ClearAllFields();
            }
            else
            {
                FormManager.ShowErrorMessage("Failed to update student record", "Update Error");
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string reg_no_text = combo_box_reg_no.Text;
            if (string.IsNullOrWhiteSpace(reg_no_text) || !int.TryParse(reg_no_text, out int reg_no))
            {
                FormManager.ShowWarningMessage("Please select a valid registration number", "Validation Error");
                return;
            }

            bool confirmation = FormManager.ShowConfirmationDialog(
                "Are you sure you want to delete this student record?", 
                "Confirm Deletion");

            if (confirmation)
            {
                bool result = database_repository.RemoveStudent(reg_no);

                if (result)
                {
                    FormManager.ShowInformationMessage("Record has been deleted successfully", "Deletion Complete");
                    ClearAllFields();
                    LoadRegistrationNumbers();
                }
                else
                {
                    FormManager.ShowErrorMessage("Failed to delete student record", "Deletion Error");
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            combo_box_reg_no.ResetText();
            text_box_first_name.ResetText();
            text_box_last_name.ResetText();
            date_time_picker_dob.Value = DateTime.Now;
            radio_button_male.Checked = true;
            text_box_address.ResetText();
            text_box_email.ResetText();
            text_box_mobile.ResetText();
            text_box_home.ResetText();
            text_box_parent_name.ResetText();
            text_box_nic.ResetText();
            text_box_contact.ResetText();
        }

        private void combo_box_reg_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_reg_no_text = combo_box_reg_no.Text;
            if (!string.IsNullOrEmpty(selected_reg_no_text) && int.TryParse(selected_reg_no_text, out int selected_reg_no))
            {
                Student student_data = database_repository.RetrieveStudentByRegNo(selected_reg_no);
                if (student_data != null)
                {
                    text_box_first_name.Text = student_data.FirstName;
                    text_box_last_name.Text = student_data.LastName;
                    date_time_picker_dob.Value = student_data.DateOfBirth;
                    if (student_data.Gender == "Male")
                        radio_button_male.Checked = true;
                    else
                        radio_button_female.Checked = true;
                    text_box_address.Text = student_data.Address;
                    text_box_email.Text = student_data.Email;
                    text_box_mobile.Text = student_data.MobilePhone.ToString();
                    text_box_home.Text = student_data.HomePhone.ToString();
                    text_box_parent_name.Text = student_data.ParentName;
                    text_box_nic.Text = student_data.NIC;
                    text_box_contact.Text = student_data.ContactNo.ToString();
                }
            }
        }

        private void link_label_logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool confirmation = FormManager.ShowConfirmationDialog(
                "Are you sure you want to logout?", 
                "Confirm Logout");

            if (confirmation)
            {
                LoginForm login_form = new LoginForm();
                login_form.Show();
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            this.group_box_basic_details = new System.Windows.Forms.GroupBox();
            this.date_time_picker_dob = new System.Windows.Forms.DateTimePicker();
            this.radio_button_female = new System.Windows.Forms.RadioButton();
            this.radio_button_male = new System.Windows.Forms.RadioButton();
            this.text_box_last_name = new System.Windows.Forms.TextBox();
            this.text_box_first_name = new System.Windows.Forms.TextBox();
            this.combo_box_reg_no = new System.Windows.Forms.ComboBox();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_dob = new System.Windows.Forms.Label();
            this.label_last_name = new System.Windows.Forms.Label();
            this.label_first_name = new System.Windows.Forms.Label();
            this.label_reg_no = new System.Windows.Forms.Label();
            this.group_box_contact_details = new System.Windows.Forms.GroupBox();
            this.text_box_contact = new System.Windows.Forms.TextBox();
            this.text_box_nic = new System.Windows.Forms.TextBox();
            this.text_box_parent_name = new System.Windows.Forms.TextBox();
            this.text_box_home = new System.Windows.Forms.TextBox();
            this.text_box_mobile = new System.Windows.Forms.TextBox();
            this.text_box_email = new System.Windows.Forms.TextBox();
            this.text_box_address = new System.Windows.Forms.TextBox();
            this.label_contact = new System.Windows.Forms.Label();
            this.label_nic = new System.Windows.Forms.Label();
            this.label_parent_name = new System.Windows.Forms.Label();
            this.label_home = new System.Windows.Forms.Label();
            this.label_mobile = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.button_register = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.link_label_logout = new System.Windows.Forms.LinkLabel();
            this.group_box_basic_details.SuspendLayout();
            this.group_box_contact_details.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_box_basic_details
            // 
            this.group_box_basic_details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.group_box_basic_details.Controls.Add(this.date_time_picker_dob);
            this.group_box_basic_details.Controls.Add(this.radio_button_female);
            this.group_box_basic_details.Controls.Add(this.radio_button_male);
            this.group_box_basic_details.Controls.Add(this.text_box_last_name);
            this.group_box_basic_details.Controls.Add(this.text_box_first_name);
            this.group_box_basic_details.Controls.Add(this.combo_box_reg_no);
            this.group_box_basic_details.Controls.Add(this.label_gender);
            this.group_box_basic_details.Controls.Add(this.label_dob);
            this.group_box_basic_details.Controls.Add(this.label_last_name);
            this.group_box_basic_details.Controls.Add(this.label_first_name);
            this.group_box_basic_details.Controls.Add(this.label_reg_no);
            this.group_box_basic_details.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.group_box_basic_details.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.group_box_basic_details.Location = new System.Drawing.Point(20, 20);
            this.group_box_basic_details.Name = "group_box_basic_details";
            this.group_box_basic_details.Size = new System.Drawing.Size(760, 200);
            this.group_box_basic_details.TabIndex = 0;
            this.group_box_basic_details.TabStop = false;
            this.group_box_basic_details.Text = "Basic Details";
            // 
            // date_time_picker_dob
            // 
            this.date_time_picker_dob.Font = new System.Drawing.Font("Tahoma", 10F);
            this.date_time_picker_dob.Location = new System.Drawing.Point(520, 90);
            this.date_time_picker_dob.Name = "date_time_picker_dob";
            this.date_time_picker_dob.Size = new System.Drawing.Size(220, 24);
            this.date_time_picker_dob.TabIndex = 10;
            // 
            // radio_button_female
            // 
            this.radio_button_female.AutoSize = true;
            this.radio_button_female.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radio_button_female.Location = new System.Drawing.Point(620, 145);
            this.radio_button_female.Name = "radio_button_female";
            this.radio_button_female.Size = new System.Drawing.Size(69, 21);
            this.radio_button_female.TabIndex = 9;
            this.radio_button_female.Text = "Female";
            this.radio_button_female.UseVisualStyleBackColor = true;
            // 
            // radio_button_male
            // 
            this.radio_button_male.AutoSize = true;
            this.radio_button_male.Checked = true;
            this.radio_button_male.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radio_button_male.Location = new System.Drawing.Point(520, 145);
            this.radio_button_male.Name = "radio_button_male";
            this.radio_button_male.Size = new System.Drawing.Size(54, 21);
            this.radio_button_male.TabIndex = 8;
            this.radio_button_male.TabStop = true;
            this.radio_button_male.Text = "Male";
            this.radio_button_male.UseVisualStyleBackColor = true;
            // 
            // text_box_last_name
            // 
            this.text_box_last_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_last_name.Location = new System.Drawing.Point(170, 142);
            this.text_box_last_name.Name = "text_box_last_name";
            this.text_box_last_name.Size = new System.Drawing.Size(220, 24);
            this.text_box_last_name.TabIndex = 7;
            // 
            // text_box_first_name
            // 
            this.text_box_first_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_first_name.Location = new System.Drawing.Point(170, 90);
            this.text_box_first_name.Name = "text_box_first_name";
            this.text_box_first_name.Size = new System.Drawing.Size(220, 24);
            this.text_box_first_name.TabIndex = 6;
            // 
            // combo_box_reg_no
            // 
            this.combo_box_reg_no.Font = new System.Drawing.Font("Tahoma", 10F);
            this.combo_box_reg_no.FormattingEnabled = true;
            this.combo_box_reg_no.Location = new System.Drawing.Point(170, 38);
            this.combo_box_reg_no.Name = "combo_box_reg_no";
            this.combo_box_reg_no.Size = new System.Drawing.Size(220, 24);
            this.combo_box_reg_no.TabIndex = 5;
            this.combo_box_reg_no.SelectedIndexChanged += new System.EventHandler(this.combo_box_reg_no_SelectedIndexChanged);
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_gender.Location = new System.Drawing.Point(420, 147);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(59, 17);
            this.label_gender.TabIndex = 4;
            this.label_gender.Text = "Gender:";
            // 
            // label_dob
            // 
            this.label_dob.AutoSize = true;
            this.label_dob.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_dob.Location = new System.Drawing.Point(420, 95);
            this.label_dob.Name = "label_dob";
            this.label_dob.Size = new System.Drawing.Size(91, 17);
            this.label_dob.TabIndex = 3;
            this.label_dob.Text = "Date of Birth:";
            // 
            // label_last_name
            // 
            this.label_last_name.AutoSize = true;
            this.label_last_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_last_name.Location = new System.Drawing.Point(30, 145);
            this.label_last_name.Name = "label_last_name";
            this.label_last_name.Size = new System.Drawing.Size(79, 17);
            this.label_last_name.TabIndex = 2;
            this.label_last_name.Text = "Last Name:";
            // 
            // label_first_name
            // 
            this.label_first_name.AutoSize = true;
            this.label_first_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_first_name.Location = new System.Drawing.Point(30, 93);
            this.label_first_name.Name = "label_first_name";
            this.label_first_name.Size = new System.Drawing.Size(81, 17);
            this.label_first_name.TabIndex = 1;
            this.label_first_name.Text = "First Name:";
            // 
            // label_reg_no
            // 
            this.label_reg_no.AutoSize = true;
            this.label_reg_no.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_reg_no.Location = new System.Drawing.Point(30, 41);
            this.label_reg_no.Name = "label_reg_no";
            this.label_reg_no.Size = new System.Drawing.Size(63, 17);
            this.label_reg_no.TabIndex = 0;
            this.label_reg_no.Text = "Reg No.:";
            // 
            // group_box_contact_details
            // 
            this.group_box_contact_details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.group_box_contact_details.Controls.Add(this.text_box_contact);
            this.group_box_contact_details.Controls.Add(this.text_box_nic);
            this.group_box_contact_details.Controls.Add(this.text_box_parent_name);
            this.group_box_contact_details.Controls.Add(this.text_box_home);
            this.group_box_contact_details.Controls.Add(this.text_box_mobile);
            this.group_box_contact_details.Controls.Add(this.text_box_email);
            this.group_box_contact_details.Controls.Add(this.text_box_address);
            this.group_box_contact_details.Controls.Add(this.label_contact);
            this.group_box_contact_details.Controls.Add(this.label_nic);
            this.group_box_contact_details.Controls.Add(this.label_parent_name);
            this.group_box_contact_details.Controls.Add(this.label_home);
            this.group_box_contact_details.Controls.Add(this.label_mobile);
            this.group_box_contact_details.Controls.Add(this.label_email);
            this.group_box_contact_details.Controls.Add(this.label_address);
            this.group_box_contact_details.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.group_box_contact_details.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.group_box_contact_details.Location = new System.Drawing.Point(20, 240);
            this.group_box_contact_details.Name = "group_box_contact_details";
            this.group_box_contact_details.Size = new System.Drawing.Size(760, 280);
            this.group_box_contact_details.TabIndex = 1;
            this.group_box_contact_details.TabStop = false;
            this.group_box_contact_details.Text = "Contact Details";
            // 
            // text_box_contact
            // 
            this.text_box_contact.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_contact.Location = new System.Drawing.Point(520, 230);
            this.text_box_contact.Name = "text_box_contact";
            this.text_box_contact.Size = new System.Drawing.Size(220, 24);
            this.text_box_contact.TabIndex = 13;
            // 
            // text_box_nic
            // 
            this.text_box_nic.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_nic.Location = new System.Drawing.Point(520, 180);
            this.text_box_nic.Name = "text_box_nic";
            this.text_box_nic.Size = new System.Drawing.Size(220, 24);
            this.text_box_nic.TabIndex = 12;
            // 
            // text_box_parent_name
            // 
            this.text_box_parent_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_parent_name.Location = new System.Drawing.Point(520, 130);
            this.text_box_parent_name.Name = "text_box_parent_name";
            this.text_box_parent_name.Size = new System.Drawing.Size(220, 24);
            this.text_box_parent_name.TabIndex = 11;
            // 
            // text_box_home
            // 
            this.text_box_home.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_home.Location = new System.Drawing.Point(170, 230);
            this.text_box_home.Name = "text_box_home";
            this.text_box_home.Size = new System.Drawing.Size(220, 24);
            this.text_box_home.TabIndex = 10;
            // 
            // text_box_mobile
            // 
            this.text_box_mobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_mobile.Location = new System.Drawing.Point(170, 180);
            this.text_box_mobile.Name = "text_box_mobile";
            this.text_box_mobile.Size = new System.Drawing.Size(220, 24);
            this.text_box_mobile.TabIndex = 9;
            // 
            // text_box_email
            // 
            this.text_box_email.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_email.Location = new System.Drawing.Point(170, 130);
            this.text_box_email.Name = "text_box_email";
            this.text_box_email.Size = new System.Drawing.Size(220, 24);
            this.text_box_email.TabIndex = 8;
            // 
            // text_box_address
            // 
            this.text_box_address.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text_box_address.Location = new System.Drawing.Point(170, 40);
            this.text_box_address.Multiline = true;
            this.text_box_address.Name = "text_box_address";
            this.text_box_address.Size = new System.Drawing.Size(570, 60);
            this.text_box_address.TabIndex = 7;
            // 
            // label_contact
            // 
            this.label_contact.AutoSize = true;
            this.label_contact.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_contact.Location = new System.Drawing.Point(420, 233);
            this.label_contact.Name = "label_contact";
            this.label_contact.Size = new System.Drawing.Size(83, 17);
            this.label_contact.TabIndex = 6;
            this.label_contact.Text = "Contact No.:";
            // 
            // label_nic
            // 
            this.label_nic.AutoSize = true;
            this.label_nic.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_nic.Location = new System.Drawing.Point(420, 183);
            this.label_nic.Name = "label_nic";
            this.label_nic.Size = new System.Drawing.Size(35, 17);
            this.label_nic.TabIndex = 5;
            this.label_nic.Text = "NIC:";
            // 
            // label_parent_name
            // 
            this.label_parent_name.AutoSize = true;
            this.label_parent_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_parent_name.Location = new System.Drawing.Point(420, 133);
            this.label_parent_name.Name = "label_parent_name";
            this.label_parent_name.Size = new System.Drawing.Size(94, 17);
            this.label_parent_name.TabIndex = 4;
            this.label_parent_name.Text = "Parent Name:";
            // 
            // label_home
            // 
            this.label_home.AutoSize = true;
            this.label_home.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_home.Location = new System.Drawing.Point(30, 233);
            this.label_home.Name = "label_home";
            this.label_home.Size = new System.Drawing.Size(95, 17);
            this.label_home.TabIndex = 3;
            this.label_home.Text = "Home Phone:";
            // 
            // label_mobile
            // 
            this.label_mobile.AutoSize = true;
            this.label_mobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_mobile.Location = new System.Drawing.Point(30, 183);
            this.label_mobile.Name = "label_mobile";
            this.label_mobile.Size = new System.Drawing.Size(98, 17);
            this.label_mobile.TabIndex = 2;
            this.label_mobile.Text = "Mobile Phone:";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_email.Location = new System.Drawing.Point(30, 133);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(45, 17);
            this.label_email.TabIndex = 1;
            this.label_email.Text = "Email:";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label_address.Location = new System.Drawing.Point(30, 43);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(63, 17);
            this.label_address.TabIndex = 0;
            this.label_address.Text = "Address:";
            // 
            // button_register
            // 
            this.button_register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(181)))), ((int)(((byte)(253)))));
            this.button_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_register.Font = new System.Drawing.Font("Tahoma", 10F);
            this.button_register.ForeColor = System.Drawing.Color.White;
            this.button_register.Location = new System.Drawing.Point(70, 550);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(140, 45);
            this.button_register.TabIndex = 2;
            this.button_register.Text = "Register";
            this.button_register.UseVisualStyleBackColor = false;
            this.button_register.Click += new System.EventHandler(this.button_register_Click);
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(181)))), ((int)(((byte)(253)))));
            this.button_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_update.Font = new System.Drawing.Font("Tahoma", 10F);
            this.button_update.ForeColor = System.Drawing.Color.White;
            this.button_update.Location = new System.Drawing.Point(240, 550);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(140, 45);
            this.button_update.TabIndex = 3;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(231)))), ((int)(((byte)(183)))));
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.Font = new System.Drawing.Font("Tahoma", 10F);
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(410, 550);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(140, 45);
            this.button_delete.TabIndex = 4;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(231)))), ((int)(((byte)(183)))));
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.Font = new System.Drawing.Font("Tahoma", 10F);
            this.button_clear.ForeColor = System.Drawing.Color.White;
            this.button_clear.Location = new System.Drawing.Point(580, 550);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(140, 45);
            this.button_clear.TabIndex = 5;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // link_label_logout
            // 
            this.link_label_logout.AutoSize = true;
            this.link_label_logout.Font = new System.Drawing.Font("Tahoma", 10F);
            this.link_label_logout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(181)))), ((int)(((byte)(253)))));
            this.link_label_logout.Location = new System.Drawing.Point(730, 5);
            this.link_label_logout.Name = "link_label_logout";
            this.link_label_logout.Size = new System.Drawing.Size(50, 17);
            this.link_label_logout.TabIndex = 6;
            this.link_label_logout.TabStop = true;
            this.link_label_logout.Text = "Logout";
            this.link_label_logout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_label_logout_LinkClicked);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.link_label_logout);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_register);
            this.Controls.Add(this.group_box_contact_details);
            this.Controls.Add(this.group_box_basic_details);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Management System - Registration";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.group_box_basic_details.ResumeLayout(false);
            this.group_box_basic_details.PerformLayout();
            this.group_box_contact_details.ResumeLayout(false);
            this.group_box_contact_details.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox group_box_basic_details;
        private System.Windows.Forms.DateTimePicker date_time_picker_dob;
        private System.Windows.Forms.RadioButton radio_button_female;
        private System.Windows.Forms.RadioButton radio_button_male;
        private System.Windows.Forms.TextBox text_box_last_name;
        private System.Windows.Forms.TextBox text_box_first_name;
        private System.Windows.Forms.ComboBox combo_box_reg_no;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.Label label_dob;
        private System.Windows.Forms.Label label_last_name;
        private System.Windows.Forms.Label label_first_name;
        private System.Windows.Forms.Label label_reg_no;
        private System.Windows.Forms.GroupBox group_box_contact_details;
        private System.Windows.Forms.TextBox text_box_contact;
        private System.Windows.Forms.TextBox text_box_nic;
        private System.Windows.Forms.TextBox text_box_parent_name;
        private System.Windows.Forms.TextBox text_box_home;
        private System.Windows.Forms.TextBox text_box_mobile;
        private System.Windows.Forms.TextBox text_box_email;
        private System.Windows.Forms.TextBox text_box_address;
        private System.Windows.Forms.Label label_contact;
        private System.Windows.Forms.Label label_nic;
        private System.Windows.Forms.Label label_parent_name;
        private System.Windows.Forms.Label label_home;
        private System.Windows.Forms.Label label_mobile;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.LinkLabel link_label_logout;
    }
}
