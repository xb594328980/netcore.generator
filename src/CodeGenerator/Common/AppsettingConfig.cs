using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator.Common
{
    /// <summary>
    /// 解决方案设置
    /// create by xingbo 20/03/06
    /// </summary>
    public class AppsettingConfig
    {
        /// <summary>
        /// 解决方案地址
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 表名前缀，如有生成后替换
        /// </summary>
        public string[] TablePrefix { get; set; }
        /// <summary>
        ///表名按照帕斯卡命名法（首字母大写,下划线去除后字母大写）
        /// </summary>
        public bool TablePascal { get; set; }
        /// <summary>
        /// 字段名按照帕斯卡命名法（首字母大写,下划线去除后字母大写）
        /// </summary>
        public bool FieldPascal { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Auth { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }

    }
}
