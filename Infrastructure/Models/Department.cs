namespace Infrastructure.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public int CompanyId { get; set; }

}