using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace comtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string s = "";
            //int count = serialPort1.BytesToRead;  
            int SDateTemp = this.serialPort1.ReadByte();
            //读取串口中一个字节的数据
            byte[] data = new byte[SDateTemp];
            serialPort1.Read(data, 0, SDateTemp);

            foreach (byte item in data)
            {
                s += Convert.ToChar(item);
            }

            //int SDateTemp = this.serialPort1.ReadByte();
            //读取串口中一个字节的数据  
            this.tB_ReceiveDate.Invoke(
             //在拥有此控件的基础窗口句柄的线程上执行委托Invoke(Delegate)  
             //即在textBox_ReceiveDate控件的父窗口form中执行委托.  
             new MethodInvoker
                 (
             /*表示一个委托，该委托可执行托管代码中声明为 void 且不接受任何参数的任何方法。 在对控件的 Invoke    方法进行调用时或需要一个简单委托又不想自己定义时可以使用该委托。*/
             delegate
             {
                 /*匿名方法,C#2.0的新功能，这是一种允许程序员将一段完整代码区块当成参数传递的程序代码编写技术，通过此种方法可  以直接使用委托来设计事件响应程序以下就是你要在主线程上实现的功能但是有一点要注意，这里不适宜处理过多的方法，因为C#消息机制是消息流水线响应机制，如果这里在主线程上处理语句的时间过长会导致主UI线程阻塞，停止响应或响应不顺畅,这时你的主form界面会延迟或卡死      */
                 this.tB_ReceiveDate.AppendText(s.ToString());//输出到主窗口文本控件  
                 this.tB_ReceiveDate.Text += " ";
             }
                )
             );

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM1";

            serialPort1.BaudRate = 9600;

            serialPort1.Open();
            // 为了测试GitHub的Branch功能
            // test for github
        }


        private void comboBox1_Click_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a;
            a = Convert.ToInt32(textBox1.Text);
            string b;
            string c;
            //c = a + b;
        }
    }
}
