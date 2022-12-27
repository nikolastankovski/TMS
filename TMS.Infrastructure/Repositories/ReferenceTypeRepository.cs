using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Repositories;

namespace TMS.Infrastructure.Repositories
{
    public class ReferenceTypeRepository : Repository<ReferenceType>, IReferenceTypeRepository
    {
        public ReferenceTypeRepository(TMSDbContext context, ILogger<ReferenceType> logger) : base(context, logger) { }
    }
}
