using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;
using Acozum_Dpr_Estate_Api.Dtos.ProductImageDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;

namespace Acozum_Dpr_Estate_Api.Repositories.ProductImageRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GetProductImagesByProductIdDto>> GetProductImagesProductIdAsync(int id)
        {
            string query = "Select * from ProductImage Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryAsync<GetProductImagesByProductIdDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
