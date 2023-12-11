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

        public async void CreateProductWithCategory(CreateProductWithCategoryDto createProductWithCategoryDto)
        {
            string query = "insert into Product(ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate) " +
                "values (@productTitle,@price,@city,@address,@coverImage,@district,@description,@type,@categoryName,@name,@dealOfTheDay,@advertisementDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@productTitle", createProductWithCategoryDto.productTitle);
            parameters.Add("@price", createProductWithCategoryDto.price);
            parameters.Add("@city", createProductWithCategoryDto.city);
            parameters.Add("@address", createProductWithCategoryDto.address);
            parameters.Add("@coverImage", createProductWithCategoryDto.coverImage);
            parameters.Add("@district", createProductWithCategoryDto.district);
            parameters.Add("@description", createProductWithCategoryDto.description);
            parameters.Add("@type", createProductWithCategoryDto.type);
            parameters.Add("@categoryName", createProductWithCategoryDto.productCategory);
            parameters.Add("@name", createProductWithCategoryDto.employeeID);
            parameters.Add("@dealOfTheDay", createProductWithCategoryDto.dealOfTheDay);
            parameters.Add("@advertisementDate", createProductWithCategoryDto.advertisementDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async void DeleteProductWithCategory(int id)
        {
            string query = "Delete from Product Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
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
            string query = "Select ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join Employee on Product.EmployeeID=Employee.EmployeeID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "select top(5) ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,DealOfTheDay,AdvertisementDate from product inner join Category on Product.ProductCategory=Category.CategoryID where type='Kiralık' order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDProductWithCategoryDto> GetProductWithCategory(int id)
        {
            string query = "Select * from Product Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByIDProductWithCategoryDto>(query, parameters);
                return values;
            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product set DealOfTheDay=0 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product set DealOfTheDay=1 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async void UpdateProductWithCategory(UpdateProductWithCategoryDto updateProductWithCategoryDto)
        {
            string query = "Update Product set ProductTitle=@productTitle, Price=@price, City=@city, Address=@address, CoverImage=@coverImage, District=@district, Description=@description, Type=@type, CategoryName=@categoryName, Name=@name, DealOfTheDay=@dealOfTheDay, AdvertisementDate=@advertisementDate " +
                "Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productTitle", updateProductWithCategoryDto.productTitle);
            parameters.Add("@price", updateProductWithCategoryDto.price);
            parameters.Add("@city", updateProductWithCategoryDto.city);
            parameters.Add("@address", updateProductWithCategoryDto.address);
            parameters.Add("@coverImage", updateProductWithCategoryDto.coverImage);
            parameters.Add("@district", updateProductWithCategoryDto.district);
            parameters.Add("@description", updateProductWithCategoryDto.description);
            parameters.Add("@type", updateProductWithCategoryDto.type);
            parameters.Add("@categoryName", updateProductWithCategoryDto.productCategory);
            parameters.Add("@name", updateProductWithCategoryDto.employeeID);
            parameters.Add("@dealOfTheDay", updateProductWithCategoryDto.dealOfTheDay);
            parameters.Add("@advertisementDate", updateProductWithCategoryDto.advertisementDate);
            parameters.Add("@productID", updateProductWithCategoryDto.productID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }
    }    
}
