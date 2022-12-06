using System;
using System.Collections.Generic;
using System.Text;

namespace Plans.Payment.Entities.Billing
{
  public   class InvoiceModel 
    {
        public string Description { get; set; }
        public string Interval { get; set; }
        public long? Quantity { get; set; }
        public long? IntervalCount { get; set; }
        public long? Amount { get; set; }
        public long? AmountDue { get; set; }
        public long? AmountRemaining { get; set; }
    }
}
