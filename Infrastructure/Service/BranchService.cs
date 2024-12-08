using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Service;

public class BranchService:IServices<Branch>
{
    readonly DapperContext _context;

    public BranchService()
    {
        _context = new DapperContext();
    }


    public List<Branch> GetAll()
    {
        var res = _context.GetConnection().Query<Branch>("SELECT * FROM Branch").ToList();
        return res;
    }

    public Branch GetById(int id)
    {
        var res = _context.GetConnection().QueryFirstOrDefault<Branch>("SELECT * FROM Branch WHERE Id = @Id", new { Id = id });
        return res;
    }

    public bool Add(Branch entity)
    {
        var res = _context.GetConnection().Execute("INSERT INTO Branch (Name,Description,DepartmentId) VALUES (@Name,@Description,@DepartmentId)", entity);
        return res > 0;
    }

    public bool Update(Branch entity)
    {
        var res = _context.GetConnection().Execute("Update Branch set Name=@Name,Description=@Description,DepartmentId=@DepartmentId where Id=@Id", entity);
        return res > 0;
    }

    public bool Delete(int id)
    {
        var res = _context.GetConnection().Execute("DELETE FROM Branch WHERE Id = @Id", new { Id = id });
        return res > 0;
    }
}