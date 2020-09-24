using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcMeasure;

namespace MeasureClient
{
    class Program
    {
        private static readonly Random Random = new Random();
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Measure.MeasureClient(channel);

            var authClient = new Auth.AuthClient(channel);
            var tokenReply = authClient.GetToken(new TokenRequest() {Name = "Coding4FunClient"});


            var headers = new Metadata();
            headers.Add("Authorization", $"Bearer {tokenReply.Token}");
            using (var call = client.SendMeasure(headers))
            {
                for (var i = 0; i < 5; i++)
                {
                    var measure = new MeasureRequest()
                    {
                        Name = "Temp",
                        Value = Random.Next()
                    };
                    await call.RequestStream.WriteAsync(measure);
                    Console.WriteLine($"Measure send {measure.Value}");
                    await Task.Delay(2000);
                }

                await call.RequestStream.CompleteAsync();

                await call;
            }
        }
    }
}
