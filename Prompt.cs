using System;
using System.Drawing;
using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 400,
            Height = 250,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen,
            BackColor = Color.LightCyan
        };

        Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
        textLabel.Font = new Font("Arial", 10, FontStyle.Bold);

        TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Height = 25 };

        Button confirmation = new Button()
        {
            Text = "OK",
            Left = 120,
            Width = 80,
            Height = 30,
            Top = 100,
            BackColor = Color.LightBlue
        };

        Button cancel = new Button()
        {
            Text = "Cancel",
            Left = 220,
            Width = 80,
            Height = 30,
            Top = 100,
            BackColor = Color.LightGray
        };

        confirmation.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
        cancel.Click += (sender, e) => { prompt.DialogResult = DialogResult.Cancel; prompt.Close(); };

        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(inputBox);
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(cancel);
        prompt.AcceptButton = confirmation;
        prompt.CancelButton = cancel;

        return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : null;
    }
}
