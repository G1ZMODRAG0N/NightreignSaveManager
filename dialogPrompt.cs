namespace Dialog.Prompt
{
    public static class Prompt
    {
        public static string? ShowDialog(string text, string caption)
        {
            System.Windows.Forms.Form prompt = new System.Windows.Forms.Form();
            prompt.Width = 200;
            prompt.Height = 150;
            prompt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label();
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Text = text;
            textLabel.AutoSize = true;

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Left = 20;
            textBox.Top = 40;
            textBox.Width = 140;

            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button();
            confirmation.Text = "Confirm";
            confirmation.Left = 10;
            confirmation.Width = 80;
            confirmation.Top = 80;
            confirmation.DialogResult = System.Windows.Forms.DialogResult.OK;

            System.Windows.Forms.Button cancel = new System.Windows.Forms.Button();
            cancel.Text = "Cancel";
            cancel.Left = 95;
            cancel.Width = 80;
            cancel.Top = 80;
            cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.MinimizeBox = false;
            prompt.MaximizeBox = false;


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