using KioscoInformaticoServices.Enums;
using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioscoInformaticoDesktop.Views
{
    public partial class VentasView : Form
    {
        ClienteService clienteService = new ClienteService();
        ProductoService productoService = new ProductoService();
        Venta Venta = new Venta();

        public VentasView()
        {
            InitializeComponent();
            CargarCombos();
        }

        private async void CargarCombos()
        {
            Stopwatch reloj = new Stopwatch();
            reloj.Start();
            var clienteTask = clienteService.GetAllAsync();
            var productoTask = productoService.GetAllAsync();

            await Task.WhenAll(clienteTask, productoTask);

            cBClientes.DataSource = clienteTask.Result;
            cBClientes.DisplayMember = "Nombre";
            cBClientes.ValueMember = "Id";

            cBProductos.DataSource = productoTask.Result;
            cBProductos.DisplayMember = "Nombre";
            cBProductos.ValueMember = "Id";
            cBProductos.SelectedIndex = -1;

            cBFormasPago.DataSource = Enum.GetValues(typeof(FormaDePagoEnum));
            reloj.Stop();
            Debug.Print($"CargarCombos: {reloj.ElapsedMilliseconds} ms");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBProductos.SelectedIndex != -1)
            {
                Producto producto = (Producto)cBProductos.SelectedItem;
                numPrecio.Value = producto.Precio;
            }
            else if (cBProductos.SelectedIndex == -1)
            {
                numPrecio.Value = 0;
            }
            GridDetalleVenta.DataSource = Venta.DetallesVenta.ToList();
            numCantidad.Value = 1;
            GridDetalleVenta.OcultarColumnas(new string[] { "Id", "VentaId", "ProductoId", "Eliminado", "Venta" });
        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            numSubTotal.Value = numPrecio.Value * numCantidad.Value;
        }

        private void numPrecio_ValueChanged(object sender, EventArgs e)
        {
            numSubTotal.Value = numPrecio.Value * numCantidad.Value;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var DetalleVenta = new DetalleVenta
            {
                Producto = (Producto)cBProductos.SelectedItem,
                ProductoId = (int)cBProductos.SelectedValue,
                Cantidad = (int)numCantidad.Value,
                PrecioUnitario = numPrecio.Value
            };
            Venta.DetallesVenta.Add(DetalleVenta);
            GridDetalleVenta.DataSource = Venta.DetallesVenta.ToList();
            GridDetalleVenta.OcultarColumnas(new string[] { "Id", "VentaId", "ProductoId", "Eliminado", "Venta" });
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
           var detalleVenta = (DetalleVenta)GridDetalleVenta.CurrentRow.DataBoundItem;
            Venta.DetallesVenta.Remove(detalleVenta);
            GridDetalleVenta.DataSource = Venta.DetallesVenta.ToList();
            GridDetalleVenta.OcultarColumnas(new string[] { "Id", "VentaId", "ProductoId", "Eliminado", "Venta" });
        }

        private void GridDetalleVenta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }
}
