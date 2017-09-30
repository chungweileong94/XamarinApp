namespace XamarinApp.Models
{
    public class BingImages
    {
        public Image[] Images { get; set; }
        public Tooltips Tooltips { get; set; }
    }

    public class Image
    {
        public long Drk { get; set; }
        public string Hsh { get; set; }
        public string Copyright { get; set; }
        public long Bot { get; set; }
        public string Copyrightlink { get; set; }
        public string Fullstartdate { get; set; }
        public string Enddate { get; set; }
        public object[] Hs { get; set; }
        public string Startdate { get; set; }
        public string Url { get; set; }
        public string Quiz { get; set; }
        public long Top { get; set; }
        public string Urlbase { get; set; }
        public bool Wp { get; set; }
    }

    public class Tooltips
    {
        public string Next { get; set; }
        public string Walle { get; set; }
        public string Loading { get; set; }
        public string Previous { get; set; }
        public string Walls { get; set; }
    }
}
