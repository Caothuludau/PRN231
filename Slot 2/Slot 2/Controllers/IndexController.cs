using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Slot_2.Controllers
{
    [Route("[controller]")] //B1: Config lai route, yeu cau chi la Index thi xoa api/ di
    [ApiController]
    public class IndexController : ControllerBase //Lop controller base chua cac method xu ly data
    {
        [HttpGet]
        public string Index()
        {
            return "oke";
        }
    }
}
