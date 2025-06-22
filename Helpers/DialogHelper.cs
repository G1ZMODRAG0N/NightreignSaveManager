//
namespace NightreignSaveManager.Helpers
{
    internal static class Prompt
    {
        internal static string ShowDialog(string text, string caption)
        {

            Form prompt = new System.Windows.Forms.Form();
            prompt.Height = 150;
            prompt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            Label textLabel = new System.Windows.Forms.Label();
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Text = text;
            textLabel.AutoSize = true;

            TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Left = 20;
            textBox.Top = 40;
            textBox.Width = prompt.Width - 60;//200;

            Button confirmation = new System.Windows.Forms.Button();
            confirmation.Text = "Confirm";
            confirmation.Width = 80;
            confirmation.Left = (prompt.Width / 2) - confirmation.Width - 10;
            confirmation.Top = 80;
            confirmation.Click += (sender, e) => {
                if (textBox.Text.Length <= 0)
                {
                    MessageBox.Show("The rename field cannot be empty.");
                }
                else
                {
                    confirmation.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            };

            Button cancel = new System.Windows.Forms.Button();
            cancel.Text = "Cancel";
            cancel.Left = confirmation.Left + confirmation.Width + 10;
            cancel.Width = 80;
            cancel.Top = 80;
            cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.MinimizeBox = false;
            prompt.MaximizeBox = false;
            prompt.AutoSize = false;

            DialogResult result = prompt.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                
                return textBox.Text;
                
            }
            else
            {
                return null;
            }
        }
    }
}