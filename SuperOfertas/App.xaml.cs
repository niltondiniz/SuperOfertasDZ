using Xamarin.Forms;

namespace SuperOfertas
{
	public partial class App : Application
	{
		public ItemOfertaViewModel vm;
		public MasterPageViewModel masterPageViewModel;
		public OfertaViewModel ofertaViewmModel;
		public OfertaRelampagoViewModel relampagoViewModel;


		public App()
		{
			InitializeComponent();

			vm = new ItemOfertaViewModel();
			masterPageViewModel = new MasterPageViewModel();
			ofertaViewmModel = new OfertaViewModel();
			relampagoViewModel = new OfertaRelampagoViewModel();
			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
