using Microsoft.Data.Sqlite;
using WebApplication1.Entity;
using WebApplication1.iRepository;

namespace WebApplication1.Repository
{
    public class StudentRepository : IstudentRepository
    {
        private readonly string _ConnectionString;

        public StudentRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        } 
        public void AddStudent(Students student)
        {
            using (var connection = new SqliteConnection(_ConnectionString))
            {
                connection.Open();
                var command =connection.CreateCommand();
                command.CommandText = "Insert into Students(Id,Name,Email) values(@id,@name,@email)";
                command.Parameters.AddWithValue("@id",student.Id);
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@email",student.Email);
                command.ExecuteNonQuery();
            }
        }

    }
}
