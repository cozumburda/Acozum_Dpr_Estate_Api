using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;

namespace Acozum_Dpr_Estate_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join Employee on Product.EmployeeID=Employee.EmployeeID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }    
}
