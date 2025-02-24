using AexSoft_Test.Services.Interfaces;
using AexSoft_Test.ViewModels;

namespace AexSoft_Test.Views;

public partial class GenrePage : ContentPage
{
	public GenrePage()
	{
		InitializeComponent();
        BindingContext = new GenreViewModel(App.services.GetRequiredService<IDatabaseService>());
    }
}