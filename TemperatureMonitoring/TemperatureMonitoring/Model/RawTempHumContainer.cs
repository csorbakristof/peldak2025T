namespace TemperatureMonitoring.Model
{
    public class RawTempHumContainer
    {
        public List<TempHum> AllTempHums = new List<TempHum>();

        public delegate void TempHumAdded();
        public event TempHumAdded? TempHumAddedEvent;

        public void Add(IEnumerable<TempHum> newTempHums)
        {
            AllTempHums.AddRange(newTempHums);
            TempHumAddedEvent?.Invoke();
        }
    }
}
