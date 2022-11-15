namespace Akounto.Billing.Gateways.StripePayment.Person
{
    public class StripeCustomer // : StripeGateway, IBaseRepository<CustomerCreateModel, CustomerModel>
    {      

        //public async Task<string> Add(CustomerCreateModel entity)
        //{
        //    var custService = new Stripe.CustomerService();
        //    var customer = GetStripeCustomer(entity);
        //    Stripe.Customer stpCustomer = custService.Create(customer);

        //    return stpCustomer.Id;
        //}
       
        //public bool Delete(CustomerCreateModel entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Update(CustomerCreateModel entity)
        //{
        //    throw new NotImplementedException();
        //}       

        //public async Task<CustomerModel> GetById(string id)
        //{
        //    var service = new Stripe.CustomerService();
        //    var customer = service.Get(id);

        //    return GetAppCustomer(customer);
        //}

        //public IEnumerable<CustomerCreateModel> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //private Stripe.CustomerCreateOptions GetStripeCustomer(CustomerCreateModel entity)
        //{
        //    //Stripe.CustomerCreateOptions customer = new Stripe.CustomerCreateOptions();

        //    //var config = new MapperConfiguration(cfg =>
        //    //    cfg.CreateMap<CustomerCreateModel, Stripe.CustomerCreateOptions>()
        //    //);
        //    //_mapper = new Mapper(config);
        //    //customer = _mapper.Map<Stripe.CustomerCreateOptions>(entity);

        //    var settings = new JsonSerializerSettings() { ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver() };
        //    string jsonData = JsonConvert.SerializeObject(entity, settings);
        //    Stripe.CustomerCreateOptions customer = JsonConvert.DeserializeObject<Stripe.CustomerCreateOptions>(jsonData);

        //    return customer;

        //    // var settings = new JsonSerializerSettings() { ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver() };
        //    //  var str = JsonConvert.SerializeObject(yourObj, settings);

        //}

        //private CustomerModel GetAppCustomer(Stripe.Customer entity)
        //{
        //    //CustomerModel customer = new CustomerModel();

        //    //var config = new MapperConfiguration(cfg =>
        //    //    cfg.CreateMap<Stripe.Customer, CustomerModel>()
        //    //);
        //    //_mapper = new Mapper(config);
        //    //customer = _mapper.Map<CustomerModel>(entity);

        //    string jsonData = JsonConvert.SerializeObject(entity);
        //    CustomerModel customer = JsonConvert.DeserializeObject<CustomerModel>(jsonData);

        //    return customer;
        //}
    }
}
