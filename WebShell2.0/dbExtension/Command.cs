using ModelsApi;

namespace WebShell2._0.DB
{
    public partial class Command
    {
        public static explicit operator CommandApi(Command command)
        {
            return new CommandApi
            {
                ID = command.Id,
                CommandName = command.CommandName,
                CommandParametr = command.CommandParametr
            };
        }
        public static explicit operator Command(CommandApi command)
        {
            return new Command
            {
                Id = command.ID,
                CommandName = command.CommandName,
                CommandParametr = command.CommandParametr
            };
        }
    }
}
