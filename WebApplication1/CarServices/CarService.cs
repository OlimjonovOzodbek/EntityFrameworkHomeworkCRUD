
using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure;
using WebApplication1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication1.CarServices
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;
        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(CarDTO cd)
        {
            try
            {

                var model = new Car
                {
                    Name = cd.Name,
                    Model = cd.Model,
                    Price = cd.Price,
                };
                await _context.Cars.AddAsync(model);
                _context.SaveChanges();
                return "Yozildi";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public async Task<string> Delete(int id)
        {
            var md = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (md != null)
            {
                _context.Cars.Remove(md);
                _context.SaveChanges();
                return "O'chirildi";
            }
            return "Error";
        }

        public async Task<List<Car>> Read()
        {
            var x = await _context.Cars.ToListAsync();
            return x;
        }

        public async Task<string> UpdateById(int id, CarDTO dt)
        {
            var md = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (md != null)
            {
                md.Name = dt.Name;
                md.Price = dt.Price;
                md.Model = dt.Model;
                await _context.SaveChangesAsync();
                return "Yangilandi";
            }
            return "Hatooo";
        }
    }
}
