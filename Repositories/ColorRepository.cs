using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using roadlovers.Models;
using roadlovers.Persistence;

namespace roadlovers.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private FactoryContext _context;

        public ColorRepository(FactoryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Color> FindAll()
        {
            return _context.Colors.ToList();
        }

        public IList<Color> FindAllByCarId(int id)
        {
            return _context
                        .VehiclesColors
                        .Where(s => s.CarId == id)
                        .Select(s => s.Color)
                    .ToList()
                    ;
        }

        public void Store(Color color)
        {
            _context.Colors.Add(color);
        }
    }
}