using Akounto.Billing.Entities.Billing;
using Akounto.Billing.Repositories;
using AutoMapper;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akounto.Billing.Gateways.StripePayment.Billing
{
    public class StripeSubscription : StripeGateway, IBaseRepository<SubscriptionModel, SubscriptionCreateModel>
    {          

        public async Task<string> Add(SubscriptionCreateModel entity)
        {
            var options = new SubscriptionCreateOptions
            {
                Customer = entity.Customer,
                Items = new System.Collections.Generic.List<Stripe.SubscriptionItemOptions> {
                        new Stripe.SubscriptionItemOptions {
                            Price = entity.PlanID 
                        }
                }
            };
            var service = new SubscriptionService(); 
            Subscription subscription = service.Create(options);
            return subscription.Id;
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

        public IEnumerable<SubscriptionModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SubscriptionModel> GetById(string ID)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Update(SubscriptionCreateModel entity)
        {

            //var options = new SubscriptionCreateOptions
            //{
            //    Customer = entity.Customer,
            //    Items = new System.Collections.Generic.List<Stripe.SubscriptionItemOptions> {
            //            new Stripe.SubscriptionItemOptions {
            //                Price = entity.PlanID
            //            }
            //    }
            //};
            //var service = new Stripe.SubscriptionService();
            //Stripe.Subscription subscription = service.Create(options);
            //return subscription.Id;


            var service = new Stripe.SubscriptionService();
            Stripe.Subscription subscription = service.Get(entity.PlanID);
            var options = new SubscriptionUpdateOptions
            {
                CancelAtPeriodEnd = false,
                ProrationBehavior = "create_prorations",
                Items = new List<SubscriptionItemOptions>
                 {
                    new SubscriptionItemOptions
                    {
                      Id = subscription.Items.Data[0].Id,
                      Price = entity.UpdatedPlanID,
                    },
                 },
            };


            subscription = service.Update(subscription.Id, options);
            return subscription.Id;
            


  //          var options = new   
  //          {
  //              Metadata = new Dictionary<string, string>
  //{
  //  { "order_id", "6735" },
  //},
  //          };
  //          var service = new SubscriptionService();
  //          service.Update(
  //            "sub_1M3bgJ2eZvKYlo2CabYTJsvY",
  //            options);

          //  throw new NotImplementedException();
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

        private SubscriptionModel GetAppSubscription(Stripe.Subscription entity)
        {
            SubscriptionModel customer = new SubscriptionModel();

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Stripe.Subscription, SubscriptionModel>()
            );
            _mapper = new Mapper(config);
            customer = _mapper.Map<SubscriptionModel>(entity);

            return customer;
        }
    }
}
