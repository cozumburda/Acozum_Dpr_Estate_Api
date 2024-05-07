namespace Acozum_Dpr_Estate_Api.Dtos.MessageDtos
{
    public class ResultSendBoxMessageDto
    {
        public int MessageID { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
