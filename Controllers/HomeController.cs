using System.Collections;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Base;
using task.context;
using TaskManagerApp_Bunya.Models;

namespace TaskManagerApp_Bunya.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TASKContext _context;
        public HomeController(TASKContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            this._context = context;
        }
        #region Task
        public IActionResult Index()
        {
            ViewBag.Priority = _context.APriorities.ToList();
            ViewBag.Status = _context.AStatuses.ToList();
            return View();
        }
        //Load data from the table
        public ActionResult GetTaskList([FromBody] DataManagerRequest dm)
        {
            var _data = _context.Tasks.OrderByDescending(o => o.Id).ToList();
            IEnumerable data = _data;
            int count = _data.Count();
            DataOperations operation = new DataOperations();

            //Performing filtering operation
            if (dm.Where != null)
            {
                data = operation.PerformFiltering(data, dm.Where, "and");
                var filtered = (IEnumerable<object>)data;
                count = filtered.Count();
            }
            //Performing search operation
            if (dm.Search != null)
            {
                data = operation.PerformSearching(data, dm.Search);
                var searched = (IEnumerable<object>)data;
                count = searched.Count();
            }
            //Performing sorting operation
            if (dm.Sorted != null)
                data = operation.PerformSorting(data, dm.Sorted);

            //Performing paging operations
            if (dm.Skip != 0)
                data = operation.PerformSkip(data, dm.Skip);
            if (dm.Take != 0)
                data = operation.PerformTake(data, dm.Take);
            return dm.RequiresCounts ? new JsonResult(new { result = data, count = count }) : new JsonResult(data);
        }
        //Search records with due date parameters Method
        public ActionResult GetTaskSearch([FromBody] DataManagerRequest dm, string start_date, string end_date)
        {
            string dateformat = "dd/MM/yyyy";
            DateTime _date = DateTime.Now;
            DateTime _date2 = DateTime.Now;
            DateTime _startDate = DateTime.Now;
            DateTime _endDate = DateTime.Now;
            //start_date
            if (!string.IsNullOrEmpty(start_date))
            {
                if (!start_date.Contains("January 1, 0001"))
                {
                    if (DateTime.TryParseExact(start_date, dateformat, null, DateTimeStyles.None, out _date))
                    {
                        _startDate = _date;
                    }
                }
            }
            if (_startDate.Hour == 0)
            {
            }
            else
            {
                var tt = _startDate.Hour;
                var timediff = 24 - tt;
                _startDate = _startDate.AddHours(timediff);
            }
            //end_date
            if (!string.IsNullOrEmpty(end_date))
            {
                if (!end_date.Contains("January 1, 0001"))
                {
                    if (DateTime.TryParseExact(end_date, dateformat, null, DateTimeStyles.None, out _date2))
                    {
                        _endDate = _date2;
                    }
                }
            }

            if (_endDate.Hour == 0)
            {
            }
            else
            {
                var tt = _endDate.Hour;
                var timediff = 24 - tt;
                _endDate = _endDate.AddHours(timediff);
            }
            var _data = _context.Tasks.OrderByDescending(o => o.Id).ToList();
            IEnumerable data = _data;
            int count = 0;

            if ((start_date == null || start_date == "01/01/1970") && (end_date == null || end_date == "01/01/1970"))
            {
                data = _data.OrderByDescending(o => o.DueDate).ToList();
                count = _data.OrderByDescending(o => o.DueDate).ToList().Count();
            }
            else
            {
                data = _data.Where(x => x.DueDate.Value.Date >= _startDate.Date && x.DueDate.Value.Date <= _endDate.Date).OrderByDescending(o => o.Id).ToList();
                count = _data.Where(x => x.DueDate.Value.Date >= _startDate.Date && x.DueDate.Value.Date <= _endDate.Date).ToList().Count();
            }
            DataOperations operation = new DataOperations();
            //Performing filtering operation
            if (dm.Where != null)
            {
                data = operation.PerformFiltering(data, dm.Where, "and");
                var filtered = (IEnumerable<object>)data;
                count = filtered.Count();
            }
            //Performing search operation
            if (dm.Search != null)
            {
                data = operation.PerformSearching(data, dm.Search);
                var searched = (IEnumerable<object>)data;
                count = searched.Count();
            }
            //Performing sorting operation
            if (dm.Sorted != null)
                data = operation.PerformSorting(data, dm.Sorted);

            //Performing paging operations
            if (dm.Skip != 0)
                data = operation.PerformSkip(data, dm.Skip);
            if (dm.Take != 0)
                data = operation.PerformTake(data, dm.Take);

            return dm.RequiresCounts ? new JsonResult(new { result = data, count = count }) : new JsonResult(data);
        }
        //Load the Partial Form
        public ActionResult AddPartial([FromBody] CRUDModel<Models.Task> value)
        {
            ViewBag.Priority = _context.APriorities.ToList();
            ViewBag.Status = _context.AStatuses.ToList();
            return PartialView("_Partial", value.Value);
        }
        //Update Method
        public ActionResult DialogUpdate([FromBody] CRUDModel<Models.Task> value)
        {
            Models.Task table = _context.Tasks.FirstOrDefault(o => o.Id == value.Value.Id);
            if (table != null)
            {
                table.Title = value.Value.Title;
                table.Description = value.Value.Description;
                table.Status = value.Value.Status;
                table.DueDate = value.Value.DueDate;
                table.Priority = value.Value.Priority;
                table.LastUpdatedTimestamp = DateTime.Now;
                _context.Entry(table).CurrentValues.SetValues(value);
                _context.Entry(table).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                }
                catch
                {
                   
                }
            }

            return Json(value.Value);
        }
        //save Method
        public ActionResult DialogInsert([FromBody] CRUDModel<Models.Task> value)
        {
            Models.Task table = new Models.Task()
            {
                Title = value.Value.Title,
                Description = value.Value.Description,
                Status = value.Value.Status,
                DueDate = value.Value.DueDate,
                Priority = value.Value.Priority,
                CreationTimestamp = DateTime.Now,
            };
            _context.Tasks.Add(table);
            _context.SaveChanges();
            return Json(value.Value);
        }
        //Delete Method
        public ActionResult DeleteUrl([FromBody] CRUDModel<Models.Task> value)
        {
            string obj = Request.Headers["additional_key"]; //key1 
            _context.Tasks.Remove(_context.Tasks.FirstOrDefault(o => o.Id == Convert.ToInt32(obj)));
            int result = _context.SaveChanges();
            return Json(result);
        }
        #endregion
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
