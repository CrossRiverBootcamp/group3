using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSB.Messages.Events
{
    public class Transferrd
    {
        public string Id { get; set; }
        public bool Result { get; set; }
        public string? FailureReason { get; set; }

    }
}
