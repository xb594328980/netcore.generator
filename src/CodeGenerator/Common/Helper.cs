using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Common
{
    /// <summary>
    /// 辅助
    /// </summary>
    public static class Helper
    {
        public static string ProcessingTableName(this string name, bool pascal = true, params string[] tablePrefix)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new AggregateException("name为空");
            name = name.Replace(" ", "");//去除空格
            //去除表前缀
            if (tablePrefix != null && tablePrefix.Any())
                foreach (var item in tablePrefix)
                    if (name.StartsWith(item))
                    {
                        name = name.Substring(item.Length);
                        break;
                    }
            if (!pascal)
                return name;
            StringBuilder result = new StringBuilder();
            foreach (var item in name.Split('_'))
            {
                result.Append(item.Substring(0, 1).ToUpper());
                result.Append(item.Substring(1));
            }
            return result.ToString();
        }

        public static string ProcessingFieldName(this string name, bool pascal = true)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new AggregateException("name为空");
            name = name.Replace(" ", "");
            if (!pascal)
                return name;
            StringBuilder result = new StringBuilder();
            foreach (var item in name.Split('_'))
            {
                result.Append(item.Substring(0, 1).ToUpper());
                result.Append(item.Substring(1));
            }
            return result.ToString();
        }
    }
}
