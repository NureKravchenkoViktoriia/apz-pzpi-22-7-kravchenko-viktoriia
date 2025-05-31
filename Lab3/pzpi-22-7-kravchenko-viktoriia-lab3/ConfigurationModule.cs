public class ConfigurationModule
{
    public string ServerUrl { get; set; }
    public int DataCollectionInterval { get; set; } // Інтервал збору даних у секундах

    public ConfigurationModule(string serverUrl, int dataCollectionInterval)
    {
        ServerUrl = serverUrl;
        DataCollectionInterval = dataCollectionInterval;
    }
}
