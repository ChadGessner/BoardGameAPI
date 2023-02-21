using GC_EF_API_Example.DAL;
using GC_EF_API_Example.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC_EF_API_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        FishRepository repo = new FishRepository();
        [HttpPost("spawn")]
        public Fish AddFish(string name, string classification, bool fresh, bool salt)
        {
            Fish newFish = new Fish()
            {
                Name = name,
                Classification = classification,
                SaltWater= salt,
                FreshWater= fresh
            };
            return repo.AddFish(newFish);
        }
    }
}
