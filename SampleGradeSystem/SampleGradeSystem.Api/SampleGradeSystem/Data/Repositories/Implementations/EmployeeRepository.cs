using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Data.Repositories.Implementations;

public class EmployeeRepository : Repository<Employee>
{
    public EmployeeRepository(DbContext context) : base(context) { }
}
