//Librerias del ADO .NET
using System.Data.SqlClient;
using System.Data;
using ConsoleApp;

class Conection
{
    // Cadena de conexión a la base de datos
    public static string connectionString = "Data Source=LAB1504-26\\SQLEXPRESS;Initial Catalog=tecsup2023db;User ID=usertecsup;Password=123456";


    static void Main()
    {

        DataTable dt = new DataTable();
        dt = ListarTrabajadoresDataTable();

        Console.WriteLine("Forma Desconectada");

        foreach (DataRow dr in dt.Rows)
        {

            foreach ( var empleado in dr.ItemArray )
            {

                Console.WriteLine(empleado);

            }

        }
    
        foreach (var empleado in ListarTrabajadoresListaObjetos())
        {

            Console.WriteLine(empleado);

        }

    }

    //De forma desconectada
    private static DataTable ListarTrabajadoresDataTable()
    {
        // Crear un DataTable para almacenar los resultados
        DataTable dataTable = new DataTable();
        // Crear una conexión a la base de datos
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT * FROM Trabajadores";

            // Crear un adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            // Llenar el DataTable con los datos de la consulta
            adapter.Fill(dataTable);

            // Cerrar la conexión
            connection.Close();

        }
        return dataTable;
    }

    //De forma conectada
    private static List<Trabajador> ListarTrabajadoresListaObjetos()
    {
        List<Trabajador> trabajadores = new List<Trabajador>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT id_trabajador, nombre, apellidos, sueldo, fecha_nacimiento FROM Trabajadores";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Verificar si hay filas
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Leer los datos de cada fila

                            trabajadores.Add(new Trabajador
                            {
                                id_trabajador = (int)reader["Id Trabajador"],
                                nombres = reader["Nombre"].ToString(),
                                apellidos = reader["Cargo"].ToString(),
                                sueldo = (decimal)reader["Sueldo"],
                                fecha_nacimiento = reader["Fecha de nacimiento"].ToString()
                            });

                        }
                    }
                }
            }

            // Cerrar la conexión
            connection.Close();


        }
        return trabajadores;

    }


}
