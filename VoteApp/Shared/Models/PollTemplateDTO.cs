using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteApp.Shared.Models
{
    public class PollTemplateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a Question")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Please enter a red answer")]
        public string RedAnswer { get; set; }
        [Required(ErrorMessage = "Please enter a green answer")]
        public string GreenAnswer { get; set; }
    }
}
