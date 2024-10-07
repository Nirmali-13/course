using Microsoft.Data.Sqlite;

namespace WebApplication1.Database
{
    public class DatabaseTables
    {
        private readonly string _connectionString;

        public DatabaseTables(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void TableCreate()
        {
            using (var Connection = new SqliteConnection(_connectionString))
            {
                Connection.Open();  
                var command= Connection.CreateCommand();
                command.CommandText = @"
              Create Table if not Exists Students(
                  Id int primary key,
                  Name nvarchar(50) not null,
                  Email nvarchar(50) not null
                   );
              Create Table if not exists Enroll(
                  Id int Primary key,
                  StudentId int not null,
                  Course nvarchar(50) not null,
                  Foreign key (StudentId) References Students(Id) on delete cascade
                  );
                ";
                command.ExecuteNonQuery();
            }
        }
    }
}
