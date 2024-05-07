namespace Acozum_Dpr_Estate_Api.Dtos.ProductDtos
{
    public class ResultProductAdvertsListWithCategoryByEmployeeDto
    {
        public int productID { get; set; }
        public string productTitle { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string categoryName { get; set; }
        public string coverImage { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool dealOfTheDay { get; set; }
        public bool ProductStatus { get; set; }
        public DateTime advertisementDate { get; set; }
    }
}
