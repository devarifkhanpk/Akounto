using System;
using System.Collections.Generic;
using System.Text;

namespace Plans.Payment.Entities.Billing
{
  public   class PlanCategoryModel
    {
        public int? ID { get; set; }
        public string PlanName { get; set; }
        public decimal? Cost { get; set; }

        public string PlanDurationName { get; set; }
    }
}
