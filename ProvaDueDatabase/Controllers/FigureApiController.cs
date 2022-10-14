using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FigureApiController : ControllerBase
    {
        private readonly IFiguraService _figuraService;

        public FigureApiController(IFiguraService figuraService)
        {
            _figuraService = figuraService;
        }

        [HttpGet]
        public JsonResult getAll()
        {
            List<FiguraDto> listaFigure;
            listaFigure = _figuraService.GetAll().ToList();
            return new JsonResult(listaFigure.ToArray());
        }
    }
}
