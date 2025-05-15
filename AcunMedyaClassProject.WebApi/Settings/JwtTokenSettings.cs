namespace AcunMedyaClassProject.WebApi.Settings
{
    public class JwtTokenSettings
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Expire { get; set; }
    }
}
