using Dapper;
using SIMPLECRUD.Data;
using SIMPLECRUD.Model;

namespace SIMPLECRUD.Services
{
    public class StudentService : IStudentInterface
    {
        public DapperContext _context;

        public StudentService(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Student student)
        {
            var query = "INSERT INTO Students(ID,Name,Email,Address,Contact) VALUES (@Id, @Name, @Email, @Address,@Contact)";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, student);
        }

    }
}
