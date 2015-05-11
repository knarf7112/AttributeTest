using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTest
{
    [AttributeUsage(AttributeTargets.Field)]
    class ReportDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public ReportDescriptionAttribute(string Description)
        {
            this.Description = Description;
        }

        public override string ToString()
        {
            return this.Description.ToString();
        }
    }

    public class gg
    {
        public ReportType rt;
        //短短幾行程式碼，就能取得Attribute的屬性定義。
        public string GetEnumAttribute(ReportType reportType)
        {
            var members = typeof(ReportType).GetMember(reportType.ToString());
            var attributes = members[0].GetCustomAttributes(typeof(ReportDescriptionAttribute), false);
            var description = ((ReportDescriptionAttribute)attributes[0]).Description;
            return description;
        }
    }
 //定義好之後，我們就可以把它掛在列舉的欄位上，比起自己Mapping類別快多了
    public enum ReportType
    {
        /// 310 全部發送清單 
        /// <summary>
        /// 310 全部發送清單
        /// </summary>
        [ReportDescription("全部發送清單")]
        All = 310,

        /// 320 成功發送清單
        /// <summary>
        /// 320 成功發送清單
        /// </summary>
        [ReportDescription("成功發送清單")]
        Succeed = 320,

        /// 330 傳送中清單
        /// <summary>
        /// 330 傳送中清單
        /// </summary>
        [ReportDescription("傳送中清單")]
        Sending = 330,

        /// 340 預約簡訊清單
        /// <summary>
        /// 340 預約簡訊清單
        /// </summary>
        [ReportDescription("預約簡訊清單")]
        PreSend = 340,

        /// 350 逾期簡訊清單
        /// <summary>
        /// 350 逾期簡訊清單
        /// </summary>
        [ReportDescription("逾期簡訊清單")]
        Timeout = 350,

        /// 360 發送失敗清單
        /// <summary>
        /// 360 發送失敗清單
        /// </summary>
        [ReportDescription("發送失敗清單")]
        Fail = 360,

        /// 370 回覆簡訊清單
        /// <summary>
        /// 370 回覆簡訊清單
        /// </summary>
        [ReportDescription("回覆簡訊清單")]
        Reply = 370,
    }
 
}
