using System;
using System.Windows;
using System.Windows.Controls;

namespace Jenx.Grpc.SimpleDemo.WpfServer
{
    public class FormLogger : ILogger
    {
        private readonly TextBox _outputControl;

        public FormLogger(TextBox outputControl)
        {
            _outputControl = outputControl;
        }

        public void Log(string logEntry)
        {
            Application.Current.Dispatcher.Invoke(() => { _outputControl.Text += logEntry + Environment.NewLine; });
        }
    }
}