using System;
using System.Collections.Generic;
using System.Text;

namespace VoteApp.DataAccess.Entities
{
    public class PollTemplate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string RedAnswer { get; set; }
        public string GreenAnswer { get; set; }
        public VoterProfile Creator { get; set; }
        public ICollection<Poll> Polls { get; set; }
    }
}
