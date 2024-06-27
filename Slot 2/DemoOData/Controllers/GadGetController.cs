using DemoOData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace DemoOData.Controllers
{
    [Route("gadget")]
    [ApiController]
    public class GadGetController : ControllerBase
    {
        private readonly _GadGetContext _myWorldDbContext;
        public GadGetController (_GadGetContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [EnableQuery]
        [HttpGet("Get")]
        public ActionResult Get()
        {
            return Ok(_myWorldDbContext.GadGets.AsQueryable());
        }
    }
}