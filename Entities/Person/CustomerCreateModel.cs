using Akounto.Billing.Gateways.StripePayment.Person;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Akounto.Billing.Entities.Person
{
    public class CustomerCreateModel : Stripe.CustomerCreateOptions
    {
      //  public long Id { get; set; }
             
      // // public CustomerTaxOptions Tax { get; set; }
      //  public Stripe.ShippingOptions Shipping { get; set; }
      ////  public string PromotionCode { get; set; }
      //  public string Plan { get; set; }
      //  public string Phone { get; set; } = default!;
      //  public string PaymentMethod { get; set; }
      //  public string Name { get; set; } = default!;

      //  [MaxLength(255)]
      //  [Required(ErrorMessage = "Email can't be empty")]
      //  [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
      //  public string Email { get; set; } = default!;

      //  public string Description { get; set; }
      //  public string Coupon { get; set; } = default!;
      //  public long? Balance { get; set; }
      //  public Stripe.AddressOptions Address { get; set; }
    }
}
