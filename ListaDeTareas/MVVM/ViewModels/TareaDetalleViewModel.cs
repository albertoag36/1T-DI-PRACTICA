using ListaDeTareas.MVVM.Models;
using MvvmHelpers;
using System.Windows.Input;

namespace ListaDeTareas.MVVM.ViewModels;

public class TareaDetalleViewModel : BaseViewModel
{
    public TareaViewModel TareaViewModel { get; set; } = new TareaViewModel();
    private Tarea tarea = new Tarea();

    public Tarea Tarea
    {
        get => tarea;
        set
        {
            tarea = value;
            OnPropertyChanged();
        }
    }

    public ICommand EliminarTareaCommand => new Command<Tarea>((tareaSeleccionada) =>
    {
        if (App.TareaViewModel != null && App.TareaViewModel.Tareas.Contains(Tarea))
        {
            App.TareaViewModel.Tareas.Remove(Tarea);
        }
    });
}
