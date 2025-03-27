using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Data.Repositories.Interfaces;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Data.Repositories.Implementations;
public class PositionRepository : Repository<Position>
{
    public PositionRepository(DbContext context) : base(context) { }
}
