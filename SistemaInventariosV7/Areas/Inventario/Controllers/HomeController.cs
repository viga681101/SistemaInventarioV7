using Microsoft.AspNetCore.Mvc;
using SistemaInventariosV7.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventariosV7.Modelos;
using SistemaInventariosV7.Modelos.ViewModels;
using System.Diagnostics;

namespace SistemaInventariosV7.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnidadTrabajo _unidadTrabajo;
        public HomeController(ILogger<HomeController> logger, IUnidadTrabajo unidadTrabajo)
        {
            _logger = logger;
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task <IActionResult> Index()
        {
            IEnumerable<Producto> productoLista = await _unidadTrabajo.Producto.ObtenerTodos(); 
            return View(productoLista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}