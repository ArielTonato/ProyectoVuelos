﻿using proyecto.fisei.vuelos.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.fisei.vuelos.ContratoRepositorio
{
    public interface IAuthRepositorio
    {
        Usuario IniciarSesion(Usuario usuario);
    }
}
