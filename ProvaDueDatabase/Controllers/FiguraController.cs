using Microsoft.AspNetCore.Mvc;
using ProvaDueDatabase.Models;
using ProvaDueDatabase.Services;

namespace ProvaDueDatabase.Controllers
{
    public class FiguraController : Controller
    {
        public IFiguraService _service;

        public FiguraController(IFiguraService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            try
            {
                FiguraDto model = new FiguraDto();
                IEnumerable<FiguraDto> listaFigure = _service.GetAll();

                    //FiguraDto myViewModel = new FiguraDto();
                    //myViewModel.Id = figure.Id;
                    //MemoryStream ms = new MemoryStream(figure.File);
                    //myViewModel.Immagine = (Bitmap)new ImageConverter().ConvertFrom(figure.File);
                    //lista.Add(myViewModel);

                MyViewFigure mvf = new MyViewFigure();
                mvf.figures = listaFigure;
                return View(mvf);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

       

        public IActionResult Trova()
        {
            IEnumerable<FiguraDto> listaFigure = _service.GetAll("numero 2");
            return View(listaFigure);
        }

      
    }
}
