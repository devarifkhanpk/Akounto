using Akounto.Billing.Entities.Billing;
using Akounto.Billing.Repositories;
using Plans.Payment.Entities.Billing;
using Stripe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akounto.Billing.Gateways.StripePayment.Billing
{
    public class InvoiceReceived : StripeGateway, IBaseRepository<InvoiceModel, InvoiceCreateModel>
    {          

        public async Task<string> Add(InvoiceCreateModel entity)
        {
            throw new NotImplementedException();
            //var options = new UpcomingInvoiceOptions
            //{
            //    Customer = entity.Customer,// "cus_4QFOF3xrvBT2nU",
            //};
            //var service = new InvoiceService();
            //Invoice upcoming = service.Upcoming(options);





            //return upcoming.Id;

        }

        public bool Delete(string ID)
        {

            var service = new SubscriptionService();

            var cancelOptions = new SubscriptionCancelOptions
            {
                InvoiceNow = true,
                Prorate = true,
            };
            Subscription subscription = service.Cancel(ID, cancelOptions);

            //service.Cancel(ID);

            return true;
           // throw new NotImplementedException();
        }

        public IEnumerable<InvoiceModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<InvoiceModel> GetById(string ID)
        {
           
            var options = new UpcomingInvoiceOptions
            {
                Customer = ID,// "cus_MvBe9uwf4Bx6Ir",
            };

            var service = new InvoiceService();
            var  upcoming = await service.UpcomingAsync(options);

            InvoiceModel info = new InvoiceModel();
            info.Description = upcoming.Lines.Data[0].Description;
            info.Quantity = upcoming.Lines.Data[0].Quantity;
            info.Interval = upcoming.Lines.Data[0].Plan.Interval;
            info.IntervalCount = upcoming.Lines.Data[0].Plan.IntervalCount;
            info.Amount = upcoming.Lines.Data[0].Amount;
            info.AmountDue = upcoming.AmountDue;
            info.AmountRemaining = upcoming.AmountRemaining;
            //info.Amount = upcoming.Lines.Data[0].Plan.Amount;


            return info;
        }

        public async Task<string> Update(InvoiceCreateModel entity)
        {  
           throw new NotImplementedException();
        }



        public  Task<string> GetInfo()
        {
            var service = new BalanceService();

            //var cancelOptions = new SubscriptionCancelOptions
            //{
            //    InvoiceNow = true,
            //    Prorate = true,
            //};
            //Subscription subscription = service.Cancel(ID, cancelOptions);

            service = new BalanceService();
            service.Get();
           
            throw new NotImplementedException();
        }

        //private SubscriptionModel GetAppSubscription(Stripe.Subscription entity)
        //{
        //    SubscriptionModel customer = new SubscriptionModel();

        //    var config = new MapperConfiguration(cfg =>
        //        cfg.CreateMap<Stripe.Subscription, SubscriptionModel>()
        //    );
        //    _mapper = new Mapper(config);
        //    customer = _mapper.Map<SubscriptionModel>(entity);

        //    return customer;
        //}
    }
}
