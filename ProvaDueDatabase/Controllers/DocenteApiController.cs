using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Models.Dto;
using ProvaDueDatabase.Services;
using System.Text.Json;
using Newtonsoft.Json;
using ProvaDueDatabase.Hubs;
using ProvaDueDatabase.Models.Enity;

namespace ProvaDueDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteApiController : ControllerBase
    {
        private readonly IFiguraService _figuraService;
        private readonly IFigureDomandeService _figureDomandeService;
        private readonly IRispostaService rispostaService;
        
        

        public DocenteApiController(IFiguraService figuraService, IFigureDomandeService figureDomandeService, IRispostaService rispostaService)
        {
            _figuraService = figuraService;
            _figureDomandeService = figureDomandeService;
            this.rispostaService = rispostaService;
        }
        [HttpGet("{id}")]
        public JsonResult Start(int ?id)
        {
            List<FiguraDto> listaFigure;

            if (id == null)
            {
                listaFigure = _figuraService.GetAll().ToList();
                
            }
            else
            {
                listaFigure = _figuraService.GetAll().Where(f => f.Id == id).ToList();
            }
            return new JsonResult(listaFigure.ToArray());
        }

        [HttpGet("{idFigura}/{idDomanda}")]
        public JsonResult getRisposte(int idFigura, int idDomanda)
        {
            
            
            int idFiguraDomanda = _figureDomandeService.Trova(idFigura, idDomanda);

            List<Risposta> listaRisposte = rispostaService.GetAllByIdFD(idFiguraDomanda).ToList();

            return new JsonResult(listaRisposte.ToArray());

        }

    }
}
