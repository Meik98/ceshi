using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace HDcd
{
    class ConfigUrtil
    {


        private void Form2_Load(object sender, EventArgs e)
        {

        }



        ///<summary> 
        ///返回*.exe.config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        public static string GetAppConfig(string strKey)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == strKey)
                {
                    return config.AppSettings.Settings[strKey].Value.ToString();
                }
            }
            return null;
        }

//       public static void Base64StringToimgae(string strbase64)
//       {
//           try
//           {
//               byte[] arr = Convert.FromBase64String(strbase64);
//               MemoryStream ms = new MemoryStream(arr);
//               System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
//
//               string str = System.Environment.CurrentDirectory+".jpg";
//              // string ls_path = Server.MapPath(@"images\camera\" + ls_imageNameCamera + ".jpg");
//
//               //img.Save(ls_path, System.Drawing.Imaging.ImageFormat.Jpeg);
//
//               //System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
//               //img.Save("ImgName.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
//               //img.Save("ImgName.bmp", ImageFormat.Bmp);
//               //img.Save("ImgName.gif", ImageFormat.Gif);
//               //img.Save(@"images\ImgName.png", ImageFormat.Png);
//
//               //Session["ImageNameCamera"] = ls_imageNameCamera;
//           }
//           catch (Exception ex)
//           {
//
//           }
//       
//       } 
        

      

    }
}
