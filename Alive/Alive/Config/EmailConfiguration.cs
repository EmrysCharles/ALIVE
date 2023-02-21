namespace Alive.Config
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; } = string.Empty;
        public int SmtpPort { get; set; } = 0;
        public string SmtpUsername { get; set; } = string.Empty;
        public string SmtpPassword { get; set; }  = string.Empty;   


        public string PopServer { get; set; } = string.Empty;   
        public int PopPort { get; set; }
        public string PopUsername { get; set; } = string.Empty; 
        public string PopPassword { get; set; } = string.Empty; 
    

    }
}
