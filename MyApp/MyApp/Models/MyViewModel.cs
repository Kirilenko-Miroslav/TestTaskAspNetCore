using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class MyViewModel
    {
        public List<Data> Data { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }
}
