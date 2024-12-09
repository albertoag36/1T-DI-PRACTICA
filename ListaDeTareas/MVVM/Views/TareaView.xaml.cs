using ListaDeTareas.MVVM.Models;
using ListaDeTareas.MVVM.ViewModels;

namespace ListaDeTareas.MVVM.Views;

public partial class TareaView : ContentPage
{
    public TareaView()
    {
        InitializeComponent();
        BindingContext = App.TareaViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is TareaViewModel viewModel)
        {
            viewModel.OrdenarPorPrioridad();
        }
    }

    private void bt_AgregarTarea(object sender, EventArgs e)
    {
        string nuevoNombre = TaskEntry.Text;

        if (!string.IsNullOrWhiteSpace(nuevoNombre))
        {
            if (BindingContext is TareaViewModel viewModel)
            {
                viewModel.Tareas.Add(new Tarea { nombre = nuevoNombre, completada = false, importancia = 0 });

                viewModel.OrdenarPorPrioridad();

                TaskEntry.Text = string.Empty;
            }
        }
    }
}