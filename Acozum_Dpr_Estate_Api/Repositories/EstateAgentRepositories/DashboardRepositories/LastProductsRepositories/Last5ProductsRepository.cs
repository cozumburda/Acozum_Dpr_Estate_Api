using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;

namespace Acozum_Dpr_Estate_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public class Last5ProductsRepository : ILast5ProductsRepository
    {
        private readonly Context _context;

        public Last5ProductsRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = "select top(5) ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,DealOfTheDay,AdvertisementDate from product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeID order by ProductID desc";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query,parameters);
                return values.ToList();
            }
        }
    }
}
