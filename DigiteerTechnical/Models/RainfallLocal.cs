namespace DigiteerTechnical.Models
{
    public class RainfallLocal
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public Contact Contact { get; set; }
        public string Description { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class RainfallReadingResponse
    {
        public List<RainfallReading> Readings { get; set; }
    }

    public class RainfallReading
    {
        public DateTime DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }

    public class ErrorResponse
    {
        public string Message { get; set; }
        public List<ErrorDetail> Detail { get; set; }
    }

    public class ErrorDetail
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }

}