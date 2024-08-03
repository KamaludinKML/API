using System.Data;
using MySql.Data.MySqlClient;

public class DbManager 
{
    private readonly string connectionString;
    private readonly MySqlConnection _connection;
    public DbManager(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(connectionString);

    }

    public List<User>GetAllUser()
    {
        List<User> userList = new List<User>();
        try
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            {
                string query = "SELECT * FROM user ";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                        id = Convert.ToInt32(reader["Id"]),
                        nama = reader["Nama"].ToString(),
                        username = reader["Usernamew"].ToString(),
                        password = reader["Password"].ToString(),
                        alamat = reader["Alamat"].ToString(),
                        nohp = reader["Nohp"].ToString(),
                        role = reader["Role"].ToString(),
                        };
                        userList.Add(user);
                    }                  
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return userList;
    }
}