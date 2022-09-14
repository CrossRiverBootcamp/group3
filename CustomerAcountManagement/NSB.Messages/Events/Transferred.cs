using NServiceBus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSB.Messages.Events
{
    public class Transferred:IEvent
    {
        [Required]
        public Guid TransactionId { get; set; }
        [Required]
        public Guid Id { get; set; }
        public bool Result { get; set; }
        public string? FailureReason { get; set; }

    }
}
