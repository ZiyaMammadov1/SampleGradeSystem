using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Data.Repositories.Interfaces;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Data.Repositories.Implementations;

public class WarehouseRepository : Repository<Warehouse>
{
    public WarehouseRepository(DbContext context) : base(context) { }
}
