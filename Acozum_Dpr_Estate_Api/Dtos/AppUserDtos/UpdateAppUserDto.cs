namespace Acozum_Dpr_Estate_Api.Dtos.AppUserDtos
{
    public class UpdateAppUserDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int UserRole { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
