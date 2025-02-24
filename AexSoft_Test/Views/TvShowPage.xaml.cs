using AexSoft_Test.Services.Interfaces;
using AexSoft_Test.ViewModels;

namespace AexSoft_Test.Views;

public partial class TvShowPage : ContentPage
{
	public TvShowPage()
	{
		InitializeComponent();
        BindingContext = new TvShowViewModel(App.services.GetRequiredService<IDatabaseService>());
    }
}