using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProyectoManicura2025V4.BD.Datos.Entidades
{
    public class Cliente : Entitybase
    {
        
        public string NombreCliente { get; set; }

        public required string Telefono { get; set; }

        
    }
}
