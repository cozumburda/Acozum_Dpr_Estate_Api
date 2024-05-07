namespace Acozum_Dpr_Estate_UI.Dtos.MessagesDtos
{
    public class ResultInboxMessagesWithUserDto
    {
        public int MessageID { get; set; }
        public string SenderName { get; set; }
        public string ImageUrl { get; set; }
        public int Receiver { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
