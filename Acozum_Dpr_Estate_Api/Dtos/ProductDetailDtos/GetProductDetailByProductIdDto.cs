namespace Acozum_Dpr_Estate_Api.Dtos.ProductDetailDtos
{
    public class GetProductDetailByProductIdDto
    {
        public int ProductDetailID { get; set; }
        public int BedRoomCount { get; set; }
        public int BathCount { get; set; }
        public int RoomCount { get; set; }
        public int ProductSize { get; set; }
        public int GarageSize { get; set; }
        public string BuildYear { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
        public string ProductTitle { get; set; }
        public string CoverImage { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime AdvertisementDate { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeImage { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeMail { get; set; }
        public string SlugUrl { get; set; }
    }
}
