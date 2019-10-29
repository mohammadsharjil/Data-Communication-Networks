using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using TouchlessLib;

namespace ArajApp
{
    public partial class Form1 : Form
    {
        int i;
        UdpClient subscriber = new UdpClient();
        UdpClient publisher = new UdpClient();
        string mycomputer = Environment.MachineName;
        IPAddress[] mycomputerIP = Dns.GetHostAddresses(Environment.MachineName);

        static TouchlessMgr Touchless = new TouchlessMgr();
        Camera Camera1 = Touchless.Cameras.ElementAt(0);
        Size picsize = new Size(160, 120);

        Voice v = new Voice();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            publisher.Client.Blocking = false;
            subscriber.Client.ReceiveTimeout = 100;
            subscriber.Client.Blocking = false;
            subscriber.ExclusiveAddressUse = false;
            publisher.ExclusiveAddressUse = false;
            txt_IP.Text = (System.Net.IPAddress.Any).ToString();

            lbl_Name.Text = Environment.MachineName;

            Touchless.CurrentCamera = Camera1;
            Touchless.CurrentCamera.CaptureWidth = picsize.Width;
            Touchless.CurrentCamera.CaptureHeight = picsize.Height;

            v.Receive(txt_IP.Text, 2000);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmapz = new Bitmap(picsize.Width, picsize.Height);
                bitmapz = Touchless.CurrentCamera.GetCurrentImage();
                pictureBox1.Image = bitmapz;
                
                byte[] sendbytes = null;

                BytesFromImageClass convert = new BytesFromImageClass();
                convert.bytesfromimage(ref sendbytes, ref bitmapz);

                publisher.Send(sendbytes, sendbytes.Length);
            }
            catch (Exception ex)
            {
            }
            try
            {
                System.Net.IPEndPoint ep = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 5050);
                byte[] rcvbytes = subscriber.Receive(ref ep);
                Bitmap bitmapz = new Bitmap(picsize.Width, picsize.Height);

                ImageFromBytesClass convert = new ImageFromBytesClass();
                convert.imagefrombytes(ref rcvbytes, ref bitmapz);

                pictureBox2.Image = bitmapz;
                

            }
            catch (Exception ex)
            {
            }
        }
        private void btn_Call_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_IP.Text != "")
                {
                        
                        publisher.Connect(txt_IP.Text, 5050);
                        subscriber.Client.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, 5050));
                        txt_IP.Enabled = false;
                        btn_Call.Enabled = false;
                        v.send(Get_privateIP(), 2000);
                }
                
                else
                {
                    MessageBox.Show("Please Enter IP Address");
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_EndCall_Click(object sender, EventArgs e)
        {
            txt_IP.Enabled = true;
            btn_Call.Enabled = true;
            txt_IP.Clear();
            subscriber.Close();
            publisher.Close();
            pictureBox2.Image.Dispose();
            pictureBox2.Image = null;
            i++;
        }

        private string Get_privateIP()
        {
            string HostName = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(HostName);
            IPAddress[] ip = hostEntry.AddressList;
            return ip[ip.Length - 1].ToString();
        }
    }

}
