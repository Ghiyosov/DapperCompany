using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Service;

public class CompanyService: IServices<Company>
{
    DapperContext _context;

    public CompanyService()
    {
        _context = new DapperContext();
    }

    public List<Company> GetAll()
    {
        return _context.GetConnection().Query<Company>("SELECT * FROM Company").ToList();
    }

    public Company GetById(int id)
    {
        return _context.GetConnection().QueryFirstOrDefault<Company>("SELECT * FROM Company WHERE Id = @Id", new { Id = id });
    }

    public bool Add(Company entity)
    {
        return _context.GetConnection().Execute("INSERT INTO Company (Name,Address,Description) VALUES (@Name,@Address,@Description)",entity)>0;
    }

    public bool Update(Company entity)
    {
        return _context.GetConnection().Execute("update Company set Name=@Name,Address=@Address,Description=@Description where Id=@Id",entity)>0;
    }

    public bool Delete(int id)
    {
        return _context.GetConnection().Execute("delete from Company WHERE Id = @Id",new { Id = id })>0;
    }
}