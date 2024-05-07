using Acozum_Dpr_Estate_Api.Dtos.ProductDetailDtos;
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

        public async Task CreateProductWithCategory(CreateProductWithCategoryDto createProductWithCategoryDto)
        {
            string query = "insert into Product(ProductTitle,Price,City,Address,CoverImage,District,Description,Type,ProductCategory,EmployeeID,DealOfTheDay,ProductStatus,AdvertisementDate) " +
                "values (@productTitle,@price,@city,@address,@coverImage,@district,@description,@type,@productCategory,@employeeID,@dealOfTheDay,@productStatus,@advertisementDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@productTitle", createProductWithCategoryDto.ProductTitle);
            parameters.Add("@price", createProductWithCategoryDto.Price);
            parameters.Add("@city", createProductWithCategoryDto.City);
            parameters.Add("@address", createProductWithCategoryDto.Address);
            parameters.Add("@coverImage", createProductWithCategoryDto.CoverImage);
            parameters.Add("@district", createProductWithCategoryDto.District);
            parameters.Add("@description", createProductWithCategoryDto.Description);
            parameters.Add("@type", createProductWithCategoryDto.Type);
            parameters.Add("@productCategory", createProductWithCategoryDto.ProductCategory);
            parameters.Add("@employeeID", createProductWithCategoryDto.EmployeeID);
            parameters.Add("@dealOfTheDay", createProductWithCategoryDto.DealOfTheDay);
            parameters.Add("@advertisementDate", createProductWithCategoryDto.AdvertisementDate);
            parameters.Add("@productStatus", createProductWithCategoryDto.ProductStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task DeleteProductWithCategory(int id)
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

        public async Task<List<ResultProductAdvertsListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeByFalseAsync(int id)
        {
            string query = "select ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,DealOfTheDay,ProductStatus,AdvertisementDate from product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeID and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertsListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertsListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeByTrueAsync(int id)
        {
            string query = "select ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,DealOfTheDay,ProductStatus,AdvertisementDate from product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeID and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertsListWithCategoryByEmployeeDto>(query,parameters);
                return values.ToList();
            }
        }

        public async Task<GetByIDProductWithCategoryDto> GetProductByProductIdWithCategoryAsync(int id)
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

        public async Task<GetProductDetailByProductIdDto> GetProductDetailByProductIdWithCategoryAsync(int id)
        {
            string query = "select ProductDetailID,ProductSize,BedRoomCount,BathCount,RoomCount,GarageSize,BuildYear,ProductDetails.Price,Location,VideoUrl,ProductDetails.ProductID,ProductTitle,City,District,Address,Type,CoverImage,Description,AdvertisementDate,Employee.Name as EmployeeName,Employee.ImageUrl as EmployeeImage,Employee.PhoneNumber as EmployeePhone,Employee.Mail as EmployeeMail from ProductDetails inner join Product on ProductDetails.ProductID=Product.ProductID inner join Employee on Product.EmployeeID=Employee.EmployeeID where ProductDetails.ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetProductDetailByProductIdDto>(query, parameters);
                return values;
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product set DealOfTheDay=0 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product set DealOfTheDay=1 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task ProductStatusChangeToFalse(int id)
        {
            string query = "Update Product set ProductStatus=0 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task ProductStatusChangeToTrue(int id)
        {
            string query = "Update Product set ProductStatus=1 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task UpdateProductWithCategory(UpdateProductWithCategoryDto updateProductWithCategoryDto)
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
