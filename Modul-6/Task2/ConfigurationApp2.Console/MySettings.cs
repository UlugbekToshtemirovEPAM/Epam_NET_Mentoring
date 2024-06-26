﻿using ConfigurationApp2.Console.Attributes;
using ConfigurationApp2.Logic;

namespace ConfigurationApp2.Console
{
    public class MySettings : ApplicationlogicService
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
