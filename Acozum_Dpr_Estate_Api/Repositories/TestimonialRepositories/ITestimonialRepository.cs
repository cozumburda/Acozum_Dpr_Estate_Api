using Acozum_Dpr_Estate_Api.Dtos.TestimonialDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        void CreateTestimonial(CreateTestimonialDto createTestimonialDto);
        void DeleteTestimonial(int id);
        void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto);
        Task<GetByIDTestimonialDto> GetTestimonial(int id);
    }
}
