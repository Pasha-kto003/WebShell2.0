namespace WebShellAsp2.Models
{
    public class CommandHistory
    {
        public int ID { get; set; }
        public int? CommandId { get; set; }
        public DateTime? DateUsing { get; set; }
        public string? CommandAnswer { get; set; }
        public Command Command { get; set; }
    }
}
