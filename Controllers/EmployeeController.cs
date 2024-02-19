using Entity.Entity;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EntityDbContext dbContext;
        public EmployeeController(EntityDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        //insert DATA To a database
        [HttpGet]
        public IActionResult Add()
        {
            var employeeModel = new EmployeeModel();
            return View(employeeModel);
        }
        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            var employee = new Employee
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                Email = emp.Email,
                DateOfBirth = emp.DateOfBirth
            };
            dbContext.EmployeeTable.Add(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Add");
        }
        //ViewData Code
        public IActionResult View()
        {
            var employee = dbContext.EmployeeTable.ToList();
            return View(employee);
        }
        //////Update Database/////////
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var employee = dbContext.EmployeeTable.FirstOrDefault(x => x.Id == Id);
            if (employee != null)
            {
                var UpdateModel = new EmployeeUpdateModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    DateOfBirth = employee.DateOfBirth,
                };
                return View(UpdateModel);
            }
            return RedirectToAction("View");

        }
        [HttpPost]
        public IActionResult Update(EmployeeUpdateModel emp)
        {
            var employee = dbContext.EmployeeTable.Find(emp.Id);
            if (employee != null)
            {
                employee.Name = emp.Name;
                employee.Salary = emp.Salary;
                employee.Email = emp.Email;
                employee.DateOfBirth = emp.DateOfBirth;
                dbContext.SaveChanges();
                return RedirectToAction("View");
            }
            return Redirect("View");
        }
        ////Delete 
        [HttpPost]
        public IActionResult Delete(EmployeeUpdateModel emp)
        {
            var employee = dbContext.EmployeeTable.Find(emp.Id);
            if (employee != null)
            {
                dbContext.EmployeeTable.Remove(employee);
                dbContext.SaveChanges();
                return RedirectToAction("View");
            }
            return RedirectToAction("View");
        }


    }

}

