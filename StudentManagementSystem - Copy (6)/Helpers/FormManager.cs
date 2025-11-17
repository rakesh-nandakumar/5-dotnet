namespace StudentManagementSystem.Helpers
{
    /// <summary>
    /// Form management helper for UI operations
    /// Version 6 (Soft Pastel) characteristic - Form management utilities
    /// </summary>
    public static class FormManager
    {
        public static void ClearAllTextBoxes(Control parent_control)
        {
            var text_boxes = parent_control.Controls.OfType<TextBox>();
            foreach (var text_box in text_boxes)
            {
                text_box.ResetText();
            }
        }

        public static void ClearAllTextBoxesRecursive(Control parent_control)
        {
            foreach (Control control in parent_control.Controls)
            {
                if (control is TextBox text_box)
                {
                    text_box.ResetText();
                }
                else if (control.Controls.Count > 0)
                {
                    ClearAllTextBoxesRecursive(control);
                }
            }
        }

        public static bool ValidateRequiredFields(params TextBox[] text_boxes)
        {
            return text_boxes.Any(tb => string.IsNullOrWhiteSpace(tb.Text));
        }

        public static void ShowInformationMessage(string message, string title = "Information")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarningMessage(string message, string title = "Warning")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowErrorMessage(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ShowConfirmationDialog(string message, string title = "Confirm")
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}
