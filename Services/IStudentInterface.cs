using SIMPLECRUD.Model;

namespace SIMPLECRUD.Services
{
    public interface IStudentInterface
    {
        Task<int> CreateAsync(Student student);
    }
}
