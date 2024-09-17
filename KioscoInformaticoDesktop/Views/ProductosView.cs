using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using KioscoInformaticoServices.Interfaces;
using System.Runtime.CompilerServices;

namespace KioscoInformaticoDesktop.Views
{
    public partial class ProductosView : Form
    {
        IGenericService<Producto> productoService = new GenericService<Producto>();
        BindingSource listaproductos = new BindingSource();
        List<Producto> ListaFiltro = new List<Producto>();
        Producto productoCurrent;

        public ProductosView()
        {
            InitializeComponent();
            DataGridProductos.DataSource = listaproductos;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaproductos.DataSource = await productoService.GetAllAsync();
            DataGridProductos.Columns["Id"].DefaultCellStyle.Format = "N0";
            ListaFiltro = (List<Producto>)listaproductos.DataSource;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {

                MessageBox.Show("Debe ingresar un nombre de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (productoCurrent != null)
            {
                productoCurrent.Nombre = txtNombre.Text;
                productoCurrent.Precio = numericPrecio.Value;
                await productoService.UpdateAsync(productoCurrent);
                productoCurrent = null;

            }
            else
            {
                var producto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = numericPrecio.Value
                };

                await productoService.AddAsync(producto);
            }

            await CargarGrilla();
            txtNombre.Text = string.Empty;
            tabControl.SelectTab(tabLista);
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            productoCurrent = (Producto)listaproductos.Current;
            txtNombre.Text = productoCurrent.Nombre;
            numericPrecio.Value = productoCurrent.Precio;


            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var producto = (Producto)listaproductos.Current;
                await productoService.DeleteAsync(producto.Id);
                CargarGrilla();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private async void FiltrarProductos()
        {
            var productosFiltrados = ListaFiltro.Where(p => p.Nombre.Contains(txtFiltro.Text)).ToList();
            listaproductos.DataSource = productosFiltrados;

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }
    }
}
