namespace Akounto.Billing.Gateways
{

    public enum PaymentGatewayType
    {
        Stripe = 1,
        AuthorizeNet = 2
    }
    public abstract class GatewaySettings
    {
        public PaymentGatewayType GatewayType { get; set; }
        public string APIKey { get; set; }
    }
}
