﻿using System.Configuration;

namespace ConfigurationApp1.Attributes
{
    public class ConfigurationManagerConfigurationItemAttribute : ConfigurationItemAttribute
    {
        public ConfigurationManagerConfigurationItemAttribute(string settingName) : base(settingName) { }

        public override object GetValue()
        {
            return ConfigurationManager.AppSettings[SettingName];
        }

        public override void SetValue(object value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(SettingName);
            config.AppSettings.Settings.Add(SettingName, value.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}