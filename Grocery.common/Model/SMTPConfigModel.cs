namespace Grocery.common.Model
{
    public class SMTPConfigModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public string? DisplayName { get; set; }
        public int Port { get; set; }
    }
}
