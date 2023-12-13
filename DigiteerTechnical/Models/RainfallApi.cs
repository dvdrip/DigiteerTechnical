namespace DigiteerTechnical.Models
{
    public class RainfallApi
    {
        public string version { get; set; }
        public string title { get; set; }
        public Contact contact { get; set; }
        public string description { get; set; }
    }

    public class Contact
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class RainfallReadingResponse
    {
        public List<RainfallReading> readings { get; set; }
    }

    public class RainfallReading
    {
        public DateTime dateMeasured { get; set; }
        public decimal amountMeasured { get; set; }
    }

    public class ErrorResponse
    {
        public string message { get; set; }
        public List<ErrorDetail> detail { get; set; }
    }

    public class ErrorDetail
    {
        public string propertyName { get; set; }
        public string message { get; set; }
    }

}