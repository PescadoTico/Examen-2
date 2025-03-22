using System;
using System.Data;
using System.Windows.Forms;

namespace Examen1
{
    public partial class Form1 : Form
    {
        Database db = new Database();

        public Form1()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            dataGridView2.DataSource = db.ObtenerPacientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool success = db.AgregarPaciente(txtNombre.Text, txtApellido.Text, txtCedula.Text,
                dtpFechaNacimiento.Value, txtTelefono.Text);

            if (success)
            {
                MessageBox.Show("Paciente agregado correctamente.");
                CargarPacientes();
            }
            else
            {
                MessageBox.Show("Error al agregar paciente.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id"].Value);
                bool success = db.ActualizarPaciente(id, txtNombre.Text, txtApellido.Text, txtCedula.Text,
                    dtpFechaNacimiento.Value, txtTelefono.Text);

                if (success)
                {
                    MessageBox.Show("Paciente actualizado correctamente.");
                    CargarPacientes();
                }
                else
                {
                    MessageBox.Show("Error al actualizar paciente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un paciente para actualizar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id"].Value);
                bool success = db.EliminarPaciente(id);

                if (success)
                {
                    MessageBox.Show("Paciente eliminado correctamente.");
                    CargarPacientes();
                }
                else
                {
                    MessageBox.Show("Error al eliminar paciente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un paciente para eliminar.");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarPacientes();
        }
    }
}

