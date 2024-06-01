using Assignment.Models.DataModels;

namespace Assignment.Services
{
    public interface IAudit
    {
        Task<List<AuditLog>> GetAll();
    }
}
