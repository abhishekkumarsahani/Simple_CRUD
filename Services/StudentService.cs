﻿using Dapper;
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

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var query = "SELECT * FROM Students";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Student>(query);
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Students WHERE ID = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Student>(query,
            new { Id = id });
        }
        
        public async Task<int> UpdateAsync(Student student)
        {
            var query = "UPDATE Students SET Name = @Name, Email = @Email, Address = @Address, Contact = @Contact WHERE ID = @Id";
        using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, student);
        }
        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Students WHERE ID = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, new { ID = id });
        }

    }
}
