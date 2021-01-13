using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;

namespace HDcd
{
    public partial class Form1 : Form
    {
        string jsonnn;
        jsonClss js;
        StringBuilder strb;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }
        /// <summary>
        /// 获取查档请求数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
                
                    js = new jsonClss();
                    js.configOut();
                js.NameMan=textBox12.Text;
                js.IdTypeMan=textBox1.Text ;
                js.CertTypeMan=textBox2.Text ;
                js.CertNumMan=textBox3.Text ;
                js.RegDetailMan=textBox4.Text ;
                js.CompareTypeMan=textBox5.Text ;
                js.CompareStatusMan=textBox6.Text ;
                js.CompareSameMan=textBox7.Text ;
                js.QueryBusiType=textBox9.Text ;
                js.QueryCtntType =textBox10.Text;
                js.QueryAimType =textBox11.Text;

            if (js != null)
            {
                jsonnn = JsonConvert.SerializeObject(js);
            }

            //MessageBox.Show("获取查档数据成功\n获取数据为：\n"+jsonnn);
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //发送请求，接收返回字符串
            string a = js.urtilOutData(jsonnn);

            DataObject stobj = JsonConvert.DeserializeObject<DataObject>(a);

            Dataa fhData = stobj.Data[0];

            //获取文件路径
            string path = System.Environment.CurrentDirectory;

           //* File.WriteAllBytes(path + DateTime.Now.Ticks.ToString() + ".jpeg", Convert.FromBase64String(fhData.DocBody));

            byte[] bytes = Convert.FromBase64String(fhData.DocBody);
            MemoryStream memStream = new MemoryStream(bytes);
            Image mImage = Image.FromStream(memStream);
            Bitmap bp = new Bitmap(mImage);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            DateTime now = DateTime.Now;
            string fileName = "1.jpg";
           
            
            string filePath = path + "\\" + fileName;
            bp.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);//注意保存路径
            


            
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory;
            pictureBox1.ImageLocation = path+"\\1.jpg";
            
        }

      



    }
}
