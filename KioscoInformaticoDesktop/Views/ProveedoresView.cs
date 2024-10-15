using KioscoInformaticoServices.Enums;
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
    public partial class ProveedoresView : Form
    {
        IGenericService<Proveedor> proveedorService = new GenericService<Proveedor>();
        ILocalidadService localidadService = new LocalidadService();

        BindingSource listaProveedores = new BindingSource();
        List<Proveedor> listaAFiltrar = new List<Proveedor>();

        Proveedor proveedorCurrent;
        public ProveedoresView()
        {
            InitializeComponent();
            dataGridProveedores.DataSource = listaProveedores;
            CargarGrilla();
            CargarCombo();
            cboCondicionIva.DataSource = Enum.GetValues(typeof(CondicionIvaEnum));
        }

        private async Task CargarGrilla()
        {
            listaProveedores.DataSource = await proveedorService.GetAllAsync();
            listaAFiltrar = (List<Proveedor>)listaProveedores.DataSource;
            dataGridProveedores.Columns["LocalidadId"].Visible = false;
        }

        private async Task CargarCombo()
        {
            cboLocalidades.DataSource = await localidadService.GetAllAsync();
            cboLocalidades.DisplayMember = "Nombre";
            cboLocalidades.ValueMember = "Id";
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

            if (proveedorCurrent != null)
            {
                proveedorCurrent.Nombre = txtNombre.Text;
                proveedorCurrent.Cbu = txtCbu.Text;
                proveedorCurrent.Direccion = txtDireccion.Text;
                proveedorCurrent.Telefonos = txtTelefonos.Text;
                proveedorCurrent.CondicionIva = (CondicionIvaEnum)cboCondicionIva.SelectedItem;
                proveedorCurrent.LocalidadId = (int?)cboLocalidades.SelectedValue;
                await proveedorService.UpdateAsync(proveedorCurrent);
                proveedorCurrent = null;
            }
            else
            {
                Proveedor nuevoProveedor = new Proveedor()
                {
                    Nombre = txtNombre.Text,
                    Cbu = txtCbu.Text,
                    Direccion = txtDireccion.Text,
                    Telefonos = txtTelefonos.Text,
                    CondicionIva = (CondicionIvaEnum)cboCondicionIva.SelectedItem,
                    LocalidadId = (int?)cboLocalidades.SelectedValue
                };
                await proveedorService.AddAsync(nuevoProveedor);
                await CargarGrilla();
                txtNombre.Text = string.Empty;
                txtCbu.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtTelefonos.Text = string.Empty;
                cboCondicionIva.SelectedIndex = -1;
                cboLocalidades.SelectedIndex = -1;
                tabControl1.SelectedTab = tabPageLista;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            proveedorCurrent = (Proveedor)listaProveedores.Current;
            txtNombre.Text = proveedorCurrent.Nombre;
            txtCbu.Text = proveedorCurrent.Cbu;
            txtDireccion.Text = proveedorCurrent.Direccion;
            txtTelefonos.Text = proveedorCurrent.Telefonos;
            cboCondicionIva.SelectedItem = proveedorCurrent.CondicionIva;
            cboLocalidades.SelectedItem = proveedorCurrent.LocalidadId;
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            proveedorCurrent = (Proveedor)listaProveedores.Current;
            DialogResult respuesta = MessageBox.Show($"Está seguro que quiere eliminar el proveedor {proveedorCurrent.Nombre}?",
                                   "Eliminar proveedor",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                await proveedorService.DeleteAsync(proveedorCurrent.Id);
                proveedorCurrent = null;
                await CargarGrilla();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProveedores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarProveedores();
        }

        public void FiltrarProveedores()
        {
            var proveedoresFlitrados = listaAFiltrar.Where(p => p.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())).ToList();
            listaProveedores.DataSource = proveedoresFlitrados;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            proveedorCurrent = null;
            txtNombre.Text = string.Empty;
            txtCbu.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonos.Text = string.Empty;
            cboCondicionIva.SelectedIndex = -1;
            cboLocalidades.SelectedIndex = -1;
            tabControl1.SelectedTab = tabPageLista;
        }
    }
}
