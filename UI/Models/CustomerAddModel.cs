using Dtos;
using Models.Concrete;

namespace UI.Models
{
    public class CustomerAddModel
    {
        public CustomerAddDto CustomerAddDto { get; set; }
        public AddressListDto Addresses { get; set; }
    }
}
