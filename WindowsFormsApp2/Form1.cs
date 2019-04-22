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
        public static List<Double> latList;
        public static List<Double> longList;

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
            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var tcpPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));

            if (tcpPacket != null)
            {
                var ipPacket = (IPPacket)tcpPacket.ParentPacket;
                IPAddress srcIp = ipPacket.SourceAddress;

                Debug.Write(Environment.NewLine);
                Debug.Write("New IP: " + srcIp.ToString());
                Debug.Write(Environment.NewLine);

                var client = new RestClient("https://ipapi.co/" + srcIp.ToString() + "/json/");
                var request = new RestRequest()
                {
                    Method = Method.GET
                };

                var response = client.Execute(request);
                var dict = JsonConvert.DeserializeObject<IDictionary>(response.Content);
            

                if (dict.Contains("latitude") && dict.Contains("longitude"))
                {
                    numPackets++;

                    Object latO = dict["latitude"];
                    Object lonO = dict["longitude"];

                    latList.Add((double)latO);
                    longList.Add((double)lonO);

                    Debug.Write(Environment.NewLine);
                    Debug.Write("New coordinates: " + (double)latO + ", " + (double)lonO);
                    Debug.Write(Environment.NewLine);
                }
            }
        }

        public void addPins()
        {
            Debug.Write("Displaying pins");
            GMapOverlay overlay = new GMapOverlay("markers");

            for (int i = 0; i < latList.Count; i++)
            {
                double lat = latList[i];
                double lon = longList[i];
                Debug.Write("Pin at: " + lat + ", " + lon);

                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(lat, lon),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);

                overlay.Markers.Add(marker);
            }

            gmap.Overlays.Add(overlay);
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GoogleMapProvider.Instance;
            gmap.Manager.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(55.755786121111, 37.617633343333);
            gmap.ShowCenter = false;
            gmap.CanDragMap = true;
            gmap.MarkersEnabled = true;
            gmap.MinZoom = 1;
            gmap.MaxZoom = 20;
            gmap.Zoom = 1;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (startBtn.Text == "Start")
            {
                string filter = "ip and tcp";
                device.Filter = filter;
                device.StartCapture();
                startBtn.Text = "Stop";
                Debug.Write("Start");
            }

            else
            {
                device.StopCapture();
                startBtn.Text = "Start";
                maxPackets = Convert.ToInt32(numPacketsTxtBox.Text);
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
            if (numPackets >= maxPackets)
            {
                Debug.Write("Done");
                device.StopCapture();
                startBtn.Text = "Start";
                addPins();
            }
        }
    }
}
