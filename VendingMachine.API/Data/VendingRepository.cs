using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendingMachine.API.Models;
using System.Collections.Generic;
using VendingMachine.API.Dtos;
using System.Linq;

namespace VendingMachine.API.Data
{
    public class VendingRepository : IVendingRepository
    {
        private readonly DataContext _context;
        public VendingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Can>> GetAllCans()
        {
            return await _context.Cans.ToListAsync();
        }

        public async Task<Can> GetCan(int id)
        {
            var can = await _context.Cans
                .FirstOrDefaultAsync(c => c.Id == id);

            return can;
        }
        public async Task<IEnumerable<Can>> GetCans()
        {
           return await _context.Cans.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
          return await _context.SaveChangesAsync() > 0;
        }

        public async void UpdateInventory(List<RestockInventoryForUpdate> list)
        {
            foreach(var item in list)
            {
                var can = await GetCan(item.Id);
                var updateStock = can.NumCans + item.NumCans;
            }
        }

        public async Task<int> UpdateStock(int id)
        {      
           var can = await _context.Cans
                .FirstOrDefaultAsync(c => c.Id == id);

           var canStock = can.NumCans = can.NumCans - 1;

           return canStock;
        }
    }
}