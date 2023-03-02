using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitest.Models
{
    #region 系统返回信息
    /// <summary>
    /// 系统返回信息
    /// </summary>
    /// <typeparam name="T">指定返回类型</typeparam>
    public class WeCahtBackdata<T>
    {
        /// <summary>
        /// 接口返回数据状态true成功|false失败
        /// </summary>
        public bool ResponseState;
        /// <summary>
        /// 接口返回正确数据
        /// </summary>
        public T ResponseData;
        /// <summary>
        /// 接口返回错误时间
        /// </summary>
        public WeChatApperror ErrorData;
    }
    #endregion

    #region 微信接口返回错误类
    /// <summary>
    /// 微信接口返回错误类
    /// </summary>
    public class WeChatApperror
    {
        /// <summary>
        /// 接口错误代码
        /// </summary>
        public string errcode;
        /// <summary>
        /// 接口错误消息
        /// </summary>
        public string errmsg;
    }
    #endregion

    #region 获取接口返回Token
    /// <summary>
    /// 获取接口返回凭证Token
    /// </summary>
    public class WeChatAaccessToken
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token;
        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        public string expires_in;
    }

    #endregion

    #region  获取此用户OpenID
    /// <summary>
    /// 获取用户OpenID列表
    /// </summary>
    public class WeChatOpenidlist
    {
        /// <summary>
        /// 关注该公众账号的总用户数
        /// </summary>
        public string total;
        /// <summary>
        /// 拉取的OPENID个数，最大值为10000
        /// </summary>
        public string count;
        /// <summary>
        /// 列表数据，OPENID的列表
        /// </summary>
        public Data data;
        /// <summary>
        /// 拉取列表的最后一个用户的OPENID
        /// </summary>
        public string next_openid;
    }
    /// <summary>
    /// openid对象
    /// </summary>
    public class Data
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public List<string> openid;
    }
    #endregion

    #region 
    /// <summary>
    /// 获取用户个人信息
    /// </summary>
    public class WeChatUserInfo
    {
        /// <summary>
        /// 是否订阅该公众号0没有关注|1已关注
        /// </summary>
        public string subscribe;
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string openid;
        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string nickname;
        /// <summary>
        /// 用户的性别0未知|1男性|2女性
        /// </summary>
        public string sex;
        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city;
        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string country;
        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string province;
        /// <summary>
        /// 用户的语言
        /// </summary>
        public string language;
        /// <summary>
        /// 用户头像,最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像）
        /// </summary>
        public string headimgurl;
        /// <summary>
        /// 用户关注时间
        /// </summary>
        public string subscribe_time;
        /// <summary>
        /// 绑定到微信开放平台唯一标识
        /// </summary>
        public string unionid;
        /// <summary>
        /// 粉丝备注
        /// </summary>
        public string remark;
        /// <summary>
        /// 用户所在的分组ID（兼容旧的用户分组接口）
        /// </summary>
        public string groupid;
        /// <summary>
        /// 用户被打上的标签ID列表
        /// </summary>
        public List<string> tagid_list;
    }
    #endregion
}
