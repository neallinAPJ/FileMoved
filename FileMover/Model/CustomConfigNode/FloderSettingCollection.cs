using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover.Model.CustomConfigNode
{
    [ConfigurationCollection(typeof(FloderSetting), AddItemName = "Folder")]
    public class FloderSettingCollection : ConfigurationElementCollection
    {
        // 基本上，所有的方法都只要简单地调用基类的实现就可以了。

        public FloderSettingCollection()
            : base(StringComparer.OrdinalIgnoreCase)   // 忽略大小写
        {
        }

        // 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
        new public FloderSetting this[string name]
        {
            get
            {
                return (FloderSetting)base.BaseGet(name);
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new FloderSetting();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FloderSetting)element).Index;
        }

        // 说明：如果不需要在代码中修改集合，可以不实现Add， Clear， Remove
        public void Add(FloderSetting setting)
        {
            this.BaseAdd(setting);
        }
        public void Clear()
        {
            base.BaseClear();
        }
        public void Remove(string name)
        {
            base.BaseRemove(name);
        }
    }
}
