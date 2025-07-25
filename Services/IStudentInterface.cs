using SIMPLECRUD.Model;

namespace SIMPLECRUD.Services
{
    public interface IStudentInterface
    {
        Task<int> CreateAsync(Student student);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<int> UpdateAsync(Student student);
        Task<int> DeleteAsync(int id);
    }
}
