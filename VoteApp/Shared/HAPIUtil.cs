using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VoteApp.Shared
{
	public static class HAPIUtil
	{
		private static string ErrorString(string error, string because)
		{
			string response = JsonSerializer.Serialize(new
			{
				_PHthis = "failed", //_PHthis because "this" is reserved and doesn't seem hide-able in this context
				with = error,
				because = because
			}).Replace("_PHthis", "this");

			return response;
		}


		private static string ErrorString(Exception exception, string because)
		{
			return ErrorString(exception.GetBaseException().GetType().ToString(), because);
		}

		public static string Failed(string error, string because)
		{
			return ErrorString(error, because);
		}
		public static string Failed(Exception exception, string because)
		{
			return ErrorString(exception, because);
		}

		public static string Succeeded(Verb by, string verb, Resource the,object with)
		{
			string response = JsonSerializer.Serialize(new
			{
				_PHthis = "succeeded", //_PHthis because "this" is reserved and doesn't seem hide-able in this context
				by = verbDick.GetValueOrDefault(by, "SomethingWentWrong"),
				the = resourceDick,
				with = JsonSerializer.Serialize(with)
			}).Replace("_PHthis", "this");

			return response;
		}

		private static readonly Dictionary<Resource, string> resourceDick
			= new Dictionary<Resource, string>() {
				{ Resource.APPLICATIONUSER, "ApplicationUser" },
				{Resource.IOTDEVICE, "IoTDevice" },
				{Resource.POLL, "Poll" },
				{Resource.POLLTEMPLATE, "PollTemplate" },
				{ Resource.VOTECOUNT, "VoteCount"},
				{ Resource.VOTERPROFILE, "VoterProfile"}
			};


		public enum Resource
		{
			APPLICATIONUSER = 0,
			IOTDEVICE = 1,
			POLL = 2,
			POLLTEMPLATE = 3,
			VOTECOUNT = 4,
			VOTERPROFILE = 5
		}

		private static readonly Dictionary<Verb, string> verbDick 
			= new Dictionary<Verb, string>() { 
				{ Verb.CREATING, "creating" }, 
				{Verb.READING, "reading" },
				{Verb.UPDATING, "updating" },
				{Verb.DELETING, "deleting" }
			};

		public enum Verb
		{
			CREATING = 0,
			READING = 1,
			UPDATING = 2,
			DELETING = 3,

		}
	}
}

