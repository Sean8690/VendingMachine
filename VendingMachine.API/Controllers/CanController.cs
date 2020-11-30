using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingMachine.API.Data;

namespace VendingMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanController : ControllerBase
    {
        public IVendingRepository _repo;
        public CanController(IVendingRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCans()
        {
            var can = await _repo.GetCans();

            return Ok(can);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> BuyCan(int id)
        {
            var canFromRepo = await _repo.GetCan(id);

            if (canFromRepo != null)
            {
                if (canFromRepo.NumCans == 0)
                {
                    return BadRequest("Out of Stock");
                }
            }

            await _repo.UpdateStock(id);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to buy a can");
        }
    }
}