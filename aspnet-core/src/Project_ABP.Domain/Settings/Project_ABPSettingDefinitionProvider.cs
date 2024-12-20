using Volo.Abp.Settings;

namespace Project_ABP.Settings;

public class Project_ABPSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(Project_ABPSettings.MySetting1));
    }
}
