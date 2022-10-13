using System;
using System.Collections.Generic;

namespace WebShell2._0.DB
{
    public partial class Command
    {
        public Command()
        {
            CommandHistories = new HashSet<CommandHistory>();
        }

        public int Id { get; set; }
        public string? CommandName { get; set; }
        public string? CommandParametr { get; set; }

        public virtual ICollection<CommandHistory> CommandHistories { get; set; }
    }
}
