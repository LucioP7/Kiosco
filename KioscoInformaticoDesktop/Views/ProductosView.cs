using KioscoInformaticoServices.Interfaces;
using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioscoInformaticoDesktop.Views
{
    public partial class ProductosView : Form
    {
        IGenericService<Producto> productoService = new GenericService<Producto>();

        BindingSource listaProductos = new BindingSource();
        List<Producto> listaAFiltrar = new List<Producto>();

        Producto productoCurrent;
        public ProductosView()
        {
            InitializeComponent();
            dataGridProductos.DataSource = listaProductos;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaProductos.DataSource = await productoService.GetAllAsync();
            listaAFiltrar = (List<Producto>)listaProductos.DataSource;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Producto producto = new Producto()
                {
                    Nombre = txtNombre.Text,
                    Precio = numericPrecio.Value
                };
                await productoService.AddAsync(producto);
            }
            await CargarGrilla();
            txtNombre.Text = string.Empty;
            numericPrecio.Value = 0;
            tabControl1.SelectedTab = tabPageLista;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            productoCurrent = (Producto)listaProductos.Current;
            txtNombre.Text = productoCurrent.Nombre;
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            productoCurrent = (Producto)listaProductos.Current;
            DialogResult respuesta = MessageBox.Show($"Está seguro que quiere eliminar el producto {productoCurrent.Nombre}?",
                                   "Eliminar producto",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                await productoService.DeleteAsync(productoCurrent.Id);
                productoCurrent = null;
                await CargarGrilla();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void FiltrarProductos()
        {
            var productosFlitrados = listaAFiltrar.Where(p => p.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())).ToList();
            listaProductos.DataSource = productosFlitrados;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            productoCurrent = null;
            txtNombre.Text = string.Empty;
            numericPrecio.Value = 0;
            tabControl1.SelectedTab = tabPageLista;
        }
    }
}
