﻿using SistemaInventariosV7.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariosV7.AccesoDatos.Repositorio.IRepositorio
{
    public interface IMarcaRepositorio: IRepositorio<Marca>
    {
        void Actualizar(Marca marca);
    }
}
