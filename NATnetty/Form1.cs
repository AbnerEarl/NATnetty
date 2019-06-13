using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace NATnetty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startNat();
        }

        private void startNat()
        {

            String folderName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            String fileName = "nat.bat";
            //String path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "nat.bat";
            String path = folderName + fileName;
            try
            {

                // FileStream fs = new FileStream(path, FileMode.Append);
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter wr = null;
                wr = new StreamWriter(fs);
                String result = "java -jar natx-client.jar -server_addr ";
                if (textBox1.Text.Length > 1)
                {
                    result = result + textBox1.Text + " ";
                }
                else
                {
                    MessageBox.Show("远程服务器IP不能为空！");
                    return;
                }
                result = result + "-server_port ";
                if (textBox2.Text.Length > 1)
                {
                    result = result + textBox2.Text+" ";
                }
                else
                {
                    MessageBox.Show("远程服务器接受端口不能为空！");
                    return;
                }
                result = result + "-password ";
                if (textBox3.Text.Length > 1)
                {
                    result = result + textBox3.Text + " ";
                }
                else
                {
                    MessageBox.Show("远程服务器验证密码不能为空！");
                    return;
                }
                result = result + "-proxy_addr localhost -proxy_port ";
                if (textBox4.Text.Length > 1)
                {
                    result = result + textBox4.Text + " ";
                }
                else
                {
                    MessageBox.Show("本地代理端口不能为空！");
                    return;
                }
                result = result + "-remote_port ";
                if (textBox5.Text.Length > 1)
                {
                    result = result + textBox5.Text + " ";
                }
                else
                {
                    MessageBox.Show("远程服务器开放端口不能为空！");
                    return;
                }
                wr.WriteLine(result);
                wr.Close();

            }
            catch (Exception e)
            {

            }
            excuteCommand(folderName, fileName);

        }


        private void excuteCommand(String folderName, String fileName)
        {
            Process proc = null;
            try
            {
                string targetDir = string.Format(folderName);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = fileName;
                // proc.StartInfo.Arguments = string.Format("10");//参数设置
                //proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }

            MessageBox.Show("网络穿透成功，可在任意电脑通过远程服务器IP和指定端口访问本台电脑的应用或资源！");
        }

    }
}
