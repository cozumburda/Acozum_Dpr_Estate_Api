﻿namespace Acozum_Dpr_Estate_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {      
        public string ProductTitle { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string categoryid { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string coverimage { get; set; }
        public string name { get; set; }
        public string Type { get; set; }
    }
}