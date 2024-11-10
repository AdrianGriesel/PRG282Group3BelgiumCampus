using System;
using System.Drawing;
using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        //prompts formatting
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

        //ok button formatting
        Button confirmation = new Button()
        {
            Text = "OK",
            Left = 120,
            Width = 80,
            Height = 30,
            Top = 100,
            BackColor = Color.LightBlue
        };

        //cancel button formatting
        Button cancel = new Button()
        {
            Text = "Cancel",
            Left = 220,
            Width = 80,
            Height = 30,
            Top = 100,
            BackColor = Color.LightGray
        };

        //adding event handlers to the confirmation and cancel buttons
        confirmation.Click += ConfirmPrompt;
        cancel.Click += CancelPrompt;

        //event handler for the confirmation and cancel buttons
        void ConfirmPrompt(object sender, EventArgs e)
        {
            //setting dialog result to OK and closeing the prompt
            prompt.DialogResult = DialogResult.OK;
            prompt.Close();
        }

        void CancelPrompt(object sender, EventArgs e)
        {
            prompt.DialogResult = DialogResult.Cancel;
            prompt.Close();
        }

        //adding controls to the prompt form
        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(inputBox);
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(cancel);

        //setting the default buttons for:
        prompt.AcceptButton = confirmation;//enter
        prompt.CancelButton = cancel;//escape

        //showing the dialog and getting the result
        var dialogResult = prompt.ShowDialog();


        //checking the result and returning the input text if confirmed, otherwise returning null
        if (dialogResult == DialogResult.OK)
        {
            return inputBox.Text;
        }
        else
        {
            return null;
        }
    }
}
