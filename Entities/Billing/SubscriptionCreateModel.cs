using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akounto.Billing.Entities.Billing
{
    public class SubscriptionCreateModel //: Stripe.SubscriptionCreateOptions
    { 

        public string Customer { get; set; }

        public string PlanID { get; set; }

        public string UpdatedPlanID { get; set; }

        ////  public AnyOf<DateTime?, SubscriptionTrialEnd> TrialEnd { get; set; }

        //  public Stripe.SubscriptionTransferDataOptions TransferData { get; set; }

        //  public string ProrationBehavior { get; set; }

        //  public string PromotionCode { get; set; }

        //  public Stripe.SubscriptionPendingInvoiceItemIntervalOptions PendingInvoiceItemInterval { get; set; }

        //  public Stripe.SubscriptionPaymentSettingsOptions PaymentSettings { get; set; }

        //  public string PaymentBehavior { get; set; }

        //  public string OnBehalfOf { get; set; }

        //  public bool? OffSession { get; set; }

        //  public Dictionary<string, string> Metadata { get; set; }

        //  public List<Stripe.SubscriptionItemOptions> Items { get; set; }

        //  public string Description { get; set; }

        //  public List<string> DefaultTaxRates { get; set; }

        //  public bool? TrialFromPlan { get; set; }

        //  public string DefaultSource { get; set; }

        //  public long? DaysUntilDue { get; set; }

        //  public string Customer { get; set; }

        //  public string Currency { get; set; }

        //  public string Coupon { get; set; }

        //  public string CollectionMethod { get; set; }

        //  public bool? CancelAtPeriodEnd { get; set; }

        //  public DateTime? CancelAt { get; set; }

        //  public Stripe.SubscriptionBillingThresholdsOptions BillingThresholds { get; set; }

        //  public DateTime? BillingCycleAnchor { get; set; }

        //  public DateTime? BackdateStartDate { get; set; }

        //  public Stripe.SubscriptionAutomaticTaxOptions AutomaticTax { get; set; }

        //  public decimal? ApplicationFeePercent { get; set; }

        //  public List<Stripe.SubscriptionAddInvoiceItemOptions> AddInvoiceItems { get; set; }

        //  public string DefaultPaymentMethod { get; set; }

        //  public long? TrialPeriodDays { get; set; }
    }
}
