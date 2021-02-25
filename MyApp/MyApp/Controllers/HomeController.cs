using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyApp.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EFDBContext _context;
        public HomeController(ILogger<HomeController> logger, EFDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFileCollection uploads)
        {
            foreach (IFormFile file in uploads)
            {
                IWorkbook workbook = null;
                using (var fileStream = new FileStream(file.FileName, FileMode.Open, FileAccess.Read))
                { 
                    try
                    {
                        workbook = WorkbookFactory.Create(fileStream);
                    }
                    catch
                    {
                        continue;
                    }
                }
                if (workbook != null)
                {
                    ISheet sheet = workbook.GetSheetAt(0);
                    foreach (IRow row in sheet)
                    {
                        if (row.GetCell(0) != null) //Я не очень понял условия задания. Если нам нельзя пропускать в БД строки где есть пустые
                        {                           //значения, то все проверки на то является ли ячейка пустой стоит вставить в этот первый if
                            if (DateTime.TryParse(row.GetCell(0).StringCellValue, out DateTime dateTime)) 
                            {
                                Data data = new Data();
                                data.Date = dateTime;
                                if (row.GetCell(1) != null)
                                    data.Time = row.GetCell(1).StringCellValue;
                                else data.Time = data.Date.ToShortTimeString();
                                data.T = ChechNum(row.GetCell(2));
                                data.Humidity = ChechNum(row.GetCell(3));
                                data.Td = ChechNum(row.GetCell(4));
                                data.Pressure = ChechNum(row.GetCell(5));
                                data.WindDir = CheckStr(row.GetCell(6));
                                data.WindSpeed = ChechNum(row.GetCell(7));
                                data.Cloudy = ChechNum(row.GetCell(8));
                                data.H = ChechNum(row.GetCell(9));
                                data.VV = ChechNum(row.GetCell(10));
                                data.Conditions = CheckStr(row.GetCell(11));
                                _context.Data.Add(data);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Succes");
        }
        private string CheckStr(ICell cell)
        {
            if (cell != null)
                if (cell.CellType == CellType.String)
                    return cell.StringCellValue;
            return null;
        }
        private double? ChechNum(ICell cell)
        {
            if (cell != null && cell.CellType == CellType.Numeric)
                return cell.NumericCellValue;
            else return null;
        }
        public IActionResult Succes()
        {
            return View();
        }
        public IActionResult DataView(string year, string month, int page = 1)
        {
            int pageSize = 8; // Параметр отображающий максимальное кол-во элементов в таблице на странице, можно менять если нужно
            IQueryable<Data> datas = _context.Data; //но значение 8 выбрано потому что в хороших условиях без пропуска данных в день у нас 8 строк
            MyViewModel model = new MyViewModel();  //а значит номер страницы совпадает с номером дня в месяце (как например в примере с 2011 годом)
            model.Year = year;
            model.Month = month;
            //фильтрация
            if (month != "Все" && !String.IsNullOrEmpty(month) && !String.IsNullOrEmpty(year))
            {
                datas = datas.Where(p => p.Date.Month.ToString() == month && p.Date.Year.ToString() == year);
            }
            else if (month != "Все" && !String.IsNullOrEmpty(month))
            {
                model.PageViewModel = new PageViewModel(0, page, pageSize);
                return View(model);
            }
            else if (!String.IsNullOrEmpty(year))
            {
                datas = datas.Where(p => p.Date.Year.ToString() == year);
            }
            var count = datas.Count();
            model.Data = datas.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            model.PageViewModel = new PageViewModel(count, page, pageSize);
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
