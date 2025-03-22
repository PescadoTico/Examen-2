using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Examen1
{
    public class Database
    {
        private string connectionString = "Server=DESKTOP-1NVGEMG\\MSSQLSERVER01;Database=CLINICAUH;Integrated Security=True;";

        public DataTable ObtenerPacientes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Pacientes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public bool AgregarPaciente(string nombre, string apellido, string cedula, DateTime fechaNacimiento, string telefono)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Pacientes (Nombre, Apellido, Cedula, FechaNacimiento, Telefono) " +
                               "VALUES (@Nombre, @Apellido, @Cedula, @FechaNacimiento, @Telefono)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Cedula", cedula);
                command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@Telefono", telefono);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0; 
            }
        }


        public bool ActualizarPaciente(int id, string nombre, string apellido, string cedula, DateTime fechaNacimiento, string telefono)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Pacientes SET Nombre=@Nombre, Apellido=@Apellido, Cedula=@Cedula, " +
                               "FechaNacimiento=@FechaNacimiento, Telefono=@Telefono";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Cedula", cedula);
                command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@Telefono", telefono);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Método para eliminar un paciente
        public bool EliminarPaciente(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Pacientes WHERE Id=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
