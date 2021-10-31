using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.Unit_of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarParkDbContext _context;

        public UnitOfWork(CarParkDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
