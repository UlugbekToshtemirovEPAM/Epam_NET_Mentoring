﻿using ConfigurationApp1.Attributes;

namespace ConfigurationApp2.Logic
{
    public class ApplicationlogicService
    {
        public void LoadSettings()
        {
            foreach (var prop in GetType().GetProperties())
            {
                foreach (ConfigurationItemAttribute attr in prop.GetCustomAttributes(typeof(ConfigurationItemAttribute), false))
                {
                    var value = attr.GetValue();
                    if (value != null)
                    {
                        prop.SetValue(this, Convert.ChangeType(value, prop.PropertyType));
                    }
                }
            }
        }

        public void SaveSettings()
        {
            foreach (var prop in GetType().GetProperties())
            {
                foreach (ConfigurationItemAttribute attr in prop.GetCustomAttributes(typeof(ConfigurationItemAttribute), false))
                {
                    attr.SetValue(prop.GetValue(this));
                }
            }
        }
    }
}