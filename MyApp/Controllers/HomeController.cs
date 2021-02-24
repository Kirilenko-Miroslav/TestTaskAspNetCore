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
            if (uploads.Count == 0)
            {
                //тут можно было бы выводить подсказку что не загружено ни одного файла
            }
            foreach (IFormFile file in uploads)
            {
                IWorkbook workbook = null;
                using (var fileStream = new FileStream(file.FileName, FileMode.Open, FileAccess.Read))
                {
                    if (file.FileName.IndexOf(".xlsx") > 0)
                        try
                        {
                            workbook = new XSSFWorkbook(fileStream);
                        }
                        catch
                        {
                            continue;
                        }
                    else if (file.FileName.IndexOf(".xls") > 0)
                        try
                        {
                            workbook = new HSSFWorkbook(fileStream);
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
                                data.Date = dateTime.ToShortDateString();
                                if (row.GetCell(1) != null)
                                    if (!String.IsNullOrEmpty(row.GetCell(1).StringCellValue))
                                        data.Time = row.GetCell(1).StringCellValue;
                                if (row.GetCell(1) == null)
                                    data.Time = dateTime.ToShortTimeString();
                                if (row.GetCell(2) != null)
                                    if (row.GetCell(2).CellType == CellType.Numeric)
                                        data.T = row.GetCell(2).NumericCellValue;
                                if (row.GetCell(3) != null)
                                    if (row.GetCell(3).CellType == CellType.Numeric)
                                        data.Humidity = row.GetCell(3).NumericCellValue;
                                if (row.GetCell(4) != null) 
                                    if (row.GetCell(4).CellType == CellType.Numeric)
                                        data.Td = row.GetCell(4).NumericCellValue;
                                if (row.GetCell(5) != null) 
                                    if (row.GetCell(5).CellType == CellType.Numeric)
                                        data.Pressure = row.GetCell(5).NumericCellValue;
                                if (row.GetCell(6) != null) 
                                    if (row.GetCell(6).CellType == CellType.String)
                                        data.WindDir = row.GetCell(6).StringCellValue;
                                if (row.GetCell(7) != null) 
                                    if (row.GetCell(7).CellType == CellType.Numeric)
                                        data.WindSpeed = row.GetCell(7).NumericCellValue;
                                if (row.GetCell(8) != null) 
                                    if (row.GetCell(8).CellType == CellType.Numeric)
                                        data.Cloudy = row.GetCell(8).NumericCellValue;
                                if (row.GetCell(9) != null) 
                                    if (row.GetCell(9).CellType == CellType.Numeric)
                                        data.H = row.GetCell(9).NumericCellValue;
                                if (row.GetCell(10) != null) 
                                    if (row.GetCell(10).CellType == CellType.Numeric)
                                        data.VV = row.GetCell(10).NumericCellValue;
                                if (row.GetCell(11) != null)
                                    if (row.GetCell(11).CellType == CellType.String) 
                                        data.Conditions = row.GetCell(11).StringCellValue;
                                data.Year = data.Date.Substring(6);
                                _context.Data.Add(data);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Succes");
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
                datas = datas.Where(p => p.Date.Contains($".{month}.") && p.Year == year);
            }
            else if (month != "Все" && !String.IsNullOrEmpty(month))
            {
                model.PageViewModel = new PageViewModel(0, page, pageSize);
                return View(model);
            }
            else if (!String.IsNullOrEmpty(year))
            {
                datas = datas.Where(p => p.Year == year);
            }

            var count = datas.Count();
            model.Data = datas.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            model.PageViewModel = new PageViewModel(count, page, pageSize);
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
