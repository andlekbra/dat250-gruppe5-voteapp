using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteApp.Shared.Models
{
    public class RegistrationResponseDTO
    {
        public bool IsRegistrationSuccessfull { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

}
