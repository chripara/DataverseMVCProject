namespace DataverseMVCProject.Dtos.Customer
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
