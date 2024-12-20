using Project_ABP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Project_ABP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Project_ABPController : AbpControllerBase
{
    protected Project_ABPController()
    {
        LocalizationResource = typeof(Project_ABPResource);
    }
}
