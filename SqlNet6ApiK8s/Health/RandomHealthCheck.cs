
namespace SqlNet6ApiK8s.Health
{
    public class RandomHealthCheck : IHealthCheck
    {
        private static readonly Random random = new Random();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            isHealthy = random.Next(10) != 7;

            var result = isHealthy
                ? HealthCheckResult.Healthy("The app is healthy")
                : HealthCheckResult.Unhealthy("The app is failing");

            return Task.FromResult(result);
        }
    }
}
