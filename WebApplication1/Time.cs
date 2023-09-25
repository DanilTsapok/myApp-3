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
                DatePhrase = "����� �����";
                    break;
                case int h when (h >= 12 && h < 18):
                DatePhrase = "����� ����";
                    break;
                case int h when (h >= 18 && h < 24):
                DatePhrase = "����� �����";
                    break;
            default:
                DatePhrase = "����� �����";
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