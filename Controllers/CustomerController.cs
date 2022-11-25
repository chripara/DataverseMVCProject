using AutoMapper;
using DataverseMVCProject.Data;
using DataverseMVCProject.Dtos.Customer;
using DataverseMVCProject.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace DataverseMVCProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CustomerController(AppDbContext appDbContext,
            IMapper mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetCustomerDto dto)
        {
            var customer = _appDbContext.Customers.Find(dto.Id);

            if (customer == null)
                return BadRequest();

            return Ok(customer);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var customer = _appDbContext.Customers.ToList();

            if (customer == null)
                return BadRequest();

            return Ok(customer);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteCustomerDto dto)
        {
            var customer = _appDbContext.Customers.Find(dto.Id);

            if (customer == null)
                return BadRequest();
            
            _appDbContext.Remove(customer);
            await _appDbContext.SaveChangesAsync();

            return Ok("Customer with id " + dto.Id + " deleted succesfully.");
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            await _appDbContext.AddAsync(customer);
            _appDbContext.SaveChanges();

            var newCustomer = _appDbContext.Customers.OrderBy(o => o.Id).Last();

            if (newCustomer == null)
                return BadRequest();

            return Ok(newCustomer);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateCustomerDto dto)
        {
            var customer = _appDbContext.Customers.Find(dto.Id);

            if (customer == null)
                return BadRequest();

            customer.Surname = dto.Surname;
            customer.Firstname = dto.Firstname;
            customer.Address = dto.Address;
            customer.ContactPhone = dto.ContactPhone;
            customer.Email = dto.Email;

            _appDbContext.Update(customer);
            _appDbContext.SaveChanges();

            var updatedCustomer = _appDbContext.Customers.Find(dto.Id);

            return Ok(updatedCustomer);
        }
    }
}
