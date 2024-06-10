using ConfigurationApp1.Attributes;

namespace ConfigurationApp1
{
    public class MySettings : ConfigurationComponentBase
    {
        [FileConfigurationItem("MyIntSetting")]
        [ConfigurationManagerConfigurationItem("MyIntSetting")]
        public int MyIntSetting { get; set; }

        [FileConfigurationItem("MyFloatSetting")]
        [ConfigurationManagerConfigurationItem("MyFloatSetting")]
        public float MyFloatSetting { get; set; }

        [FileConfigurationItem("MyStringSetting")]
        [ConfigurationManagerConfigurationItem("MyStringSetting")]
        public string MyStringSetting { get; set; }
    }
}
