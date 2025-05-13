namespace quizExpirience.Pages;

public partial class ResultsQuiz : ContentPage
{
	public ResultsQuiz()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            string secureStoragePartialValue = Convert.ToString(await SecureStorage.GetAsync("partial"));
            
            if(secureStoragePartialValue == "" || secureStoragePartialValue == null)
            {
                secureStoragePartialValue = "0";
                int partialScore = Convert.ToInt32(secureStoragePartialValue);
                int finalResult = partialScore * 2 / 100;

                ResultsLabel.Text = "Você acertou " + finalResult + "% das questões";
            } else
            {
                int partialScore = Convert.ToInt32(secureStoragePartialValue);
                int finalResult = partialScore * 2 / 100;

                ResultsLabel.Text = "Você acertou " + finalResult+ "% das questões";
            }

       

        }
        catch (Exception error)
        {
            Console.WriteLine(error);
        }
       
    }

}