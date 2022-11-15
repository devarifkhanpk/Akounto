using Akounto.Billing.Gateways.StripePayment.Billing;
using Akounto.Billing.Gateways.StripePayment.Person;
using AutoMapper;

namespace Akounto.Billing.Gateways.StripePayment
{
    public class StripeFactory : IGatewayFactory
    {       
        public IGateway CreateGateway(GatewaySettings param)
        {
            StripeGateway Gateway = new StripeGateway();
            Gateway.Initialize(param);
            //Gateway.Customer = new StripeCustomer();
            Gateway.Subscription = new StripeSubscription();
            return Gateway;
        }
    }
}
