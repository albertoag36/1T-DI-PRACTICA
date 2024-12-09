using ListaDeTareas.MVVM.Models;
using ListaDeTareas.MVVM.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ListaDeTareas.MVVM.ViewModels
{
    public class TareaViewModel
    {
        public ObservableCollection<Tarea> Tareas { get; set; } = new ObservableCollection<Tarea>();

        public ICommand TareaClickCommand => new Command<Tarea>(async (tareaSeleccionada) =>
        {
            if (tareaSeleccionada != null)
            {
                var navigation = Application.Current!.MainPage!.Navigation;
                if (navigation != null)
                {
                    await navigation.PushAsync(new TareaDetalleView
                    {
                        BindingContext = new TareaDetalleViewModel
                        {
                            Tarea = tareaSeleccionada
                        }
                    });
                }
            }
        });

        public void OrdenarPorPrioridad()
        {
            var tareasOrdenadas = Tareas.OrderByDescending(t => t.importancia).ToList();
            Tareas.Clear();
            foreach (var tarea in tareasOrdenadas)
            {
                Tareas.Add(tarea);
            }
        }
    }
}
