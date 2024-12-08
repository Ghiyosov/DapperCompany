using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Service;

public class DepartmentService:IServices<Department>
{
    readonly DapperContext _context;

    public DepartmentService()
    {
        _context = new DapperContext();
    }


    public List<Department> GetAll()
    {
        var res = _context.GetConnection().Query<Department>("SELECT * FROM Department").ToList();
        return res;
    }

    public Department GetById(int id)
    {
        var res = _context.GetConnection().QueryFirstOrDefault<Department>("SELECT * FROM Department WHERE Id = @Id", new { Id = id });
        return res;
    }

    public bool Add(Department entity)
    {
        var res = _context.GetConnection().Execute("INSERT INTO Department (Name,Address,Description,CompanyId) VALUES (@Name,@Address,@Description,@CompanyId)", entity) ;
        return res > 0;
    }

    public bool Update(Department entity)
    {
        var res = _context.GetConnection().Execute("update Department set Name=@Name, Address=@Address, Description=@Description, CompanyId=@CompanyId where Id=@Id", entity) ;
        return res > 0;
    }

    public bool Delete(int id)
    {
        var res = _context.GetConnection().Execute("delete from Department where Id=@Id", id);
        return res > 0;
    }
}