using Infrastructure.Models;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class EmployeeController
{
    readonly EmployeeService employeeService;

    public EmployeeController()
    {
        employeeService = new EmployeeService();
    }

    [HttpGet("GetAllEmployees")]
    public List<Employee> GetAllEmployees()
    {
        return employeeService.GetAll();
    }

    [HttpGet("GetEmployeeById/{id}")]
    public Employee GetEmployeeById(int id)
    {
        return employeeService.GetById(id);
    }

    [HttpPost("AddEmployee")]
    public bool AddEmployee(Employee employee)
    {
        return employeeService.Add(employee);
    }

    [HttpPut("UpdateEmployee")]
    public bool UpdateEmployee(Employee employee)
    {
        return employeeService.Update(employee);
    }

    [HttpDelete("DeleteEmployee/{id}")]
    public bool DeleteEmployee(int id)
    {
        return employeeService.Delete(id);
    }
}