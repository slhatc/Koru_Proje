using Dtos;
using Microsoft.AspNetCore.Mvc;
using Models.Concrete;
using Services.Interface;
using UI.Models;

namespace UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;
        public AddressController(ICustomerService customerService, IAddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
        }
        public async Task<IActionResult> Index()
        {
            var addressList = await _addressService.GetAllAsync();
            return View(addressList);
           
        }

        public async Task<IActionResult> Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddressAddDto model)
        {

            await _addressService.AddAsync(model);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {

            await _addressService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
