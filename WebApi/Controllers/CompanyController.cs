using Infrastructure.Models;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CompanyController
{
    readonly CompanyService company;

    public CompanyController()
    {
        company = new CompanyService();
    }

    [HttpGet("getCompany")]
    public List<Company> GetCompanies()
    {
        return company.GetAll();
    }

    [HttpGet("getCompany/{id}")]
    public Company GetCompany(int id)
    {
        return company.GetById(id);
    }

    [HttpPost("addCompany")]
    public bool AddCompany(Company company)
    {
        return this.company.Add(company);
    }

    [HttpPut("updateCompany")]
    public bool UpdateCompany(Company company)
    {
        return this.company.Update(company);
    }

    [HttpDelete("deleteCompany/{id}")]
    public bool DeleteCompany(int id)
    {
        return this.company.Delete(id);
    }
}