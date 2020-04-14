using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator.Models
{
    /// <summary>
    /// 返回的Json模型
    /// </summary>
    public class PageResponse
    {
        /// <summary>
        /// 200成功
        /// </summary>
        public string code { get; set; } //状态码

        /// <summary>
        /// 错误消息
        /// </summary>
        public string msg { get; set; }//消息

        /// <summary>
        /// 要定位的页面元素id
        /// </summary>
        public string pitchId { get; set; }


        /// <summary>
        /// 跳转的页面
        /// </summary>
        public string returnUrl { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int total { get; set; }
    }
}
