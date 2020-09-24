using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace GrpcMeasure
{
    [Authorize]
    public class MeasureService : Measure.MeasureBase
    {
        private readonly ILogger<MeasureService> _logger;
        public MeasureService(ILogger<MeasureService> logger)
        {
            _logger = logger;
        }


        public override async Task<Empty> SendMeasure(IAsyncStreamReader<MeasureRequest> requestStream,
            ServerCallContext context)
        {
            await foreach (var measure in requestStream.ReadAllAsync())
            {
                _logger.LogInformation($"New measure received : {measure.Name}={measure.Value}");
            }
            return new Empty();
        }
    }
}
