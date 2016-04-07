using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Model.CustomConfigNode
{
    public class FloderSetting : ConfigurationElement
    {
        private static readonly ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(SearchSettingCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public SearchSettingCollection KeyValues
        {
            get
            {
                return (SearchSettingCollection)base[s_property];
            }
        }
        [ConfigurationProperty("toFolder", IsRequired = true)]
        public string ToFolder
        {
            get { return this["toFolder"].ToString(); }
            set { this["toFolder"] = value; }
        }
        [ConfigurationProperty("fromFolder", IsRequired = true)]
        public string FromFolder
        {
            get { return this["fromFolder"].ToString(); }
            set { this["fromFolder"] = value; }
        }
        [ConfigurationProperty("index", IsRequired = true)]
        public string Index
        {
            get { return this["index"].ToString(); }
            set { this["index"] = value; }
        }
        [ConfigurationProperty("sub", IsRequired = false)]
        public string Sub
        {
            get {return this["sub"].ToString();}
            set { this["sub"] = value; }
        }
        [ConfigurationProperty("struct", IsRequired = false)]
        public string Struct
        {
            get {return this["struct"].ToString(); }
            set { this["struct"] = value; }
        }
    }
}
