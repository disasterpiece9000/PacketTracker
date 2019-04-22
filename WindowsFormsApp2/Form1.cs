using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using PacketDotNet;
using SharpPcap;
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        CaptureDeviceList devices;              //List of devices for this computer
        public static ICaptureDevice device;    //The device being used
        public static string strPackets = "";          //The data that is captued
        static int numPackets = 0;
        static int maxPackets = 0;
        int holdProg = 0;
        public static List<double> latList = new List<double>();
        public static List<double> longList = new List<double>();
        public static List<string> ipList = new List<string>();
        public static List<string> threatList = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //Get the list of devices
            devices = CaptureDeviceList.Instance;

            //Make sure at least one device is found
            if (devices.Count < 1)
            {
                MessageBox.Show("No capture devices found! You really messed up this one :(");
                Application.Exit();
            }

            //Add devices to the combo box
            foreach (ICaptureDevice dev in devices)
            {
                cmbDevices.Items.Add(dev.Description);
            }

            //Get the target device and display in combo box
            device = devices[0];
            cmbDevices.Text = device.Description;

            //Register the handler function on the 'packet arrival' event
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            //Open the device for capture
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
        }

        private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            if (numPackets >= maxPackets) return;

            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var tcpPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));

            if (tcpPacket != null)
            {
                var ipPacket = (IPPacket)tcpPacket.ParentPacket;
                IPAddress srcIp = ipPacket.SourceAddress;

                if (ipList.Contains(srcIp.ToString())) return;

                var client = new RestClient("http://api.ipstack.com/" + srcIp.ToString() + "?access_key=c805296379e5d0095b779113db6392d9");
                var request = new RestRequest()
                {
                    Method = Method.GET
                };

                var response = client.Execute(request);
                var dict = JsonConvert.DeserializeObject<IDictionary>(response.Content);

                if (dict["latitude"] != null)
                {
                    numPackets++;

                    double lat = (double)dict["latitude"];
                    double lon = (double)dict["longitude"];
                    string ip = (string)dict["ip"];
                    string threat = "";

                    try
                    {
                        threat = (string)JsonConvert.DeserializeObject<IDictionary>(
                                    (string)dict["security"])["threat_level"];
                    }
                    catch (System.ArgumentNullException)
                    {
                        threat = "None";
                    }

                    latList.Add(lat);
                    longList.Add(lon);
                    ipList.Add(ip);
                    threatList.Add(threat);

                    Debug.Write(Environment.NewLine);
                    Debug.Write("New coordinates: " + lat + ", " + lon);
                    Debug.Write(Environment.NewLine);
                }
            }
        }

        public void addPins()
        {
            Debug.Write("Displaying pins");

            for (int i = 0; i < latList.Count; i++)
            {
                double lat = latList[i];
                double lon = longList[i];
                Debug.Write("Pin at: " + lat + ", " + lon);

                GMapOverlay overlay = new GMapOverlay("markers");
                gmap.Overlays.Add(overlay);

                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(lat, lon),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);

                marker.ToolTipText = "\nIP: " + ipList[i] + "\n"
                    + "Threat Level: " + threatList[i];

                overlay.Markers.Add(marker);
            }
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GoogleMapProvider.Instance;
            gmap.Manager.Mode = AccessMode.ServerOnly;
            gmap.ShowCenter = false;
            gmap.CanDragMap = true;
            gmap.MarkersEnabled = true;
            gmap.MinZoom = 1;
            gmap.MaxZoom = 20;
            gmap.Zoom = 2;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (startBtn.Text == "Start")
            {
                try
                {
                    maxPackets = Convert.ToInt32(numPacketsTxtBox.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("The number of packets must be a number you silly billy");
                    numPacketsTxtBox.Clear();
                    return;
                }

                Debug.Write("Max Packets: " + maxPackets);

                progressLabel.Visible = true;
                progressTxt.Visible = true;
                progressTxt.Text = "0/" + maxPackets;

                timer1.Enabled = true;
                string filter = "ip and tcp";
                device.Filter = filter;
                device.StartCapture();
                startBtn.Text = "Stop";
            }

            else
            {
                device.StopCapture();
                startBtn.Text = "Start";
                timer1.Enabled = false;
            }
        }

        private void CmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = devices[cmbDevices.SelectedIndex];
            cmbDevices.Text = device.Description;

            //Register the handler function on the 'packet arrival' event
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            //Open the device for capture
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
        }

        private void NumPacketsTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (numPackets != holdProg)
            {
                progressTxt.Text = numPackets + "/" + maxPackets;
                holdProg = numPackets;
            }

            if (numPackets >= maxPackets)
            {
                timer1.Enabled = false;
                progressTxt.Text = "Done!";
                Debug.Write("Done");
                device.StopCapture();
                startBtn.Text = "Start";
                addPins();
                latList.Clear();
                longList.Clear();
                ipList.Clear();
                threatList.Clear();
                numPackets = 0;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            gmap.Overlays.Clear();
        }
    }
}
