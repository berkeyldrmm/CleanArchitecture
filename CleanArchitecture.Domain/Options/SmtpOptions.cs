using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Options
{
    public class SmtpOptions
    {
        public string SenderEmail { get; set; }
        public string ApplicationCode { get; set; }
        public string Host { get; set; }
        public bool Ssl { get; set; }
        public int Port { get; set; }
    }
}
