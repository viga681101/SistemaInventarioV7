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
    public class UsuarioAplicacionRepositorio : Repositorio<UsuarioAplicacion>, IUsuarioAplicacionRepositorio
    {
        private readonly ApplicationDbContext _db;
        public UsuarioAplicacionRepositorio(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
       
    }
}
