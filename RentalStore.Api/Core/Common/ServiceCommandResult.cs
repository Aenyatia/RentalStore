using System.Collections.Generic;

namespace RentalStore.Api.Core.Common
{
	public class ServiceCommandResult
	{
		public bool IsValid => Errors.Count == 0;
		public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();

		public void AddError(string code, string description)
		{
			if (!Errors.ContainsKey(code))
				Errors.Add(code, description);
		}

		public void AddError((string code, string description) error)
		{
			if (!Errors.ContainsKey(error.code))
				Errors.Add(error.code, error.description);
		}
	}
}
