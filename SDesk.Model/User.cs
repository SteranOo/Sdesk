namespace SDesk.Model
{
    public class User
    {
        public long UserId { get; set; }
        public long EmailId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long ExternalId { get; set; } //EpamId
    }
}
