using Infrastructure.Models;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class DepartmentController
{
    readonly DepartmentService _departmentService;

    public DepartmentController()
    {
        _departmentService = new DepartmentService();
    }

    [HttpGet("getAllDepartments")]
    public List<Department> GetAllDepartments()
    {
        return _departmentService.GetAll();
    }

    [HttpGet("getDepartmentById/{id}")]
    public Department GetDepartmentById(int id)
    {
        return _departmentService.GetById(id);
    }

    [HttpPost("addDepartment")]
    public bool AddDepartment(Department department)
    {
        return _departmentService.Add(department);
    }

    [HttpPut("updateDepartment")]
    public bool UpdateDepartment(Department department)
    {
        return _departmentService.Update(department);
    }

    [HttpDelete("deleteDepartment/{id}")]
    public bool DeleteDepartment(int id)
    {
        return _departmentService.Delete(id);
    }
}