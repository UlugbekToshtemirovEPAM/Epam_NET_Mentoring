namespace HelloUser_MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            var username = UserNameEntry.Text;
            string greeting = $"Hello, {username}. Current date and time: {DateTime.Now}";
            SubmitButton.Text = greeting;
        }
    }
}
