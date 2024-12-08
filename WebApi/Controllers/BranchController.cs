using Infrastructure.Models;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BranchController
{
    readonly BranchService branchService;

    public BranchController()
    {
        branchService = new BranchService();
    }

    [HttpGet("GetAllBranches")]
    public List<Branch> GetAllBranches()
    {
        return branchService.GetAll();
    }

    [HttpGet("GetBranchById/{id}")]
    public Branch GetBranchById(int id)
    {
        return branchService.GetById(id);
    }

    [HttpPost("AddBranch")]
    public bool AddBranch(Branch branch)
    {
        return branchService.Add(branch);
    }

    [HttpPut("UpdateBranch")]
    public bool UpdateBranch(Branch branch)
    {
        return branchService.Update(branch);
    }

    [HttpDelete("DeleteBranch/{id}")]
    public bool DeleteBranch(int id)
    {
        return branchService.Delete(id);
    }
}