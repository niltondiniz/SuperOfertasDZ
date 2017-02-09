using PushNotification.Plugin;
using Xamarin.Forms;

namespace SuperOfertas
{
	public partial class App : Application
	{
		public ItemOfertaViewModel vm;
		public MasterPageViewModel masterPageViewModel;
		public OfertaViewModel ofertaViewmModel;
		public OfertaRelampagoViewModel relampagoViewModel;
		public ProdutoCompraViewModel produtoCompraViewModel;


		public App()
		{

			//CrossPushNotification.Current.Register();
			InitializeComponent();


			masterPageViewModel = new MasterPageViewModel();
			ofertaViewmModel = new OfertaViewModel();
			relampagoViewModel = new OfertaRelampagoViewModel();
			vm = new ItemOfertaViewModel();
			produtoCompraViewModel = new ProdutoCompraViewModel();

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
