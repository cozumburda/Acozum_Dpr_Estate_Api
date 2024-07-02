using Acozum_Dpr_Estate_Api.Dtos.CategoryDtos;
using Acozum_Dpr_Estate_Api.Dtos.EmployeeDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployee();
        Task CreateEmployee(CreateEmployeeDto createEmployeeDto);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        Task<GetByIDEmployeeDto> GetEmployee(int id);
    }
}
