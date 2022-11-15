using Akounto.Billing.Entities.Person;
using Akounto.Billing.Presentation.Controllers.Billing;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Akounto.Billing.Presentation.Controllers.Person
{
    public class CustomerController : BaseController
    {
        //[HttpPost(nameof(Add))]
        //public async Task<IActionResult> Add(CustomerCreateModel entity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var customer = await _paymentGateway.Customer.Add(entity);

        //        return Ok(customer);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpGet(nameof(GetByID))]
        //public async Task<IActionResult> GetByID(string Id)
        //{
        //    var customer = await _paymentGateway.Customer.GetById(Id);
        //    return Ok(customer);
        //}
    }
}
