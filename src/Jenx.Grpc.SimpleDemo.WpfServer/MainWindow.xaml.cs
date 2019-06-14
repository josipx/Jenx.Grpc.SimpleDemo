using Grpc.Core;
using System.Windows;

namespace Jenx.Grpc.SimpleDemo.WpfServer
{
    public partial class MainWindow : Window
    {
        private readonly Server _gRpcServer;

        public MainWindow()
        {
            InitializeComponent();

            _gRpcServer = new Server
            {
                Services = { Contracts.JenxSimpleGrpcService.BindService(new JenxSimpleGrpcServiceServer(new FormLogger(OutputTextbox))) },
                Ports = { new ServerPort("localhost", 505050, ServerCredentials.Insecure) }
            };
        }

        private void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            _gRpcServer.Start();
        }

        private async void StopServerButton_Click(object sender, RoutedEventArgs e)
        {
            await _gRpcServer.ShutdownAsync();
        }
    }
}