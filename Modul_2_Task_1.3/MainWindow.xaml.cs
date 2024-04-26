using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Modul_2_Task_1._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button button = new Button { Content = "Enter your name" };
            button.Click += Button_Click;
            this.Content = button;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new InputDialog("Enter your name:");
            if (dialog.ShowDialog() == true)
            {
                string name = UserGreeting.HelloUser(dialog.ResponseText);
                MessageBox.Show(name);
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

    public class InputDialog : Window
    {
        public InputDialog(string question)
        {
            this.Title = question;

            Button buttonOk = new Button() { Content = "Ok", IsDefault = true };
            buttonOk.Click += (sender, e) => { this.DialogResult = true; };

            this.Content = new StackPanel
            {
                Children =
                {
                    new Label() { Content = question },
                    (txtUserInput = new TextBox()),
                    buttonOk
                },
            };
        }

        TextBox txtUserInput;

        public string ResponseText
        {
            get { return txtUserInput.Text; }
        }
    }
}