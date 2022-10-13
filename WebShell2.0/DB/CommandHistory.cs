using System;
using System.Collections.Generic;

namespace WebShell2._0.DB
{
    public partial class CommandHistory
    {
        public int Id { get; set; }
        public int? CommandId { get; set; }
        public DateTime? DateUsing { get; set; }
        public string? CommandAnswer { get; set; }

        public virtual Command? Command { get; set; }
    }
}
