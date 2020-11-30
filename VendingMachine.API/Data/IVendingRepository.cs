using System.Collections.Generic;
using System.Threading.Tasks;
using VendingMachine.API.Models;

namespace VendingMachine.API.Data
{
    public interface IVendingRepository
    {
         Task<IEnumerable<Can>> GetCans();
         Task<Can> GetCan(int id);
         Task<bool> SaveAll();
         Task<int> UpdateStock(int id);
    }
}