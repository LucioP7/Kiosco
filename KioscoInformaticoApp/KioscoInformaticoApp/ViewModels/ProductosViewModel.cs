using KioscoInformaticoApp.Utils;
using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoInformaticoApp.ViewModels
{
    public class ProductosViewModel : ObjectNotification
    {
        private GenericService <Producto> productoService = new GenericService <Producto>();

        private string filtroProductos = string.Empty ;
        public string FiltroProductos
        {
            get { return filtroProductos; }
            set
            {
                if (filtroProductos != value)
                {
                    filtroProductos = value;
                    OnPropertyChanged();
                    _ = FiltrarProducto(); // Filtra automáticamente cuando se cambia el texto
                }
                //filtroProductos = value; OnPropertyChanged();
                //filtroProductosList();
            }
        }
    
        private ObservableCollection<Producto> productos;
        public ObservableCollection<Producto> Productos
        {
            get { return productos; }
            set
            {
                productos = value; OnPropertyChanged();
            }
        }

        private bool activityStart;
        public bool ActivityStart
        {
            get { return activityStart; }
            set { activityStart = value; OnPropertyChanged(); }
        }

        public Command ObtenerProductosCommand { get; }
        public Command FiltrarProductoCommand { get; }

        public List<Producto> productsList;

        public ProductosViewModel()
        {
            ObtenerProductosCommand = new Command(async () => await ObtenerProducto());
            FiltrarProductoCommand = new Command(async () => await FiltrarProducto ());
            ObtenerProducto();
        }

        private async Task ObtenerProducto()
        {
            ActivityStart = true;
            productsList = await productoService.GetAllAsync();
            Productos = new ObservableCollection<Producto>(productsList);
            ActivityStart = false;
        }

        private async Task FiltrarProducto()
        {
            var productosFiltrados = productsList
                .Where(p => p.Nombre.Contains(FiltroProductos, StringComparison.OrdinalIgnoreCase))
                .ToList();
            Productos = new ObservableCollection<Producto>(productosFiltrados);
        }

    }
}
