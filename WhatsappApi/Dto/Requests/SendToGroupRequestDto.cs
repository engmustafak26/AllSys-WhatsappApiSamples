namespace WhatsappApi.Dto.Requests
{
    public class SendToGroupRequestDto
    {
        public long GroupId { get; set; }
        public string Message { get; set; }
        public string Base64Image { get; set; }
    }
}
