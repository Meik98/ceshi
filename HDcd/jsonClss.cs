using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HDcd
{
    class jsonClss
    {
        #region 字段封装
        string sign;                   //签名

        public string Sign
        {
            get { return sign; }
            set { sign = value; }
        }
         string grantKey;               //授权码 

         public string GrantKey
         {
             get { return grantKey; }
             set { grantKey = value; }
         }
         string deptCode;               //办理机关编号

         public string DeptCode
         {
             get { return deptCode; }
             set { deptCode = value; }
         }
         string deptName;               //办理机关名称 

         public string DeptName
         {
             get { return deptName; }
             set { deptName = value; }
         }
         private string privatekey;             //私钥

         public string Privatekey
         {
             get { return privatekey; }
             set { privatekey = value; }
         }
         private string grantkey;                //授权key

         public string Grantkey
         {
             get { return grantkey; }
             set { grantkey = value; }
         }
         private string readtime;                //准备时间

         public string Readtime
         {
             get { return readtime; }
             set { readtime = value; }
         }
         private string timeinterval;            //时间间隔

         public string Timeinterval
         {
             get { return timeinterval; }
             set { timeinterval = value; }
         }
         string nameMan;                //声请人姓名 

         public string NameMan
         {
             get { return nameMan; }
             set { nameMan = value; }
         }
         string idTypeMan;              //声请人身份类别

         public string IdTypeMan
         {
             get { return idTypeMan; }
             set { idTypeMan = value; }
         }
         string certTypeMan;              //声请人证件类型 

         public string CertTypeMan
         {
             get { return certTypeMan; }
             set { certTypeMan = value; }
         }
         string certNumMan;               //声请人身份证件号

         public string CertNumMan
         {
             get { return certNumMan; }
             set { certNumMan = value; }
         }
         string regDetailMan;             //申请人常住户口所在地 

         public string RegDetailMan
         {
             get { return regDetailMan; }
             set { regDetailMan = value; }
         }
         string compareTypeMan;           //申请人比对类型

         public string CompareTypeMan
         {
             get { return compareTypeMan; }
             set { compareTypeMan = value; }
         }
         string compareStatusMan;         //申请人比对状态

         public string CompareStatusMan
         {
             get { return compareStatusMan; }
             set { compareStatusMan = value; }
         }
         string compareSameMan;           //申请人比对相似度

         public string CompareSameMan
         {
             get { return compareSameMan; }
             set { compareSameMan = value; }
         }
         string queryBusiType;            //查档业务类型 

         public string QueryBusiType
         {
             get { return queryBusiType; }
             set { queryBusiType = value; }
         }
         string queryCtntType;            //查档内容 

         public string QueryCtntType
         {
             get { return queryCtntType; }
             set { queryCtntType = value; }
         }
         string queryAimType;             //查档用途 

         public string QueryAimType
         {
             get { return queryAimType; }
             set { queryAimType = value; }
         }



         string ipaddress;               //请求地址

         public string Ipaddress
         {
             get { return ipaddress; }
             set { ipaddress = value; }
         }
        #endregion


        /// <summary>
        /// 获取config文件内容
        /// </summary>
         public void configOut() {
             //获取config文件下的数据
             Ipaddress = ConfigUrtil.GetAppConfig("ipaddress");
             Privatekey = ConfigUrtil.GetAppConfig("privatekey");
             Grantkey = ConfigUrtil.GetAppConfig("grantkey");
             Readtime = ConfigUrtil.GetAppConfig("readtime");
             Timeinterval = ConfigUrtil.GetAppConfig("timeinterval");
             DeptCode = ConfigUrtil.GetAppConfig("deptCode");
             DeptName = ConfigUrtil.GetAppConfig("deptName");

             byte[] buffer = Encoding.Default.GetBytes(Privatekey + Grantkey + DateTime.Now.ToString("yyyy-MM-dd"));
             MD5 md5 = MD5.Create();
             byte[] bufferNew = md5.ComputeHash(buffer); //使用MD5实例的ComputerHash()方法处理字节数组。

             //sign签名数据
             Sign = null;
             for (int i = 0; i < bufferNew.Length; i++)
             {

                 Sign += bufferNew[i].ToString("x2");  //对bufferNew字节数组中的每个元素进行十六进制转换然后拼接成strNew字符串

             }
         }
        /// <summary>
        /// 发送json字符串，返回string类型
        /// </summary>
        /// <param name="jsonnn"></param>
        /// <returns></returns>
         public string urtilOutData(string jsonnn) {
             var request = (HttpWebRequest)WebRequest.Create(Ipaddress);
             request.Method = "POST";
             request.ContentType = "application/json;charset=UTF-8";

             var byteData = Encoding.UTF8.GetBytes(jsonnn);
             var length = byteData.Length;
             request.ContentLength = length;
             var writer = request.GetRequestStream();
             writer.Write(byteData, 0, length);
             writer.Close();
             var response = (HttpWebResponse)request.GetResponse();
             var responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            
             
             return responseString;
         }







    }
}
