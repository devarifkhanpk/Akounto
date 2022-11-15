using AutoMapper;

namespace Akounto.Billing.Gateways.StripePayment
{
    public class StripeGateway : IGateway
    {      
        protected IMapper _mapper = default!;
        public override void Initialize(GatewaySettings param)
        {           
            Stripe.StripeConfiguration.ApiKey = param.APIKey;         
        }

    }
}
