
using System.Collections.Generic;

namespace VoteApp.DataAccess.Entities
{ 

    public class VoterProfile
    
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public ICollection<PollTemplate> PollTemplates { get; set; }
    }
}