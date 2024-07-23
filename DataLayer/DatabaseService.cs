using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

public class User_info
{

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string DateofBirth { get; set; }


}
public class DatabaseService
{
    private readonly string _connectionString;


    public DatabaseService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");

    }

    public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
    {
        DataTable result = new DataTable();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(result);
                }
            }
        }

        return result;
    }
    public async Task AddUser(User_info users)  // Asynchronous method to insert data
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            string query = "INSERT INTO User_info (Email,FirstName,LastName,DateofBirth,Password) VALUES (@email, @firstn, @lastn, @dob, @password)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@email", users.Email);
                command.Parameters.AddWithValue("@firstn", users.FirstName);
                command.Parameters.AddWithValue("@lastn", users.LastName);
                command.Parameters.AddWithValue("@dob", users.DateofBirth);
                command.Parameters.AddWithValue("@password", users.Password);

                await command.ExecuteNonQueryAsync();  // Execute the query
            }
        }
    }


}
