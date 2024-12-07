using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Service;

public class EmployeeService: IServices<Employee>
{
    DapperContext _context;

    public EmployeeService()
    {
        _context = new DapperContext();
    }

    public List<Employee> GetAll()
    {
        return _context.GetConnection().Query<Employee>("SELECT * FROM Employee").ToList();
    }

    public Employee GetById(int id)
    {
        return _context.GetConnection().QueryFirstOrDefault<Employee>("SELECT * FROM Employee WHERE Id = @Id", new { Id = id });
    }

    public bool Add(Employee entity)
    {
        return _context.GetConnection().Execute("insert into Employee (FirstName, LastName,Email,PhoneNumber,Address,HireDate,BranchId) values (@FirstName, @LastName,@Email,@PhoneNumber,@Address,@HireDate,@BranchId)", entity)>0;
    }

    public bool Update(Employee entity)
    {
        return _context.GetConnection().Execute("update Employee set FirstName=@FirstName, LastName=@LastName, Email=@Email, PhoneNumber=@PhoneNumber, Address=@Address, HireDate=@HireDate, BranchId=@BranchId where Id=@Id", entity)>0;
    }

    public bool Delete(int id)
    {
        return _context.GetConnection().Execute("delete from Employee where Id=@Id", new { Id = id }) > 0;
    }
}