namespace StudentManagementSystem.Helpers
{
    /// <summary>
    /// Input validation helper class for form validation
    /// Version 5 (Corporate Formal) characteristic - Separate validation class
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates that a TextBox control contains a value
        /// </summary>
        public static bool ValidateTextBoxNotEmpty(TextBox textBoxControl, string fieldDisplayName)
        {
            if (string.IsNullOrWhiteSpace(textBoxControl.Text))
            {
                MessageBox.Show(
                    $"The {fieldDisplayName} field is required and cannot be empty.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBoxControl.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that a ComboBox control has a selected value
        /// </summary>
        public static bool ValidateComboBoxHasSelection(ComboBox comboBoxControl, string fieldDisplayName)
        {
            if (comboBoxControl.SelectedItem == null && string.IsNullOrWhiteSpace(comboBoxControl.Text))
            {
                MessageBox.Show(
                    $"Please select a value for the {fieldDisplayName} field.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                comboBoxControl.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that a RadioButton group has a selection
        /// </summary>
        public static bool ValidateRadioButtonGroupHasSelection(RadioButton firstRadioButton, RadioButton secondRadioButton, string fieldDisplayName)
        {
            if (!firstRadioButton.Checked && !secondRadioButton.Checked)
            {
                MessageBox.Show(
                    $"Please select a value for the {fieldDisplayName} field.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates email format
        /// </summary>
        public static bool ValidateEmailFormat(TextBox emailTextBox, string fieldDisplayName)
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                return true; // Allow empty if not required
            }

            if (!emailTextBox.Text.Contains("@") || !emailTextBox.Text.Contains("."))
            {
                MessageBox.Show(
                    $"The {fieldDisplayName} field must contain a valid email address.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                emailTextBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that all required fields in a form are filled
        /// </summary>
        public static bool ValidateAllRequiredFieldsAreFilled(List<TextBox> requiredTextBoxList, List<string> fieldDisplayNameList)
        {
            for (int index = 0; index < requiredTextBoxList.Count; index++)
            {
                if (!ValidateTextBoxNotEmpty(requiredTextBoxList[index], fieldDisplayNameList[index]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
