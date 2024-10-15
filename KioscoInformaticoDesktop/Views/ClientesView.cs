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
using System.Windows.Controls;
using System.Windows.Forms;

namespace KioscoInformaticoDesktop.Views
{
    public partial class ClientesView : Form
    {
        IClienteService clienteService = new ClienteService();
        ILocalidadService localidadService = new LocalidadService();
        BindingSource listaClientes = new BindingSource();
        List<Cliente> listaAFiltrar = new List<Cliente>();
        Cliente clienteCurrent;
        public ClientesView()
        {
            InitializeComponent();
            dataGridClientes.DataSource = listaClientes;
            CargarGrilla();
            CargarCombo();
        }

        private async Task CargarCombo()
        {
            cboLocalidades.DataSource = await localidadService.GetAllAsync();
            cboLocalidades.DisplayMember = "Nombre";
            cboLocalidades.ValueMember = "Id";
        }

        private async Task CargarGrilla()
        {
            listaClientes.DataSource = await clienteService.GetAllAsync(null);
            listaAFiltrar = (List<Cliente>)listaClientes.DataSource;
            dataGridClientes.Columns["LocalidadId"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tabControlLista.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clienteCurrent != null)
            {
                clienteCurrent.Nombre = txtNombre.Text;
                clienteCurrent.Direccion = txtDireccion.Text;
                clienteCurrent.Telefonos = txtTelefonos.Text;
                clienteCurrent.FechaNacimiento = dateTimeNacimiento.Value;
                clienteCurrent.LocalidadId = (int?)cboLocalidades.SelectedValue;
                await clienteService.UpdateAsync(clienteCurrent);
                clienteCurrent = null;
            }
            else
            {
                Cliente cliente = new Cliente()
                {
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefonos = txtTelefonos.Text,
                    FechaNacimiento = dateTimeNacimiento.Value,
                    LocalidadId = (int?)cboLocalidades.SelectedValue
                };
                await clienteService.AddAsync(cliente);
            }
            await CargarGrilla();
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonos.Text = string.Empty;
            dateTimeNacimiento.Value = DateTime.Now;
            tabControlLista.SelectedTab = tabPageLista;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            clienteCurrent = (Cliente)listaClientes.Current;
            txtNombre.Text = clienteCurrent.Nombre;
            txtDireccion.Text = clienteCurrent.Direccion;
            txtTelefonos.Text = clienteCurrent.Telefonos;
            dateTimeNacimiento.Value = clienteCurrent.FechaNacimiento;
            cboLocalidades.SelectedValue = clienteCurrent.LocalidadId;
            tabControlLista.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            clienteCurrent = (Cliente)listaClientes.Current;
            DialogResult respuesta = MessageBox.Show($"Está seguro que quiere eliminar el cliente {clienteCurrent.Nombre}?",
                                   "Eliminar cliente",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                await clienteService.DeleteAsync(clienteCurrent.Id);
                clienteCurrent = null;
                await CargarGrilla();
            }
        }

        private async void FiltrarClientes()
        {
            var clientesFiltrados = listaAFiltrar.Where(p => p.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())).ToList();
            listaClientes.DataSource = clientesFiltrados;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //FiltrarClientes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clienteCurrent = null;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonos.Text = string.Empty;
            dateTimeNacimiento.Value = DateTime.Now;
            tabControlLista.SelectedTab = tabPageLista;
        }
    }
}
