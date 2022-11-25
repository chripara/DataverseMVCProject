using AutoMapper;
using DataverseMVCProject.Dtos.Customer;

namespace DataverseMVCProject.Dtos.Profiles.Customer
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<GetCustomerDto, Models.Customer.Customer>().ReverseMap();
            CreateMap<CreateCustomerDto, Models.Customer.Customer>().ReverseMap();
            CreateMap<UpdateCustomerDto, Models.Customer.Customer>().ReverseMap();
            CreateMap<DeleteCustomerDto, Models.Customer.Customer>().ReverseMap();            
        }
    }
}
