using System.Data.SqlClient;
namespace CRUD_CONTACTO.Datos
{
    public class Conexion
    {
        private string cadenaSLQ = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSLQ = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSLQ;
        }
    }
}
