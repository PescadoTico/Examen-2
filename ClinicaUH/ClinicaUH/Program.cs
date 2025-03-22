using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClinicaUH;

namespace Examen1
{
    static class Program
    {
        
        static string connectionString = "Server=DESKTOP-1NVGEMG\\MSSQLSERVER01;Database=CLINICAUH;Integrated Security=True;";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

         
            if (ProbarConexion())
            {
                MessageBox.Show("Conexión exitosa a la base de datos.");
            }
            else
            {
                MessageBox.Show("Error en la conexión a la base de datos.");
            }

            Application.Run(new Form1()); 
        }

        static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); 
                    return true; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false; 
            }
        }
    }
}
