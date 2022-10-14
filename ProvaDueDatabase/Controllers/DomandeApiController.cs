using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomandeApiController : ControllerBase
    {
        private readonly IDomandaService _domandaService;

        public DomandeApiController(IDomandaService domandaService)
        {
            _domandaService = domandaService;
        }

        [HttpGet("{id}")]
        public JsonResult getDomanda(int id)
        {
            DomandaDto domanda = _domandaService.FindById(id);
            return new JsonResult(domanda);
        }
    }
}
