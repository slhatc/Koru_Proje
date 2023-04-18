using Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using UI.Models;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;
        public CustomerController(ICustomerService customerService, IAddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
        }
        public async Task<IActionResult> Index()
        {
            var customerList = await _customerService.GetAllAsync();
            return View(customerList);
        }
        public async Task<IActionResult> Add()
        {
            var model = new CustomerAddModel();
            model.Addresses = await _addressService.GetAllAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CustomerAddModel model)
        {

            await _customerService.AddAsync(model.CustomerAddDto);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = new CustomerEditModel();
            model.Customer= await _customerService.GetByIdAsync(id); 
            model.Addresses = await _addressService.GetAllAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditModel model)
        {
            model.CustomerUpdateDto.Id = model.Id;
            await _customerService.UpdateAsync(model.CustomerUpdateDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _customerService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
