namespace Dialog.Prompt
{
    public static class Prompt
    {
        public static string? ShowDialog(string text, string caption)
        {
            System.Windows.Forms.Form prompt = new System.Windows.Forms.Form();
            prompt.Height = 150;
            prompt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label();
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Text = text;
            textLabel.TextAlign = ContentAlignment.TopCenter;
            textLabel.AutoSize = true;
            //textLabel.Padding = new Padding(6);

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Left = 20;
            textBox.Top = 40;
            textBox.Width = prompt.Width - 60;//200;

            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button();
            confirmation.Text = "Confirm";
            confirmation.Left = ((textBox.Width - confirmation.Width) / 2) - (confirmation.Width/2);
            confirmation.Width = 80;
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

            System.Windows.Forms.Button cancel = new System.Windows.Forms.Button();
            cancel.Text = "Cancel";
            cancel.Left = ((textBox.Width - confirmation.Width) / 2) + (cancel.Width / 2) + 20;
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
            prompt.AutoSize = true;
            //prompt.Width = text.Length*5;


            System.Windows.Forms.DialogResult result = prompt.ShowDialog();
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