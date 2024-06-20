using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

public class IndexModel : PageModel
{
    public List<(int id, string name)> TableData { get; private set; } = new List<(int id, string name)>();

    public void OnGet()
    {
        var connectionString = "Server=db;Database=mydatabase;User Id=sa;Password=YourStrong!Passw0rd;";

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT id, name FROM example_table", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TableData.Add((reader.GetInt32(0), reader.GetString(1)));
                }
            }
        }
    }
}
