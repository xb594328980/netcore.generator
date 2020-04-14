using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeGenerator.Models
{
    /// <summary>
    /// ajax请求处理结果对象
    /// </summary>

    public class AjaxResult : ActionResult
    {
        /// <summary>
        /// 数据
        /// </summary>
        private AjaxBackData Data { get; set; }
        /// <summary>
        /// 获取返回数据
        /// </summary>
        public AjaxBackData GetResponseData
        {
            get { return Data; }
        }
        #region 初始化函数
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="data"></param>
        public AjaxResult(dynamic data, int total = 0)
        {
            Data = new AjaxBackData(data, total);
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public AjaxResult(int code, string msg)
        {
            Data = new AjaxBackData(code, msg);
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="ex"></param>
        public AjaxResult(Exception ex)
        {
            Data = new AjaxBackData(ex);
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="data"></param>
        public AjaxResult(AjaxBackData data)
        {
            Data = data;
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ActionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(Data);
            response.WriteAsync(result);
        }
    }

    #region 数据

    public class AjaxBackData
    {
        #region 初始化函数
        public AjaxBackData() { }
        public AjaxBackData(dynamic data, int total = 0)
        {
            Code = 200;
            Msg = "ok";
            Data = data;
            Total = total;
        }
        public AjaxBackData(int code, string msg)
        {
            Code = code;
            Msg = msg;
            Data = new object();
        }
        public AjaxBackData(Exception ex)
        {
            Code = 500;
            Msg = ex.Message;
            Data = new object();
        }
        #endregion
        /// <summary>
        /// 错误代码 ,200为成功
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public dynamic Data { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// 要定位的页面元素id
        /// </summary>
        [JsonProperty("pitchId")]
        public string PitchId { get; set; }


        /// <summary>
        /// 跳转的页面
        /// </summary>
        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

    }
    #endregion

}