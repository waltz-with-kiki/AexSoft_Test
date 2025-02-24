using AexSoft_Test.Services.Interfaces;
using AexSoft_Test.ViewModels;

namespace AexSoft_Test.Views;

public partial class MoviePage : ContentPage
{
	public MoviePage()
	{
		InitializeComponent();
        BindingContext = new MovieViewModel(App.services.GetRequiredService<IDatabaseService>());
    }
}