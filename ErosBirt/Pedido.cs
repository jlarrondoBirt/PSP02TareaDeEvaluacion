using System;
using System.Collections.Generic;
using System.Text;

namespace ErosBirt
{
    public class Pedido
    {
        // Número entre 0 y 29
        public int Id { get; set; }

        //Ropa, Electrónica o Juguetes
        public string TipoProducto { get; set; }

        // Para representar horas y minutos (16:35:00)
        public TimeSpan TiempoRespuesta { get; set; }

        public Pedido(int id, string tipoProducto, TimeSpan tiempoRespuesta)
        {
            Id = id;
            TipoProducto = tipoProducto;
            TiempoRespuesta = tiempoRespuesta;
        }
    }
}