using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Model.CustomConfigNode
{
    public class FileConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(FloderSettingCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public FloderSettingCollection KeyValues
        {
            get
            {
                return (FloderSettingCollection)base[s_property];
            }
        }
    }
}
