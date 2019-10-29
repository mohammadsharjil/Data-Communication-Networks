using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using NAudio.Wave;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Media;


namespace ArajApp
{
    class Voice
    {
        private string ip;

        private string path = Application.StartupPath + "\\buffer.wav";

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        private int Port;

        private Thread rec_Thread;

        public int VPort
        {
            get { return Port; }
            private set { Port = value; }
        }

        private WaveIn sourceStream = null;
        private Byte[] Data_array;
        private NetworkStream ns;
        private WaveFileWriter waveWriter = null;
        private System.Windows.Forms.Timer c_v = null;
        private Socket connector, sc, sock = null;

        public void send(string ip, int port)
        {
            this.IP = ip;
            this.VPort = port;

            c_v = new System.Windows.Forms.Timer();
            //c_v.Interval = 2000;
            c_v.Enabled = false;
            c_v.Tick += c_v_Tick;
            Recordwave();
        }

        private void Recordwave()
        {
            sourceStream = new WaveIn();
            int devicenum = 0;

            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                if (NAudio.Wave.WaveIn.GetCapabilities(i).ProductName.Contains("microphone"))
                {
                    devicenum = i;
                }
            }
            sourceStream.DeviceNumber = devicenum;
            sourceStream.WaveFormat = new WaveFormat(22000, WaveIn.GetCapabilities(devicenum).Channels);
            sourceStream.DataAvailable += new EventHandler<WaveInEventArgs>(sourceStream_DataAvailable);
            waveWriter = new WaveFileWriter(path, sourceStream.WaveFormat);
            sourceStream.StartRecording();
            c_v.Start();
        }

        void sourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveWriter == null)
            {
                return;
            }
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        void c_v_Tick(object sender, EventArgs e)
        {
            this.Dispose();
            Send_Bytes();
        }

        private void Send_Bytes()
        {
            Data_array = File.ReadAllBytes(path);

            connector = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(this.IP), this.VPort);
            ie.Address = IPAddress.Loopback;
            connector.Connect(ie);
            connector.Send(Data_array, 0, Data_array.Length, 0);
            connector.Close();

            Recordwave();
        }

        public void Receive(string IP, int Port)
        {
            this.IP = IP;
            this.VPort = Port;
            rec_Thread = new Thread(new ThreadStart(VoiceReceive));
            rec_Thread.Start();
        }

        private void VoiceReceive()
        {
            sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, this.VPort);
            sc.Bind(ie);
            sc.Listen(0);
            sock = sc.Accept();
            ns = new NetworkStream(sock);
            WriteBytes();
            sc.Close();
            while (true)
            {
                VoiceReceive();
            }
        }

        private void WriteBytes()
        {
            if (ns != null)
            {
                SoundPlayer sp = new SoundPlayer(ns);
                sp.Play();
            }
        }

        private void Dispose()
        {
            c_v.Stop();
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
            }
            if (waveWriter != null)
            {
                waveWriter.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
