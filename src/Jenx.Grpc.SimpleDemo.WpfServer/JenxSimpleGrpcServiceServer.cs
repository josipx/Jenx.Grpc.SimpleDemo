using Grpc.Core;
using Jenx.Grpc.SimpleDemo.Contracts;
using System;
using System.Threading.Tasks;

namespace Jenx.Grpc.SimpleDemo.WpfServer
{
    public class JenxSimpleGrpcServiceServer : JenxSimpleGrpcService.JenxSimpleGrpcServiceBase
    {
        private readonly ILogger _logger;

        public JenxSimpleGrpcServiceServer(ILogger logger)
        {
            _logger = logger;
        }

        public override Task<ReplyMessage> SendMessage(RequestMessage request, ServerCallContext context)
        {
            _logger.Log($"Message Received: {request.RequestPayload}");
            _logger.Log("Sending message back to the client...");

            return Task.FromResult(new ReplyMessage { ResponsePayload = $"ServerSideTime is {DateTime.Now}" });
        }
    }
}