using WebApplication1.Models;

namespace WebApplication1.CarServices
{
    public interface ICarService
    {
        public Task<string> Create(CarDTO cd);
        public Task<string> Delete(int id);
        public Task<List<Car>> Read();
        public Task<string> UpdateById(int id,CarDTO dt);

    }
}
