namespace Acozum_Dpr_Estate_Api.Dtos.ProductDtos
{
    public class UpdateProductWithCategoryDto
    {
        public int productID { get; set; }
        public string productTitle { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public int productCategory { get; set; }
        public string coverImage { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public int appUserId { get; set; }
        public string type { get; set; }
        public bool dealOfTheDay { get; set; }
        public DateTime advertisementDate { get; set; }
    }
}
