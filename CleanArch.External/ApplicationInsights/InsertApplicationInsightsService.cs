using CleanArch.Application.External.ApplicationInsights;
using CleanArch.Domain.ApplitationInsights;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;

namespace CleanArch.External.ApplicationInsights
{
    public class InsertApplicationInsightsService : IInsertApplicationInsightsService
    {
        private readonly IConfiguration _configuration;
        public InsertApplicationInsightsService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public bool Execute(InsertApplicationInsightsModel metric)
        {
            if (metric == null)
            {
                throw new ArgumentNullException(nameof(metric));
            }

            TelemetryConfiguration config = new TelemetryConfiguration();
            config.ConnectionString = _configuration["ApplicationInsightsConnectionString"];

            var _telemetryClient = new TelemetryClient(config);

            var properties = new Dictionary<string, string>
            {
                {"Id", metric.Id },
                {"Content", metric.Content },
                {"Detail", metric.Detail }

            };

            _telemetryClient.TrackTrace(metric.Type, SeverityLevel.Information, properties);
            return true;
        }
    }
}
