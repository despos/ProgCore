using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace WindCli
{
    public partial class Form1 : Form
    {
        private static HubConnection _connection;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:60000/progressdemo")
                //.WithConsoleLogger()
                //.WithMessagePackProtocol()
                .Build();

            lblConnectionId.Text = "Connected";
            _connection.On("initProgressBar", () =>
            {
                // Run UI Thread ...
                Invoke((Action)(() => label1.Text = "0%"));
            });
            _connection.On<int>("updateProgressBar", (perc) =>
            {
                // Run UI Thread ...
                Invoke((Action) (() => label1.Text = String.Format("{0}%", perc)));
            });
            _connection.On("clearProgressBar", () =>
            {
                // Run UI Thread ...
                Invoke((Action)(() =>
                {
                    label1.Text = "100%";
                    button1.Enabled = true;
                }));
            });

            await _connection.StartAsync();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Must go on a separate thread, not the UI thread
            Task.Run(() =>
            {
                var client = new WebClient();
                client.UploadString("http://localhost:60000/task/lengthy/0000", "connId");
            });
            button1.Enabled = false;
        }
    }
}
