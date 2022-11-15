using System.ComponentModel.DataAnnotations;

namespace Akounto.Billing.Entities.Person
{
    public class AddressOptions1 : BaseEntity
    {
    //    public long Id { get; set; }

      //  public long CustomerId { get; set; }
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Line1 { get; set; } = default!;
        public string Line2 { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string State { get; set; } = default!;
    }
}
