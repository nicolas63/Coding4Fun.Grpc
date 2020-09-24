# Coding4Fun gRPC

mkdir d:\temp\Coding4Fun-gRPC
cd d:\temp\Coding4Fun-gRPC
dotnet new sln

dotnet new grpc -o Coding4FungRPC.Server 
dotnet sln .\Coding4Fun-grpc.sln add .\Coding4FungRPC.Server\Coding4FungRPC.Server.csproj

dotnet new console -o Coding4FungRPC.Client
dotnet sln .\Coding4Fun-grpc.sln add .\Coding4FungRPC.Client\Coding4FungRPC.Client.csproj

cd .\Coding4FungRPC.Client\

dotnet add .\Coding4FungRPC.Client\Coding4FungRPC.Client.csproj package Grpc.Net.Client
dotnet add .\Coding4FungRPC.Client\Coding4FungRPC.Client.csproj package Google.Protobuf
dotnet add .\Coding4FungRPC.Client\Coding4FungRPC.Client.csproj package Grpc.Tools