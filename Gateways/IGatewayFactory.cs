using Akounto.Billing.Gateways.StripePayment.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akounto.Billing.Gateways
{
    public interface IGatewayFactory
    {
        IGateway CreateGateway(GatewaySettings param);      

    }
}
