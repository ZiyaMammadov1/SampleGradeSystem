using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Data.Repositories.Interfaces;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Data.Repositories.Implementations;

public class GradeRepository : Repository<Grade>
{
    public GradeRepository(DbContext context) : base(context) { }
}
