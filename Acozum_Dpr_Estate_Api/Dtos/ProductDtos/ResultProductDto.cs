namespace Acozum_Dpr_Estate_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ProductCategory { get; set; }
        public string CoverImage { get; set; }
        public string Address { get; set;}
        public string Description {  get; set; }
        public int EmployeeID { get; set; }
        public string Type { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime advertisementDate { get; set; }
    }
}
