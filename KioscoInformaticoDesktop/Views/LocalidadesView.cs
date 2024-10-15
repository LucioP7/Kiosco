using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using KioscoInformaticoServices.Interfaces;
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
    public partial class LocalidadesView : Form
    {
        ILocalidadService localidadService = new LocalidadService();

        BindingSource listaLocalidades = new BindingSource();

        Localidad localidadCurrent;
        public LocalidadesView()
        {
            InitializeComponent();
            dataGridLocalidades.DataSource = listaLocalidades;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaLocalidades.DataSource = await localidadService.GetAllAsync();
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

            if (localidadCurrent != null)
            {
                localidadCurrent.Nombre = txtNombre.Text;
                await localidadService.UpdateAsync(localidadCurrent);
                localidadCurrent = null;
            }
            else
            {
                Localidad localidad = new Localidad()
                {
                    Nombre = txtNombre.Text
                };
                await localidadService.AddAsync(localidad);
            }
            await CargarGrilla();
            txtNombre.Text = string.Empty;
            tabControl1.SelectedTab = tabPageLista;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            localidadCurrent = (Localidad)listaLocalidades.Current;
            txtNombre.Text = localidadCurrent.Nombre;
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            localidadCurrent = (Localidad)listaLocalidades.Current;
            DialogResult respuesta = MessageBox.Show($"Está seguro que quiere eliminar la localidad {localidadCurrent.Nombre}?",
                                   "Eliminar localidad",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                await localidadService.DeleteAsync(localidadCurrent.Id);
                localidadCurrent = null;
                await CargarGrilla();
            }
        }

        private async void FiltrarLocalidades()
        {
            listaLocalidades.DataSource = await localidadService.GetAllAsync(txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //FiltrarLocalidades();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarLocalidades();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            localidadCurrent = null;
            txtNombre.Text = string.Empty;
            tabControl1.SelectedTab = tabPageLista;
        }
    }
}
