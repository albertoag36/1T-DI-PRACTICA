using System.ComponentModel;

namespace ListaDeTareas.MVVM.Models
{
    public class Tarea : INotifyPropertyChanged
    {
        private string Nombre = string.Empty;
        public string nombre
        {
            get => Nombre;
            set
            {
                if (Nombre != value)
                {
                    Nombre = value;
                    OnPropertyChanged(nameof(nombre));
                }
            }
        }

        private bool Completada;
        public bool completada
        {
            get => Completada;
            set
            {
                if (Completada != value)
                {
                    Completada = value;
                    OnPropertyChanged(nameof(completada));
                }
            }
        }

        private int Importancia;
        public int importancia
        {
            get => Importancia;
            set
            {
                if (Importancia != value)
                {
                    Importancia = value;
                    OnPropertyChanged(nameof(importancia));
                    OnPropertyChanged(nameof(TextoPrioridad));
                }
            }
        }

        public string TextoPrioridad => importancia switch
        {
            0 => "Sin prioridad",
            1 => "Prioridad baja",
            2 => "Prioridad media",
            3 => "Prioridad alta",
            _ => "Sin prioridad",
        };

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
