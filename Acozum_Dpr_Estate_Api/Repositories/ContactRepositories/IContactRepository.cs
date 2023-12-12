using Acozum_Dpr_Estate_Api.Dtos.ContactDto;

namespace Acozum_Dpr_Estate_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        void CreateContact(CreateContactDto createContactDto);
        void DeleteContact(int id);
        void UpdateContact(UpdateContactDto updateContactDto);
        Task<GetByIDContactDto> GetContact(int id);
        Task<List<Last4ContactResultDto>> GetLast4ContactAsync();
    }
}
