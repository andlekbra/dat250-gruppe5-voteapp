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
		public int PollTemplateId { get; set; }
		[ForeignKey("PollTemplateId"), JsonIgnore]
		public PollTemplate Template { get; set; }
		[JsonIgnore]
		public VoteCount VoteCount { get; set; }
		[JsonIgnore]
		public ICollection<IoTDevice> IoTDevices { get; set; }

		[JsonInclude]
		public List<int> IoTDevicesIds
		{
			get
			{
				return IoTDevices?.Select(device => device.Id).ToList();
			}
		}

	}
}