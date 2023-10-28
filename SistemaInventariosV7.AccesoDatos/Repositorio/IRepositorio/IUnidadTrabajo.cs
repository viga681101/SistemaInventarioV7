﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariosV7.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo: IDisposable
    {
        IBodegaRepositorio Bodega { get; }
        Task Guardar();

    }
}