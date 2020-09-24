using Coding4Fun.gRPC.Server;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Coding4Fun.gRPC.Client
{
    class Program
    {
        private const string SERVER_ADDRESS = "https://localhost:5001";

        static async Task Main(string[] _)
        {
            using (GrpcChannel channel = GrpcChannel.ForAddress(SERVER_ADDRESS))
            {
                Greeter.GreeterClient client = new Greeter.GreeterClient(channel);
                HelloReply reply = await client.SayHelloAsync(new HelloRequest { Name = "Coding4Fun" });
                Console.WriteLine($"Greeting: {reply.Message}!");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
