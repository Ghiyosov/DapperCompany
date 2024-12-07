namespace Infrastructure.Models;

public class Branch
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; } 
}