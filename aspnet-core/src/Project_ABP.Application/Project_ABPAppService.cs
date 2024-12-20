using System;
using System.Collections.Generic;
using System.Text;
using Project_ABP.Localization;
using Volo.Abp.Application.Services;

namespace Project_ABP;

/* Inherit your application services from this class.
 */
public abstract class Project_ABPAppService : ApplicationService
{
    protected Project_ABPAppService()
    {
        LocalizationResource = typeof(Project_ABPResource);
    }
}
