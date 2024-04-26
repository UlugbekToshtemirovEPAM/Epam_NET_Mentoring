using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Modul_2_Task_1._2
{
    public partial class UserControl1 : UserControl
    {
        private IContainer components = new Container();

        private Button button1 = new Button()
        {
            Text = "Enter Your Name",
            AutoSize = true,
            Location = new Point(10, 10) // you may need to adjust this
        };

        private void InitializeComponent()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Greeting Application";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 500;
                prompt.Height = 200;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Enter name";
                prompt.StartPosition = FormStartPosition.CenterScreen;

                Label textLabel = new Label() { Left = 50, Top = 20, Text = "Enter your name:" };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };

                confirmation.Click += (_sender, _e) => { prompt.Close(); };

                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.ShowDialog();

                var username = textBox.Text;
                MessageBox.Show(UserGreeting.HelloUser(username), "Greeting");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                button1?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public static class UserGreeting
    {
        public static string HelloUser(string name)
        {
            return $"Hello, {name}";
        }
    }
}