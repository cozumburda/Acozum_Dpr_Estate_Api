﻿namespace Acozum_Dpr_Estate_Api.Dtos.AppUserDtos
{
    public class GetAppUserByProductIdDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
