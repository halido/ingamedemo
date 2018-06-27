using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace InGame.BestPractice.Localization
{
    public static class BestPracticeLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BestPracticeConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BestPracticeLocalizationConfigurer).GetAssembly(),
                        "InGame.BestPractice.Localization.SourceFiles"
                    )
                )
            );
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BestPracticeConsts.LocalizationCustomName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BestPracticeLocalizationConfigurer).GetAssembly(),
                        "InGame.BestPractice.Localization.Custom"
                    )
                )
            );
        }
    }
}
