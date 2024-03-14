using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Data;


namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
    private readonly ApplicationDBContex _context;

            public EmployeeController(ApplicationDBContex context) 
            {
                _context = context;
            }

            public IActionResult Registration()
            {
                return View(new Employee());
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(Employee emp)
        {
            
            var email = _context.employees.Where(x => x.Email == emp.Email).FirstOrDefault();
            if(email == null)
            {
                _context.employees.Add(emp);
                _context.SaveChanges();

                return RedirectToAction("GetEmployees");
            }
            else
            {
                TempData["message"] = "Email Already exist";
                return RedirectToAction("Registration");
            }
        }
        public IActionResult Index()
            {
                return View();
            }

        public IActionResult GetEmployees(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            var dataList = _context.employees.AsQueryable();

            // Search functionality
            if (!string.IsNullOrEmpty(searchString))
            {
                dataList = dataList.Where(p => p.Name.Contains(searchString));
            }

            // Calculate total records and total pages
            var totalRecords = dataList.Count(); // Total number of records
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Ensure pageNumber stays within bounds
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));

            // Handle edge cases
            if (totalRecords == 0)
            {
                // No records found, return empty view
                ViewData["PageNumber"] = 0;
                ViewData["TotalPages"] = 0;
                return View(new List<Employee>());
            }

            // Retrieve paginated records
            var paginatedEmployees = dataList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewData["PageNumber"] = pageNumber;
            ViewData["TotalPages"] = totalPages;

            return View(paginatedEmployees);
        }

        //List<Employee> dataList = _context.employees.ToList();

        //return View(dataList);


        public IActionResult EditEmployee(int id )
        {
            var obj = _context.employees.Where(x => x.Id==id).FirstOrDefault() ;
            
            return PartialView("Views/Employee/_EditEmployee.cshtml" , obj);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee empl)
        {

            _context.employees.Update(empl);
            _context.SaveChanges();

            return RedirectToAction("GetEmployees");
        }
        public IActionResult DeleteEmployee(int id)
        {
            var obj = _context.employees.Where(x => x.Id == id).FirstOrDefault();

            _context.employees.Remove(obj);
            _context.SaveChanges();

            return RedirectToAction("GetEmployees");
        }

        public IActionResult ViewEmployee(int id)
        {
            var obj = _context.employees.Where(x => x.Id == id).FirstOrDefault();

            return PartialView("Views/Employee/_viewEmployee.cshtml", obj);
        }

        //public IActionResult EditEmployee(Employee empl)
        //{
        //    // Retrieve the existing entity from the database
        //    var existingEmployee = _context.employees.Find(empl.Id);

        //    if (existingEmployee != null)
        //    {
        //        // Update the properties of the existing entity
        //        existingEmployee.Name = empl.Name;
        //        existingEmployee.office = empl.office;
        //        existingEmployee.Position = empl.Position;
        //        existingEmployee.Password = empl.Password;
        //       // Save the changes to the database
        //        _context.SaveChanges();
        //    }

        //    return RedirectToAction("GetEmployees");
        //}

    }
}
