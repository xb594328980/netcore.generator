using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator.Models
{
    public class TableConfig
    {



        public string Id { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表注释
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 全名不包含具体模块，只是处理后的表名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 库名
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        public List<ColumnConfig> ColumnConfig { get; set; }
    }


}
