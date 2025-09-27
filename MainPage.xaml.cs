namespace QuoteGenerator
{
    public partial class MainPage : ContentPage
    {

		private List<string> quotes;

		public MainPage()
        {
            InitializeComponent();
			quotes = new List<string>();
			LoadQuotes();
		}


		private async void LoadQuotes()
		{
			try
			{
				using var stream = await FileSystem.OpenAppPackageFileAsync("lovequotes.txt");
				using var reader = new StreamReader(stream);

				string line;
				while ((line = reader.ReadLine()) != null)
				{
					if (!string.IsNullOrWhiteSpace(line))
					{
						quotes.Add(line.Trim());
					}
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", $"Failed to load quotes: {ex.Message}", "OK");
			}
		}

		private void btnRandom_Clicked(object sender, EventArgs e)
		{


			if (quotes.Count > 0)
			{
				int index = new Random().Next(quotes.Count);
				lblQuote.Text = quotes[index];
			}
			else
			{
				lblQuote.Text = "No quotes found.";
			}
		}
	}
}
