using Acozum_Dpr_Estate_Api.Dtos.ProductDetailDtos;
using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;

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
            string query = "insert into Product(ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,ProductCategory,AppUserId,DealOfTheDay,ProductStatus,AdvertisementDate) " +
                "values (@productTitle,@slugUrl,@price,@city,@address,@coverImage,@district,@description,@type,@productCategory,@appUserId,@dealOfTheDay,@productStatus,@advertisementDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@productTitle", createProductWithCategoryDto.ProductTitle);
            parameters.Add("@slugUrl", createProductWithCategoryDto.SlugUrl);
            parameters.Add("@price", createProductWithCategoryDto.Price);
            parameters.Add("@city", createProductWithCategoryDto.City);
            parameters.Add("@address", createProductWithCategoryDto.Address);
            parameters.Add("@coverImage", createProductWithCategoryDto.CoverImage);
            parameters.Add("@district", createProductWithCategoryDto.District);
            parameters.Add("@description", createProductWithCategoryDto.Description);
            parameters.Add("@type", createProductWithCategoryDto.Type);
            parameters.Add("@productCategory", createProductWithCategoryDto.ProductCategory);
            parameters.Add("@appUserId", createProductWithCategoryDto.AppUserId);
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
            string query = "Select ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3ProductsWithCategoryAndEmployeeDto>> GetLast3ProductAsync()
        {
            string query = "select top(3) ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from product inner join Category on Product.ProductCategory=Category.CategoryID inner join AppUser on Product.AppUserId=AppUser.UserId order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductsWithCategoryAndEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "select top(5) ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from product inner join Category on Product.ProductCategory=Category.CategoryID inner join AppUser on Product.AppUserId=AppUser.UserId order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertsListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeByFalseAsync(int id)
        {
            string query = "select ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,DealOfTheDay,ProductStatus,AdvertisementDate from product inner join Category on Product.ProductCategory=Category.CategoryID where AppUserId=@appUserId and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertsListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertsListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeByTrueAsync(int id)
        {
            string query = "select ProductID,ProductTitle,Price,City,Address,CoverImage,District,Description,Type,CategoryName,DealOfTheDay,ProductStatus,AdvertisementDate from product inner join Category on Product.ProductCategory=Category.CategoryID where AppUserId=@appUserId and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertsListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<GetByIDProductWithCategoryDto> GetProductByProductIdWithCategoryAsync(int id)
        {
            string query = "Select ProductID, ProductTitle,Price,City,District,Description,CategoryName,CoverImage,Type,Address,DealOfTheDay,AdvertisementDate,AppUserId from Product inner join Category on Product.ProductCategory=Category.CategoryID Where ProductID=@productID";
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
            string query = "select ProductDetailID,ProductSize,BedRoomCount,BathCount,RoomCount,GarageSize,BuildYear,ProductDetails.Price,Location,VideoUrl,ProductDetails.ProductID,ProductTitle,City,District,Address,Type,CoverImage,Description,AdvertisementDate,AppUser.Name as EmployeeName,AppUser.ImageUrl as EmployeeImage,AppUser.PhoneNumber as EmployeePhone,AppUser.Email as EmployeeMail,SlugUrl from ProductDetails inner join Product on ProductDetails.ProductID=Product.ProductID inner join AppUser on Product.AppUserId=AppUser.UserId where ProductDetails.ProductID=@productID";
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

        public async Task<List<ResultProductCitiesDto>> ResultProductCities(int? propertyCategoryId)
        {
            if (propertyCategoryId == null) { propertyCategoryId = 0; }
            if (propertyCategoryId != 0)
            {
                string query = "Select DISTINCT City from Product Where ProductCategory=@productCategory";
                var parameters = new DynamicParameters();
                parameters.Add("@productCategory", propertyCategoryId);
                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductCitiesDto>(query, parameters);
                    return values.ToList();
                }
            }
            else
            {
                string query = "Select DISTINCT City from Product";

                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductCitiesDto>(query);
                    return values.ToList();
                }
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string? searchKeyValue, int? propertyCategoryId, string? city)
        {
            if (propertyCategoryId == null) { propertyCategoryId = 0; }

            if (!string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId != 0 & !string.IsNullOrEmpty(city))
            {
                string query = "Select ProductID,ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId Where ProductTitle like " + "'%" + searchKeyValue + "%'" + "And ProductCategory=@productCategory And City=@city And ProductStatus=1";
                var parameters = new DynamicParameters();
                //parameters.Add("@productTitle", searchKeyValue);
                parameters.Add("@productCategory", propertyCategoryId);
                parameters.Add("@city", city);
                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if (!string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId != 0 & string.IsNullOrEmpty(city))
            {
                string query = "Select ProductID,ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId Where ProductTitle like " + "'%" + searchKeyValue + "%'" + "And ProductCategory=@productCategory And ProductStatus=1";
                var parameters = new DynamicParameters();
                parameters.Add("@productCategory", propertyCategoryId);
                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if (!string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId == 0 & !string.IsNullOrEmpty(city))
            {
                string query = "Select ProductID,ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId Where ProductTitle like " + "'%" + searchKeyValue + "%'" + "And City=@city And ProductStatus=1";
                var parameters = new DynamicParameters();
                //parameters.Add("@productTitle", searchKeyValue);                
                parameters.Add("@city", city);
                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if (!string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId == 0 & string.IsNullOrEmpty(city))
            {
                string query = "Select ProductID,ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId Where ProductTitle like " + "'%" + searchKeyValue + "%'" + "And ProductStatus=1";

                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductWithSearchListDto>(query);
                    return values.ToList();
                }
            }
            else if (string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId != 0 & !string.IsNullOrEmpty(city))
            {
                string query = "Select ProductID,ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId Where ProductCategory=@productCategory And City=@city And ProductStatus=1";
                var parameters = new DynamicParameters();
                parameters.Add("@productCategory", propertyCategoryId);
                parameters.Add("@city", city);
                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if (string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId != 0 & string.IsNullOrEmpty(city))
            {
                string query = "Select ProductID,ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId Where ProductCategory=@productCategory And ProductStatus=1";
                var parameters = new DynamicParameters();
                parameters.Add("@productCategory", propertyCategoryId);
                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if (string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId == 0 & !string.IsNullOrEmpty(city))
            {
                string query = "Select ProductID,ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId Where City=@city And ProductStatus=1";
                var parameters = new DynamicParameters();
                parameters.Add("@city", city);
                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                    return values.ToList();
                }
            }
            else
            {
                string query = "Select ProductID,ProductTitle,SlugUrl,Price,City,Address,CoverImage,District,Description,Type,CategoryName,Name,DealOfTheDay,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID  inner join AppUser on Product.AppUserId=AppUser.UserId And ProductStatus=1";

                using (var connections = _context.CreateConnection())
                {
                    var values = await connections.QueryAsync<ResultProductWithSearchListDto>(query);
                    return values.ToList();
                }
            }

        }

        public async Task UpdateProductWithCategory(UpdateProductWithCategoryDto updateProductWithCategoryDto)
        {
            string query = "Update Product set ProductTitle=@productTitle,SlugUrl=@slugUrl, Price=@price, City=@city, Address=@address, CoverImage=@coverImage, District=@district, Description=@description, Type=@type, ProductCategory=@productCategory, AppUserId=@appUserId, DealOfTheDay=@dealOfTheDay, AdvertisementDate=@advertisementDate " +
                "Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productTitle", updateProductWithCategoryDto.productTitle);
            parameters.Add("@slugUrl", updateProductWithCategoryDto.SlugUrl);
            parameters.Add("@price", updateProductWithCategoryDto.price);
            parameters.Add("@city", updateProductWithCategoryDto.city);
            parameters.Add("@address", updateProductWithCategoryDto.address);
            parameters.Add("@coverImage", updateProductWithCategoryDto.coverImage);
            parameters.Add("@district", updateProductWithCategoryDto.district);
            parameters.Add("@description", updateProductWithCategoryDto.description);
            parameters.Add("@type", updateProductWithCategoryDto.type);
            parameters.Add("@productCategory", updateProductWithCategoryDto.productCategory);
            parameters.Add("@appUserId", updateProductWithCategoryDto.appUserId);
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
