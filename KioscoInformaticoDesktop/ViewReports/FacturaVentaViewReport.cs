using KioscoInformaticoServices.Interfaces;
using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioscoInformaticoDesktop.Reports
{
    public partial class FacturaVentaViewReport : Form
    {
        ReportViewer reporte;
        IGenericService<DetalleVenta> detallesService = new GenericService<DetalleVenta>();
        IGenericService<Venta> ventaService = new GenericService<Venta>();
        private Venta? nuevaVenta;

        public FacturaVentaViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;

            Controls.Add(reporte);
        }

        public FacturaVentaViewReport(Venta? nuevaVenta)
        {
            this.nuevaVenta = nuevaVenta;
            InitializeComponent();
            reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;

            Controls.Add(reporte);
        }

        private async void FacturaVentaViewReport_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "KioscoInformaticoDesktop.Reports.FacturaVentaViewReport.rdlc";
           
            var detalles = await detallesService.GetAllAsync();
            var ventas = await ventaService.GetAllAsync();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSVentas", ventas));
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSDetallesVenta", detalles));
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            reporte.ZoomMode = ZoomMode.Percent;
            reporte.RefreshReport();

        }
    }
}

