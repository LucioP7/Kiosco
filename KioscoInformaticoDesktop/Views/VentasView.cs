using KioscoInformaticoDesktop.Reports;
using KioscoInformaticoServices.Enums;
using KioscoInformaticoServices.Interfaces;
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
        IGenericService<Venta> ventaService = new GenericService<Venta>();
        Venta venta = new Venta();

        public VentasView()
        {
            InitializeComponent();
            AjustePantalla();
        }

        private async void AjustePantalla()
        {
            #region Combo
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

            #endregion

            numPrecio.Value = 0;
            numCantidad.Value = 1;
            GridDetalleVenta.DataSource = venta.DetallesVenta.ToList();
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
            btnAgregar.Enabled = cBProductos.SelectedIndex != -1;
            numCantidad.Value = 1;
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
            var detalleVenta = new DetalleVenta
            {
                Producto = (Producto)cBProductos.SelectedItem,
                ProductoId = (int)cBProductos.SelectedValue,
                Cantidad = (int)numCantidad.Value,
                PrecioUnitario = numPrecio.Value
            };
            venta.DetallesVenta.Add(detalleVenta);
            GridDetalleVenta.DataSource = venta.DetallesVenta.ToList();
            cBProductos.SelectedIndex = -1;
            cBProductos.Focus();
            ActualizarTotalFactura();
        }

        private void ActualizarTotalFactura()
        {
            numTotal.Value = venta.DetallesVenta.Sum(dv => dv.Subtotal);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (GridDetalleVenta.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un detalle de venta");
                return;
            }
            var detalleVenta = (DetalleVenta)GridDetalleVenta.CurrentRow.DataBoundItem;
            venta.DetallesVenta.Remove(detalleVenta);
            GridDetalleVenta.DataSource = venta.DetallesVenta.ToList();
            ActualizarTotalFactura();
        }

        private void GridDetalleVenta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridDetalleVenta.OcultarColumnas(new string[] { "Id", "VentaId", "ProductoId", "Eliminado", "Venta" });
            btnQuitar.Enabled = GridDetalleVenta.RowCount > 0;
        }

        private async void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            venta.ClienteId = (int)cBClientes.SelectedValue;
            venta.Fecha = DateTime.Now;
            venta.FormaPago = (FormaDePagoEnum)cBFormasPago.SelectedItem;
            venta.Total = numTotal.Value;
            venta.Iva = venta.Total * 0.21m;
            venta.Cliente = null;
            venta.DetallesVenta.ToList().ForEach(dv => dv.Producto = null);
            venta.DetallesVenta.ToList().ForEach(dv => dv.Venta = null);
            var nuevaVenta = await ventaService.AddAsync(venta);
            var facturaVentaViewReport = new FacturaVentaViewReport(nuevaVenta);
            facturaVentaViewReport.ShowDialog();
        }
    }
}
