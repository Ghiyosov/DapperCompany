using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Service;

public class CompanyService: IServices<Company>
{
    readonly DapperContext _context;

    public CompanyService()
    {
        _context = new DapperContext();
    }

    public List<Company> GetAll()
    {
        var res = _context.GetConnection().Query<Company>("SELECT * FROM Company").ToList();
        return res;
    }

    public Company GetById(int id)
    {
        var res = _context.GetConnection().QueryFirstOrDefault<Company>("SELECT * FROM Company WHERE Id = @Id", new { Id = id });
        return res; 
    }

    public bool Add(Company entity)
    {
        
        var res = _context.GetConnection().Execute("INSERT INTO Company (Name,Address,Description) VALUES (@Name,@Address,@Description)",entity);
        return res > 0;
    }

    public bool Update(Company entity)
    {
        var res = _context.GetConnection().Execute("update Company set Name=@Name,Address=@Address,Description=@Description where Id=@Id",entity);
        return res > 0;
    }

    public bool Delete(int id)
    {
        
        var res = _context.GetConnection().Execute("delete from Company WHERE Id = @Id",new { Id = id });
        return res > 0;
    }
}