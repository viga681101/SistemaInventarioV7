using SistemaInventariosV7.AccesoDatos.Data;
using SistemaInventariosV7.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventariosV7.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariosV7.AccesoDatos.Repositorio
{
    public class BodegaProductoRepositorio : Repositorio<BodegaProducto>, IBodegaProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BodegaProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(BodegaProducto bodegaProducto)
        {
            var bodegaProductoDB = _db.BodegasProductos.FirstOrDefault(b => b.Id == bodegaProducto.Id);
            if(bodegaProductoDB != null)
            {
                bodegaProductoDB.Cantidad = bodegaProducto.Cantidad;
                _db.SaveChanges();
            }
        }
    }
}
