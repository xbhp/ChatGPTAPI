using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitest.Models
{
    /// <summary>
    /// 创建菜单
    /// </summary>
    public class WeChatMenu
    {
        /// <summary>
        /// 一级菜单数组，个数应为1~3个
        /// </summary>
        public Button[] button { get; set; }
    }
    /// <summary>
    /// 一级菜单数组，个数应为1~3个
    /// </summary>
    public class Button
    {
        /// <summary>
        /// 菜单标题，不超过16个字节，子菜单不超过60个字节
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 菜单的响应动作类型，view表示网页类型，click表示点击类型，miniprogram表示小程序类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 菜单KEY值，用于消息接口推送，不超过128字节 
        /// click等点击类型必须
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 调用新增永久素材接口返回的合法media_id
        /// media_id类型和view_limited类型必须
        /// </summary>
        public string media_id { get; set; }
        /// <summary>
        /// 二级菜单数组，个数应为1~5个
        /// </summary>
        public Sub_Button[] sub_button { get; set; }
    }
    /// <summary>
    /// 二级菜单数组，个数应为1~5个
    /// </summary>
    public class Sub_Button
    {
        /// <summary>
        /// 菜单的响应动作类型，view表示网页类型，click表示点击类型，miniprogram表示小程序类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 菜单标题，不超过16个字节，子菜单不超过60个字节
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 网页链接，用户点击菜单可打开链接，不超过1024字节。type为miniprogram时，不支持小程序的老版本客户端将打开本url。
        /// view、miniprogram类型必须
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 小程序的appid（仅认证公众号可配置）
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 小程序的页面路径
        /// </summary>
        public string pagepath { get; set; }
        /// <summary>
        /// 菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        public string key { get; set; }
        public object[] sub_button { get; set; }
    }
}
