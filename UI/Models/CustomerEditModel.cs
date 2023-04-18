using Dtos;
using Models.Concrete;

namespace UI.Models
{
    public class CustomerEditModel
    {
        public CustomerUpdateDto CustomerUpdateDto { get; set; }
        public Customer Customer { get; set; }
        public AddressListDto Addresses { get; set; }
        public int Id { get; set; }
    }
}
