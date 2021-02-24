using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)//класс для инициализации каких-либо данных без подключения сторонних библиотек и отправки данных
        {                                               //в готовом проекте по сути не нужен
            if(!context.Data.Any())
            {
                context.Data.Add(new Entityes.Data() { Date = "01.01.2010", Time = "03:00", T = -6, Humidity = 91, Td = -7.1, Pressure = 738, WindDir = "штиль", WindSpeed = 0, Cloudy = 100, H = 800, VV = 0, Conditions = "Дымка", Year = "2010"});
                context.Data.Add(new Entityes.Data() { Date = "02.01.2010", Time = "09:00", T = -12.1, Humidity = 95, Td = -12.7, Pressure = 741, WindDir = "С", WindSpeed = 1, Cloudy = 100, H = 450, VV = 2, Conditions = "Непрерывный слабый снег", Year = "2010" });
                context.SaveChanges();
            }
        }
    }
}
