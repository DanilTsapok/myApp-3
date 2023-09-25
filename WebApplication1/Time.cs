public class TimeService: InTimeService
{


    private string? DatePhrase { get; set; }

     public TimeService()
        {
            DateTime now= DateTime.Now;
            int hour= now.Hour;

            switch (hour)
            {
                case int h when (h >= 6 && h < 12):
                DatePhrase = "Зараз Ранок";
                    break;
                case int h when (h >= 12 && h < 18):
                DatePhrase = "Зараз День";
                    break;
                case int h when (h >= 18 && h < 24):
                DatePhrase = "Зараз Вечір";
                    break;
            default:
                DatePhrase = "Зараз Ранок";
                break;
        
            }

    }
    public string GetPhrase()
    {
        if (DatePhrase== null) {
            throw new NullReferenceException("Server is not able to process time");
        }
        return DatePhrase;
    }
    
}