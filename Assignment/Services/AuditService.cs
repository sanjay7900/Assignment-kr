using Assignment.DBContextManager;
using Assignment.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Services
{
    public class AuditService:IAudit
    {
        private readonly ProductAppContext _context;

        public AuditService(ProductAppContext productAppContext)
        {
            _context=productAppContext; 
            
        }
        public async Task<List<AuditLog>> GetAll()
        {
           return await _context.AuditLogs.ToListAsync();
            
        }
    }
}
