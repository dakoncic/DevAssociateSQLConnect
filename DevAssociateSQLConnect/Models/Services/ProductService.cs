using System.Data.SqlClient;

namespace DevAssociateSQLConnect.Models.Services
{
    public class ProductService
    {
        private static string db_source = "devassociate.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "qwertzuiop1!";
        private static string db_database = "appdb";


        private SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.UserID = db_user;
            builder.Password = db_password;
            builder.InitialCatalog = db_database;
            return new SqlConnection(builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection connection = GetConnection();

            var product_list = new List<Product>();

            string statement = "SELECT ProductID, ProductName, Quantity FROM Products;";

            connection.Open();

            SqlCommand cmd = new SqlCommand(statement, connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    product_list.Add(product);
                }
            }

            connection.Close();
            return product_list;
        }
    }
}
