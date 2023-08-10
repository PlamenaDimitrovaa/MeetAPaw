using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MeetAPaw.Common.GeneralApplicationConstants;

namespace MeetAPaw.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
       
    }
}
