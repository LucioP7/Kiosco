using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Services;
using KioscoInformaticoServices.Interfaces;

namespace KioscoInformaticoDesktop.Views
{
    public partial class LocalidadesView : Form
    {
        IGenericService<Localidad> localidadService = new GenericService<Localidad>();
        BindingSource listalocalidades = new BindingSource();
        List<Localidad> ListaFiltro = new List<Localidad>();
        Localidad localidadCurrent;

        public LocalidadesView()
        {
            InitializeComponent();
            DataGridLocalidades.DataSource = listalocalidades;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listalocalidades.DataSource = await localidadService.GetAllAsync();
            ListaFiltro = (List<Localidad>)listalocalidades.DataSource;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {

                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                var localidad = new Localidad
                {
                    Nombre = txtNombre.Text
                };

                await localidadService.AddAsync(localidad);
            }

            await CargarGrilla();
            txtNombre.Text = string.Empty;
            tabControl.SelectTab(tabLista);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            localidadCurrent = (Localidad)listalocalidades.Current;
            txtNombre.Text = localidadCurrent.Nombre;
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            localidadCurrent = (Localidad)listalocalidades.Current;
            var result = MessageBox.Show($"¿Está seguro que desea eliminar la localidad {localidadCurrent.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                await localidadService.DeleteAsync(localidadCurrent.Id);
                CargarGrilla();
            }
            localidadCurrent = null;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabLista);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarLocalidades();
        }

        private async void FiltrarLocalidades()
        {
            var localidadesFiltrados = ListaFiltro.Where(p => p.Nombre.Contains(txtFiltro.Text)).ToList();
            listalocalidades.DataSource = localidadesFiltrados;

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalidades();
        }
    }
}
