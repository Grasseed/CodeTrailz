using System.Text.Json.Serialization;

namespace TreeForSuccess.Model
{
	public class HeaderModel
	{
		[JsonPropertyName("authorization")]
		public required string Authorization { get; set; }
	}
}
