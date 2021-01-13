using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HDcd
{
    class DataObject
    {

        #region 字段封装
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        List<Dataa> data;

        public List<Dataa> Data
        {
            get { return data; }
            set { data = value; }
        }


        string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        string success;

        public string Success
        {
            get { return success; }
            set { success = value; }
        }
        #endregion

        #region
        //       public Dataa data_Json(){
        //           Dataa datajson = new Dataa();
        //           datajson = (Dataa)datajson.js_Da(Data);
        //           return datajson;
        //       }
    }
    class Dataa
    {
        #region 字段封装
        string certNumMan;

        public string CertNumMan
        {
            get { return certNumMan; }
            set { certNumMan = value; }
        }
        string deptCode;

        public string DeptCode
        {
            get { return deptCode; }
            set { deptCode = value; }
        }
        string deptName;

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }
        string docBody;

        public string DocBody
        {
            get { return docBody; }
            set { docBody = value; }
        }
        string docType;

        public string DocType
        {
            get { return docType; }
            set { docType = value; }
        }
        string docUrl;

        public string DocUrl
        {
            get { return docUrl; }
            set { docUrl = value; }
        }
        string nameMan;

        public string NameMan
        {
            get { return nameMan; }
            set { nameMan = value; }
        }
        #endregion
        /// <summary>
        /// JSON字段转换为Dataa对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Object js_Da(string data)
        {
            Object da = JsonConvert.DeserializeObject<Dataa>(data);
            return da;
        }
        #endregion
    }
}

