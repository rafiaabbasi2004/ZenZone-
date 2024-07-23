using System.Data.SqlClient;
using System.Threading.Tasks;

public class DataAccess
{
    private readonly string _connectionString;

    public DataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<User> ValidateUserAsync(string email, string password)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            string query = "SELECT FirstName, Email FROM User_info WHERE email = @Email AND password = @Password";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            FirstName = reader.GetString(0),
                            Email = reader.GetString(1),
                          
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }

    public async Task SaveContactMessageAsync(string name, string email, string message)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO ContactMessages (Name, Email, Message, CreatedAt) VALUES (@name, @email, @message, @createdAt)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@message", message);
                    command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions here
            Console.WriteLine($"Error saving contact message: {ex.Message}");
            throw; // Rethrow the exception to indicate failure
        }
    }

}

public class User
{
    public string FirstName { get; set; }
    public string Email { get; set; }

}
