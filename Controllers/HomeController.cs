using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _EmployeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository EmployeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _EmployeeRepository = EmployeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }// Constructor Injection Here

        public IActionResult Index(int? id) // To View the Employees from Database
        {
          
                Employee model = _EmployeeRepository.GetEmployee(id ?? 5);
            if(model == null)
            {
                Response.StatusCode = 400;
                return View("Error_Code", id.Value);
            }
                return View(model);
        }

        public ViewResult List()
        {
            var Employee = _EmployeeRepository.GetAllList();
            return View(Employee);
        }

        public JsonResult data()
        {
            var Employee = _EmployeeRepository.GetAllList();
            return Json(Employee);
        }
      

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            ViewBag.DepartmentList = _EmployeeRepository.GetAllList();
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                String UniqueFileName = ProcessUploadedFile(model);
               
                Employee employee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = UniqueFileName
                };
                _EmployeeRepository.AddEmploye(employee);
                return RedirectToAction("Index", new { id = employee.id });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                Employee employee = _EmployeeRepository.GetEmployee(id);
                EmployeeEditViewModel UserData = new EmployeeEditViewModel()
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department,
                    ExistingPhotoPath = employee.PhotoPath
                };
                return View(UserData);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {

                Employee employee1 = _EmployeeRepository.GetEmployee(model.id);
                employee1.Name = model.Name;
                employee1.Email = model.Email;
                employee1.Department = model.Department.Value;

                if(model.Photo != null)
                {
                    string UniqueFileName = ProcessUploadedFile(model);
                    if(model.ExistingPhotoPath != null)
                    {
                        String Filepath = Path.Combine(hostingEnvironment.WebRootPath, "/Images/", model.ExistingPhotoPath);
                        System.IO.File.Delete(Filepath);
                    }
                }

                _EmployeeRepository.Update(employee1);
                return RedirectToAction("Index", new { id = employee1.id });
            }
            else
            {
                return View();
            }
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            String UniqueFileName = null;
            if (model.Photo != null)
            {
                var filePaths = new List<string>();
                String upload = Path.Combine(hostingEnvironment.WebRootPath + "/Images");

                UniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                String FilePath = Path.Combine(upload, UniqueFileName);

                filePaths.Add(FilePath);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    model.Photo.CopyTo(stream);
                }
            }

            return UniqueFileName;
        }

        public IActionResult Delete(int id)
        {
            var emp = _EmployeeRepository.Delete(id);
            return View(emp);
        }

        public IActionResult Grid()
        {
            var Employee = _EmployeeRepository.GetAllList();
            return View(Employee);
        }

        public IActionResult Update(int id)
        {
            
            return View();
        }

    }
}
