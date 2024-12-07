using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Service;

public class DepartmentService:IServices<Department>
{
    DapperContext _context;

    public DepartmentService()
    {
        _context = new DapperContext();
    }


    public List<Department> GetAll()
    {
        return _context.GetConnection().Query<Department>("SELECT * FROM Department").ToList();
    }

    public Department GetById(int id)
    {
        return _context.GetConnection().QueryFirstOrDefault<Department>("SELECT * FROM Department WHERE Id = @Id", new { Id = id });
    }

    public bool Add(Department entity)
    {
        return _context.GetConnection().Execute("INSERT INTO Department (Name,Address,Description,CompanyId) VALUES (@Name,@Address,@Description,@CompanyId)", entity) > 0;
    }

    public bool Update(Department entity)
    {
        return _context.GetConnection().Execute("update Department set Name=@Name, Address=@Address, Description=@Description, CompanyId=@CompanyId where Id=@Id", entity) > 0;
    }

    public bool Delete(int id)
    {
        return _context.GetConnection().Execute("delete from Department where Id=@Id", id) > 0;
    }
}