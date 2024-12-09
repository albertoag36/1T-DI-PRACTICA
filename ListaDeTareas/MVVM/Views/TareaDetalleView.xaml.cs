using ListaDeTareas.MVVM.Models;
using ListaDeTareas.MVVM.ViewModels;

namespace ListaDeTareas.MVVM.Views;

public partial class TareaDetalleView : ContentPage, IQueryAttributable
{
    public TareaDetalleViewModel ViewModel { get; private set; }

    public TareaDetalleView()
    {
        InitializeComponent();

        ViewModel = new TareaDetalleViewModel
        {
            TareaViewModel = App.TareaViewModel!
        };

        BindingContext = ViewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("Tarea") && query["Tarea"] is Tarea tarea)
        {
            ViewModel.Tarea = tarea;
        }
    }

    public async void GuardarTarea(object sender, EventArgs e)
    {
        if (ViewModel.Tarea != null)
        {
            var tareaViewModel = App.TareaViewModel;
            if (tareaViewModel != null)
            {
                var tareaExistente = tareaViewModel.Tareas.FirstOrDefault(t => t.nombre == ViewModel.Tarea.nombre);
                if (tareaExistente != null)
                {
                    tareaExistente.nombre = ViewModel.Tarea.nombre;
                    tareaExistente.completada = ViewModel.Tarea.completada;
                    tareaExistente.importancia = ViewModel.Tarea.importancia;
                }
            }
        }

        await Navigation.PopAsync();
    }

    public async void EliminarTarea(object sender, EventArgs e)
    {
        if (ViewModel.Tarea != null && ViewModel.TareaViewModel != null)
        {
            ViewModel.TareaViewModel.Tareas.Remove(ViewModel.Tarea);
        }

        await Navigation.PopAsync();
    }
}