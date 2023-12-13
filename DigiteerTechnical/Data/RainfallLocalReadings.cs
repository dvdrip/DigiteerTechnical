using DigiteerTechnical.Models;

namespace DigiteerTechnical.Data
{
    public class RainfallLocalReadings
    {
        //Sample readings
        public List<RainfallReading> GenerateRainfallReadings(string stationId, int count)
        {
            RainfallPublicReadings readings = new RainfallPublicReadings();
            string parameterSample = "rainfall";
            var x = readings.GetRainfallAPIReadings(stationId, parameterSample, count);

            List<RainfallReading> myReadings = new List<RainfallReading>();

            foreach (var item in x.items)
            {
                RainfallReading reading = new RainfallReading
                {
                    DateMeasured = item.dateTime,
                    AmountMeasured = (decimal)item.value
                };

                myReadings.Add(reading);
            }

            return myReadings;
        }
    }
}
