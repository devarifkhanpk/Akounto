using Akounto.Billing.Gateways;
using Akounto.Billing.Gateways.StripePayment;
using Akounto.Billing.Gateways.StripePayment.Person;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akounto.Billing.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
       protected readonly IGateway _paymentGateway = default!;      
        public BaseApiController() //Add switch condition to create multiple gateway factories
        {
            GatewaySettings param = new StripeGatewaySetting();
            param.GatewayType = PaymentGatewayType.Stripe;
            param.APIKey = "sk_test_51LzdNRSEUqurWPXSePSAQzDJYj8JVddU9pXq5afQh2PZUakWcIpmvU2z8pjJjBsZuW1McwWIqdMGuItGGGwzbRZX00J9vmvVwL";
            IGatewayFactory Factory = new StripeFactory();

            _paymentGateway = Factory.CreateGateway(param);
          
        }
    }
}
