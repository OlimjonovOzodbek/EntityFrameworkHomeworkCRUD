using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.CarServices;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ICarService _crs;
        public CarController(ICarService crs)
        {
            _crs = crs;
        }
        [HttpPost]
        public async Task <string> Create(CarDTO cd)
        {
            return await _crs.Create(cd);
        }
        [HttpGet]
        public async Task<List<Car>> Read()
        {
            return await _crs.Read();
        }
        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            return await _crs.Delete(id);
        }
        [HttpPut]
        public async Task<string> Update(int id, CarDTO cd)
        {
            return await _crs.UpdateById(id, cd);
        }
    }
}
