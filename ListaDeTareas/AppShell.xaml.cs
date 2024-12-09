using ListaDeTareas.MVVM.Views;

namespace ListaDeTareas
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TareaDetalleView), typeof(TareaDetalleView));
        }
    }
}
