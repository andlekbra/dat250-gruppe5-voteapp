using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteApp.Shared.Models
{
	public class PollDTO

	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please enter a startTime")]
		public DateTime StartTime { get; set; }
		[Required(ErrorMessage = "Please enter a stopTime")]
		public DateTime StopTime { get; set; }
		[Required(ErrorMessage = "Please enter a joinCode")]
		public int JoinCode { get; set; }
		[Required(ErrorMessage = "Please enter a name")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter a template ID")]
		public int TemplateId { get; set; }
		[Required(ErrorMessage = "Please enter voteCount ID")]
		public int VoteCountId { get; set; }
		[Required(ErrorMessage = "Please enter IoTDevice ID")]
		public List<int> IoTDevices { get; set; }
    }
}
