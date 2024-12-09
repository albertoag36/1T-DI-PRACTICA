using ListaDeTareas.MVVM.ViewModels;
using ListaDeTareas.MVVM.Views;

namespace ListaDeTareas
{
    public partial class App : Application
    {
        public static TareaViewModel? TareaViewModel { get; private set; }
        public App()
        {
            InitializeComponent();
            TareaViewModel = new TareaViewModel();
            MainPage = new NavigationPage(new TareaView());
        }
    }
}
