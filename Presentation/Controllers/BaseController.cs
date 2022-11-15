using Akounto.Billing.Gateways;
using Akounto.Billing.Gateways.StripePayment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akounto.Billing.Presentation.Controllers.Billing
{
    public class BaseController : Controller
    {
        public static IGateway _gateway = default;
        private static GatewaySettings gatewaySettings = default;
        public static IGateway GetGateway(PaymentGatewayType gatewayType)
        {
            if (gatewayType == PaymentGatewayType.Stripe)
            {
                gatewaySettings = new StripeGatewaySetting();
                gatewaySettings.APIKey = "sk_test_51LzdNRSEUqurWPXSePSAQzDJYj8JVddU9pXq5afQh2PZUakWcIpmvU2z8pjJjBsZuW1McwWIqdMGuItGGGwzbRZX00J9vmvVwL";
                gatewaySettings.GatewayType = gatewayType;
                IGatewayFactory factory = new StripeFactory();
                _gateway = factory.CreateGateway(gatewaySettings);
            }
            else if (gatewayType == PaymentGatewayType.AuthorizeNet)
            {
                // Authorize Factory Implmentation
            }
            return _gateway;
        }
    }
}
