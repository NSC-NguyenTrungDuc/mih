using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    class RegistryManager
    {
        private string userName;
        public string UserName
        {
            get { return Environment.UserName; }
            set { userName = value; }
        }
        private bool showError = false;
        /// <summary>
        /// A property to show or hide error messages 
        /// (default = false)
        /// </summary>
        public bool ShowError
        {
            get { return showError; }
            set { showError = value; }
        }

        private string subKey = "SOFTWARE\\" + Application.ProductName.ToUpper();
        /// <summary>
        /// A property to set the SubKey value
        /// (default = "SOFTWARE\\" + Application.ProductName.ToUpper())
        /// </summary>
        public string SubKey
        {
            get { return subKey; }
            set { subKey = value; }
        }

        private RegistryKey baseRegistryKey = Registry.LocalMachine;
        /// <summary>
        /// A property to set the BaseRegistryKey value.
        /// (default = Registry.LocalMachine)
        /// </summary>
        public RegistryKey BaseRegistryKey
        {
            get { return baseRegistryKey; }
            set { baseRegistryKey = value; }
        }

        /* **************************************************************************
         * **************************************************************************/
        public RegistryManager()
        {

        }
        /// <summary>
        /// To read a registry key.
        /// input: KeyName (string)
        /// output: value (string) 
        /// </summary>
        public string Read(string KeyName)
        {
            // Opening the registry key
            RegistryKey rk = baseRegistryKey;
            // Open a subKey as read-only
            RegistryKey sk1 = rk.OpenSubKey(subKey);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value
                    // or null is returned.
                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //ShowErrorMessage(e, "Reading registry " + KeyName.ToUpper());
                    return null;
                }
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// To write into a registry key.
        /// input: KeyName (string) , Value (object)
        /// output: true or false 
        /// </summary>
        public bool Write(string KeyName, object Value)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                // Save the value
                sk1.SetValue(KeyName.ToUpper(), Value);

                return true;
            }
            catch (Exception e)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //ShowErrorMessage(e, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// To delete a registry key.
        /// input: KeyName (string)
        /// output: true or false 
        /// </summary>
        public bool DeleteKey(string KeyName)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                // If the RegistrySubKey doesn't exists -> (true)
                if (sk1 == null)
                    return true;
                else
                    sk1.DeleteValue(KeyName);

                return true;
            }
            catch (Exception e)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //ShowErrorMessage(e, "Deleting SubKey " + subKey);
                return false;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// To delete a sub key and any child.
        /// input: void
        /// output: true or false 
        /// </summary>
        public bool DeleteSubKeyTree()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists, I delete it
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);

                return true;
            }
            catch (Exception e)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //ShowErrorMessage(e, "Deleting SubKey " + subKey);
                return false;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// Retrive the count of subkeys at the current key.
        /// input: void
        /// output: number of subkeys
        /// </summary>
        public int SubKeyCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.SubKeyCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //ShowErrorMessage(e, "Retriving subkeys of " + subKey);
                return 0;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        /// <summary>
        /// Retrive the count of values in the key.
        /// input: void
        /// output: number of keys
        /// </summary>
        public int ValueCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.ValueCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //ShowErrorMessage(e, "Retriving keys of " + subKey);
                return 0;
            }
        }

        /* **************************************************************************
         * **************************************************************************/

        private void ShowErrorMessage(Exception e, string Title)
        {
            if (showError == true)
                MessageBox.Show(e.Message,
                                Title
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);
        }
    }

    public class EMRCacheManager
    {
        private string _userName;
        private readonly string _patientSetingKey = "EMR_CACHE_PATIENT_SETING_";
        public string UserName
        {
            get { return Environment.UserName; }
            set { _userName = value; }
        }
        public string PatientSetingKey
        {
            get { return _patientSetingKey; }
            //set { _patientSetingKey = value; }
        }

        public EMRCacheManager()
        {
        }

        public string Get(string key)
        {
            if (CacheService.Instance.IsSet(key))
                return CacheService.Instance.Get(key, string.Empty).ToString();
            return string.Empty;
        }

        public bool IsFirstSetup()
        {
            string key = this._patientSetingKey + this.UserName;
            if (CacheService.Instance.IsSet(key))
                return false;
            /*string label = "lbSuname,lbSuname2,lbSexAge,lbBirthDay,lbWeight,lbHeight,lbBloodpressureH,lbBloodpressureL,lbCircuit,lbTemperature,lbSpo2,lbBreathingRate";*/
            string label = "lbSuname,lbSuname2,lbSexAge,lbBirthDay,lbWeight,lbHeight,lbBloodpressureH,lbBloodpressureL,lbCircuit,lbTemperature,lbSpo2,lbBreathingRate,lbHeightAndWeight,lbBreathAndBodyHeatAndPulse,lbBpFromAndToAndSpo2";
            this.Update(key, label);
            return true;
        }
        public bool Update(string key, string data)
        {
            try
            {
                if (CacheService.Instance.IsSet(key))
                    CacheService.Instance.Remove(key);
                CacheService.Instance.Set(key, data, TimeSpan.MaxValue);

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
