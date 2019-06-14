using Grpc.Core;
using System;
using System.Windows;

namespace Jenx.Grpc.SimpleDemo.WpfClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SendMessageButton_OnClick(object sender, RoutedEventArgs e)
        {
            var channel = new Channel("127.0.0.1:505050", ChannelCredentials.Insecure);
            var client = new Contracts.JenxSimpleGrpcService.JenxSimpleGrpcServiceClient(channel);
            var requestMessage = $"Message {(string.IsNullOrEmpty(MessageTextBox.Text) ? "N/A" : MessageTextBox.Text)} from client at client time {DateTime.Now}";
            var response = await client.SendMessageAsync(new Contracts.RequestMessage { RequestPayload = requestMessage });

            OutputTextBox.Text += $"Send message {requestMessage}" + Environment.NewLine;
            OutputTextBox.Text += $"Received back message: {response.ResponsePayload}" + Environment.NewLine;
            OutputTextBox.Text += "**********************************************************" + Environment.NewLine;
        }
    }
}