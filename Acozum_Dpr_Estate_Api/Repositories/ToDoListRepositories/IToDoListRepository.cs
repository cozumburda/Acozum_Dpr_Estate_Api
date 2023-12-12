using Acozum_Dpr_Estate_Api.Dtos.ToDoListDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        void CreateToDoListAsync(CreateToDoListDto createToDoListDto);
        void DeleteToDoList(int id);
        void UpdateToDoList(UpdateToDoListDto updateToDoListDto);
        Task<GetByIDToDoListDto> GetToDoList(int id);
    }
}
