using Akounto.Billing.Entities.Billing;
using Akounto.Billing.Entities.Person;
using Akounto.Billing.Gateways.StripePayment.Person;
using Akounto.Billing.Repositories;
using Plans.Payment.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akounto.Billing.Gateways
{
    public abstract class IGateway
    {
        public abstract void Initialize(GatewaySettings param);
        public IBaseRepository<CustomerCreateModel, CustomerModel> Customer { get; set; }
        public IBaseRepository<SubscriptionModel, SubscriptionCreateModel> Subscription { get; set; }
        public IBaseRepository<InvoiceModel, InvoiceCreateModel> Invoice { get; set; }
    }
}
