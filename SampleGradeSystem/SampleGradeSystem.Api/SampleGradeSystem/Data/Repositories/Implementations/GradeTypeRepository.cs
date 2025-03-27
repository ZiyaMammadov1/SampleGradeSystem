using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Data.Repositories.Interfaces;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Data.Repositories.Implementations;
public class GradeTypeRepository : Repository<GradeType>
{
    public GradeTypeRepository(DbContext context) : base(context) { }
}