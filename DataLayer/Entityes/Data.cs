using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class Data
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double? T { get; set; }
        public double? Humidity { get; set; }
        public double? Td { get; set; }
        public double? Pressure { get; set; }
        public string WindDir { get; set; }
        public double? WindSpeed { get; set; }
        public double? Cloudy { get; set; }
        public double? H { get; set; }
        public double? VV { get; set; }
        public string Conditions { get; set; }
        public string Year { get; set; } //Для фильтрации
    }
}
