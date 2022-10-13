using ModelsApi;

namespace WebShell2._0.DB
{
    public partial class CommandHistory
    {
        public static explicit operator CommandHistoryApi(CommandHistory command)
        {
            return new CommandHistoryApi
            {
                ID = command.Id,
                DateUsing = command.DateUsing,
                CommandAnswer = command.CommandAnswer,
                CommandId = command.CommandId
            };
        }
        public static explicit operator CommandHistory(CommandHistoryApi command)
        {
            return new CommandHistory
            {
                Id = command.ID,
                DateUsing = command.DateUsing,
                CommandAnswer = command.CommandAnswer,
                CommandId = command.CommandId
            };
        }
    }
}
