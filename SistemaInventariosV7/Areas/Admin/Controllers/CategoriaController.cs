using Microsoft.AspNetCore.Mvc;
using SistemaInventariosV7.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventariosV7.Modelos;
using SistemaInventariosV7.Utilidades;

namespace SistemaInventariosV7.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public CategoriaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            Categoria categoria = new Categoria();

            if (id == null)
            {
                // Crear Categoria
                categoria.Estado = true;

                return View(categoria);
            }
            // Actualizamos Categoria
            categoria = await _unidadTrabajo.Categoria.Obtener(id.GetValueOrDefault());
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upsert(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Id == 0)
                {
                    await _unidadTrabajo.Categoria.Agregar(categoria);
                    TempData[DS.Exitosa] = "Registro guardado exitosamente";
                }
                else
                {
                    _unidadTrabajo.Categoria.Actualizar(categoria);
                    TempData[DS.Exitosa] = "Registro guardado exitosamente";
                }

                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }

            TempData[DS.Error] = "Error al guardar el registro";
            return View(categoria);
        }
        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Categoria.ObtenerTodos();

            return Json(new { data = todos });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var categoriaDB = await _unidadTrabajo.Categoria.Obtener(id);
            if (categoriaDB == null)
            {
                return Json(new { success = false, message = "Error al eliminar el Registro" });
            }
            _unidadTrabajo.Categoria.Remover(categoriaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Registro eliminado exitosamente" });


        }
        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Categoria.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());

            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && b.Id != id);

            }
            if (valor)
            {
                return Json(new { data = true });
            }
            else
            {
                return Json(new { data = false, });
            }
        }
        #endregion
    }
}
