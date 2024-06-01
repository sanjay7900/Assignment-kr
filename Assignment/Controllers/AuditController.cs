using Assignment.Models.ViewModels;
using Assignment.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class AuditController : Controller
    {
        private readonly IAudit _auditcontext;
        private readonly IMapper _mapper;

        public AuditController(IAudit audit,IMapper mapper)
        {
            _auditcontext=audit; 
            _mapper=mapper; 
        }
        public async Task<IActionResult> Index()
        {
            var data =_mapper.Map<List<AuditViewModel>>( await _auditcontext.GetAll());
            return View(data.AsEnumerable<AuditViewModel>());
        }
    }
}
