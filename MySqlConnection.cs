using MySql.Data.MySqlClient;
using DotNetEnv;

namespace Server
{
    class MySQL
    {
        static void Main()
        {
            var stringBuilder = new MySqlConnectionStringBuilder();

            DotNetEnv.Env.Load();
            stringBuilder["Server"] = Environment.GetEnvironmentVariable("DB_SERVER");
            stringBuilder["Port"] = Environment.GetEnvironmentVariable("DB_PORT");
            stringBuilder["Database"] = Environment.GetEnvironmentVariable("DB_DATABASE");
            stringBuilder["User Id"] = Environment.GetEnvironmentVariable("DB_UID");
            stringBuilder["Password"] = Environment.GetEnvironmentVariable("DB_PASSWORD");

            String sqlConnectionString = stringBuilder.ToString();
            
            var connection = new MySqlConnection(sqlConnectionString);

            connection.Open();
            Console.WriteLine(connection.State);
            connection.Close();
        }
    }
}