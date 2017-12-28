using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
//
using IHIS.Framework;

namespace IHIS
{
    public static class IHISUtility
    {
        /// <summary>
        /// Modify app.config by change pair of key-value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        public static void UpdateSetting(string key, string newValue)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (configuration.AppSettings != null)
                {
                    configuration.AppSettings.Settings[key].Value = newValue;
                    configuration.Save();
                }

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("Update app.config failed. Message: " + ex.Message);
                Logs.EndWriteLog();
            }
        }
    }
}
