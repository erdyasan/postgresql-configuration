namespace DotnetConfiguration.CustomConfiguration;

public class PostgreConfigurationSource : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new PostgreSqlConfigurationProvider();
    }
}