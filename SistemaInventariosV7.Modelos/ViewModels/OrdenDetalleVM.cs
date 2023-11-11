﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariosV7.Modelos.ViewModels
{
    public class OrdenDetalleVM
    {
        public Compania Compania { get; set; }

        public Orden Orden { get; set; }

        public IEnumerable<OrdenDetalle> OrdenDetalleLista { get; set; }
    }
}
