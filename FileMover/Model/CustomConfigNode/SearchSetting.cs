using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Model.CustomConfigNode
{
    public class SearchSetting : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return this["key"].ToString(); }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return this["value"].ToString(); }
            set { this["value"] = value; }
        }
        [ConfigurationProperty("operator", IsRequired = true)]
        public string Operator
        {
            get { return this["operator"].ToString(); }
            set { this["operator"] = value; }
        }
        [ConfigurationProperty("index", IsRequired = true)]
        public string Index
        {
            get { return this["index"].ToString(); }
            set { this["index"] = value; }
        }
    }
}
