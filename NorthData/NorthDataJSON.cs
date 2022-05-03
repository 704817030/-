using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace NorthData
{
    public class Data
    {
        public string SECUCODE { get; set; }
        public string MUTUAL_TYPE { get; set; }
        public string TRADE_DATE { get; set; }
        public string INTERVAL_TYPE { get; set; }
        public string SECURITY_NAME { get; set; }
        public string SECURITY_INNER_CODE { get; set; }
        public string ORG_CODE { get; set; }
        public string SECURITY_CODE { get; set; }
        public string PARTICIPANT_NUM { get; set; }
        public string EFFECTIVE_DATE { get; set; }
        public string A_SHARES_RATIO { get; set; }
        public string HOLD_SHARES_RATIO { get; set; }
        public string HOLD_SHARES { get; set; }
        public string HOLD_MARKET_CAP { get; set; }
        public string FREE_SHARES_RATIO { get; set; }
        public string TOTAL_SHARES_RATIO { get; set; }
        public string CLOSE_PRICE { get; set; }
        public string CHANGE_RATE { get; set; }
        public string INDUSTRY_CODE { get; set; }
        public string INDUSTRY_NAME { get; set; }
        public string ORIG_INDUSTRY_CODE { get; set; }
        public string CONCEPT_CODE { get; set; }
        public string CONCEPT_NAME { get; set; }
        public string AREA_CODE { get; set; }
        public string AREA_NAME { get; set; }
        public string ORIG_AREA_CODE { get; set; }
        public string FREECAP { get; set; }
        public string TOTAL_MARKET_CAP { get; set; }
        public string FREECAP_HOLD_RATIO { get; set; }
        public string TOTAL_MARKETCAP_HOLD_RATIO { get; set; }
        public string ADD_MARKET_CAP { get; set; }
        public string ADD_SHARES_REPAIR { get; set; }
        public string ADD_SHARES_AMP { get; set; }
        public string FREECAP_RATIO_CHG { get; set; }
        public string TOTAL_RATIO_CHG { get; set; }
        public string HOLD_MARKETCAP_BEFORECHG { get; set; }
        public string HOLD_SHARES_BEFORECHG { get; set; }
        public string HOLD_MARKETCAP_CHG1 { get; set; }
        public string HOLD_MARKETCAP_CHG5 { get; set; }
        public string HOLD_MARKETCAP_CHG10 { get; set; }
        public string INDUSTRY_CODE_NEW { get; set; }
        public string AREA_CODE_NEW { get; set; }
    }

    public class Result
    {
        public string pages { get; set; }
        public List<Data> data { get; set; }
        public string count { get; set; }
    }

    public class RootObject
    {
        public string version { get; set; }
        public Result result { get; set; }
        public string success { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }
    class NorthDataJSON
    {
        public RootObject NorthDataRoot = null;
        public string GetPureNorthDataJSON(string strJSON)
        {
            if (strJSON.Trim().Length == 0)
                return strJSON.Trim();
            //找到第一个( ;
            int nFirstPos = strJSON.IndexOf("(");

            int nLastPos = strJSON.LastIndexOf(")");
            string strTemp = strJSON.Substring(nFirstPos + 1, nLastPos - nFirstPos - 1);
            return strTemp;
        }
        public bool GetNorthDataDataByJSON(string strJSON)
        {
            RootObject oro = JsonConvert.DeserializeObject<RootObject>(strJSON);
            if (oro.message != "ok")
            {
                Console.WriteLine("No data.");
                return false;
            }
            this.NorthDataRoot = oro;
            Result rs = oro.result;
            string strPages = rs.pages;
            int nPages = Convert.ToInt16(strPages); //页数
            int nCount = Convert.ToInt16(rs.count); //总股票条数

            for (int i = 0; i < rs.data.Count; i++)
            {
                Data data = rs.data[i];
                /*   Console.WriteLine(" 日期 " + data.DATE + " 收盘价 " + data.SPJ + " 涨跌幅 " + data.ZDF + " scode " + data.SCODE + " sname " + data.SECNAME +
                                     " 融资余额 " + data.RZYE + " 融资余额占流通比 " + data.RZYEZB + " 融资买入额 " + data.RZMRE +
                                     " 融资偿还额 " + data.RZCHE + " 融资净买入 " + data.RZJME + " 融券余额 " + data.RQYE +
                                     " 融券余量 " + data.RQYL + " 融券卖出量 " + data.RQMCL + " 融券偿还额 " + data.RQCHL + " 融券净卖出 " + data.RQJMG +
                                     " 融资融券余额 " + data.NorthDataYE + " 融资融券余额差值 " + data.NorthDataYECZ);
                                     */
            }


            return true;
        }
    }
}
