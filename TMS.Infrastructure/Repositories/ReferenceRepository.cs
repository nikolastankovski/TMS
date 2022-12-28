using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Repositories;

namespace TMS.Infrastructure.Repositories
{
    public class ReferenceRepository : Repository<Reference>, IReferenceRepository
    {
        private readonly TMSDbContext _context;
        public ReferenceRepository(TMSDbContext context, ILogger<Reference> logger) : base(context, logger) 
        {
            _context = context;
        }
    }
}
