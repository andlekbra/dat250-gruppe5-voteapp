using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace VoteApp.DataAccess.Entities
{
	public class Poll
	{
		public int Id { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime StopTime { get; set; }
		public int JoinCode { get; set; }
		public string Name { get; set; }

		public PollTemplate Template { get; set; }

		public VoteCount VoteCount { get; set; }
	
		public ICollection<IoTDevice> IoTDevices { get; set; }
	

	}
}