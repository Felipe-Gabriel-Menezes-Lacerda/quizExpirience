using quizExpirience.Pages;

namespace quizExpirience
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SecureStorage.RemoveAll();
            SecureStorage.SetAsync("partial", "0");
        }

        private async void RedirectToQuizButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Question1());
        }

    }

}
