using Microsoft.Extensions.Localization;
using Project_ABP.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Project_ABP;

[Dependency(ReplaceServices = true)]
public class Project_ABPBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<Project_ABPResource> _localizer;

    public Project_ABPBrandingProvider(IStringLocalizer<Project_ABPResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
