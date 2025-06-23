//
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace NightreignSaveManager.Helpers
{
    internal static class Prompt
    {
        internal static string ShowDialog(string text, string caption)
        {
            string result = null;

            Form prompt = new Form();
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;

            Label textLabel = new Label();
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Text = text;
            textLabel.AutoSize = true;

            TextBox textBox = new TextBox();
            textBox.Left = 20;
            textBox.Top = 40;
            textBox.Width = prompt.Width - 60;

            Button confirmation = new Button();
            confirmation.Text = "Confirm";
            confirmation.Width = 80;
            confirmation.Left = (prompt.Width / 2) - confirmation.Width - 10;
            confirmation.Top = 80;
            confirmation.Click += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    result = textBox.Text;
                    prompt.DialogResult = DialogResult.OK;
                    prompt.Close();
                }
                else
                {
                    MessageBox.Show("The name field cannot be empty.");
                }
            };

            Button cancel = new Button();
            cancel.Text = "Cancel";
            cancel.Left = confirmation.Left + confirmation.Width + 10;
            cancel.Width = 80;
            cancel.Top = 80;
            cancel.Click += (sender, e) =>
            {
                prompt.DialogResult = DialogResult.Cancel;
                prompt.Close();
            };
            
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.MinimizeBox = false;
            prompt.MaximizeBox = false;
            prompt.AutoSize = false;

            var dialogResult = prompt.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}