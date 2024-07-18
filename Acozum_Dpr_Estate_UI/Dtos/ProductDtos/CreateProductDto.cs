﻿namespace Acozum_Dpr_Estate_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductTitle { get; set; }
        public string SlugUrl { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ProductCategory { get; set; }
        public string CoverImage { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int AppUserId { get; set; }
        public string Type { get; set; }
        public bool DealOfTheDay { get; set; }
        public bool ProductStatus { get; set; }
        public DateTime AdvertisementDate { get; set; }

    }
}
