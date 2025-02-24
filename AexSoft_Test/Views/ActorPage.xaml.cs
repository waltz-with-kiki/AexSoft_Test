using AexSoft_Test.Services.Interfaces;
using AexSoft_Test.ViewModels;

namespace AexSoft_Test.Views;

public partial class ActorPage : ContentPage
{
	public ActorPage()
	{
		InitializeComponent();
		BindingContext = new ActorsViewModel(App.services.GetRequiredService<IDatabaseService>());
	}
}