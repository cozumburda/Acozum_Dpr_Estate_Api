using Acozum_Dpr_Estate_Api.Dtos.TestimonialDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonial();
        Task CreateTestimonial(CreateTestimonialDto createTestimonialDto);
        Task DeleteTestimonial(int id);
        Task UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto);
        Task<GetByIDTestimonialDto> GetTestimonial(int id);
    }
}
