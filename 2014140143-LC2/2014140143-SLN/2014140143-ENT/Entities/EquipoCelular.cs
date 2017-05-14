using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.Entities
{
   public class EquipoCelular
    {
        public int EquipoCelularId { get; set; }

        int _CodigoCelular;
        String _Marca;
        String _Modelo;
        String _Imei;
        String _Color;
        Double _Precio;
        int _Stock;

        public EquipoCelular(int codigoCelular, String marca, String modelo, String imei, String color, Double precio, int stock)
        {
            CodigoCelular = codigoCelular;
            Marca = marca;
            Modelo = modelo;
            Modelo = modelo;
            Imei = imei;
            Color = color;
            Precio = precio;
            Stock = stock;
        }
        public int CodigoCelular
        {
            get { return _CodigoCelular; }
            set { _CodigoCelular = value; }
        }
        public String Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        public String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }
        public String Imei
        {
            get { return _Imei; }
            set { _Imei = value; }
        }
        public String Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        public Double Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public int Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }

    }
}
