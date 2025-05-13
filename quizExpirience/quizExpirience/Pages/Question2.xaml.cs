using quizExpirience.Pages;

namespace quizExpirience.Pages;

public partial class Question2 : ContentPage
{
	bool isCheckedRadioButton = false;
	bool isRigthAnswer = false;

	public Question2()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
	}

	private void VerifyAnswerRadioButton(object sender, EventArgs e)
	{
		if (isCheckedRadioButton)
		{
			isCheckedRadioButton = false;
		}
		else
		{
			RadioButton radioButtonOptionSelected = sender as RadioButton;
			string radioButtonOptionValue = radioButtonOptionSelected.Value.ToString();

			if (radioButtonOptionValue.Contains("Certa"))
			{
				isRigthAnswer = true;
			}
			else
			{
				isRigthAnswer = false;
				isCheckedRadioButton = true;
			}

			isCheckedRadioButton = true;
		}
	}

	private async void VerifyAnswerButton(object sender, EventArgs e)
	{
		if (isRigthAnswer)
		{
			try
			{
                string secureStoragePartialValue = Convert.ToString(await SecureStorage.GetAsync("partial"));
                int partial = Convert.ToInt32(secureStoragePartialValue);
                partial = partial + 1;

                await SecureStorage.Default.SetAsync("partial", Convert.ToString(partial));

                await Navigation.PushAsync(new ResultsQuiz());
            } catch(Exception error)
			{
				Console.WriteLine(error);
			}
            
        } else
		{
            await Navigation.PushAsync(new ResultsQuiz());
        }
	}
}