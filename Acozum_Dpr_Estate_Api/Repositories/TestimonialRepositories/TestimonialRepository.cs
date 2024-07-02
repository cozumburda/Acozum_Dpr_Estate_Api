using Acozum_Dpr_Estate_Api.Dtos.BottomGridDtos;
using Acozum_Dpr_Estate_Api.Dtos.TestimonialDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;

namespace Acozum_Dpr_Estate_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            string query = "insert into Testimonial(NameSurname, Title, Comment, Status) values (@nameSurname,@title,@comment,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", createTestimonialDto.NameSurname);
            parameters.Add("@title", createTestimonialDto.Title);
            parameters.Add("@comment", createTestimonialDto.Comment);
            parameters.Add("@status", createTestimonialDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task DeleteTestimonial(int id)
        {
            string query = "Delete from Testimonial Where TestimonialID=@testimonialID";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialID", id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonial()
        {
            string query = "Select * from Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDTestimonialDto> GetTestimonial(int id)
        {
            string query = "Select * from Testimonial Where TestimonialID=@testimonialID";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByIDTestimonialDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            string query = "Update Testimonial set NameSurname=@nameSurname, Title=@title, Comment=@comment, Status=@status Where TestimonialID=@testimonialID";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", updateTestimonialDto.NameSurname);
            parameters.Add("@title", updateTestimonialDto.Title);
            parameters.Add("@comment", updateTestimonialDto.Comment);
            parameters.Add("@status", updateTestimonialDto.Status);
            parameters.Add("@testimonialID", updateTestimonialDto.TestimonialID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }
    }
}
