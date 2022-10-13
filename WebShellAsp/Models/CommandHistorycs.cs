namespace WebShellAsp.Models
{
    public class CommandHistorycs
    {
        public int ID { get; set; }
        public int? CommandId { get; set; }
        public DateTime? DateUsing { get; set; }
        public string? CommandAnswer { get; set; }
    }
}
