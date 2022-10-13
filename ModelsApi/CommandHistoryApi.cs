using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class CommandHistoryApi : ApiBaseType
    {
        public int? CommandId { get; set; }
        public DateTime? DateUsing { get; set; }
        public string? CommandAnswer { get; set; }
    }
}
