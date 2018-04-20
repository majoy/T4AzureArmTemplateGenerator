using Newtonsoft.Json;

namespace T4AzureArmTemplateGenerator
{
	public interface ISchema
	{
		[JsonProperty(PropertyName = "$schema")]
		string Schema { get; set; }

		string ContentVersion { get; set; }
	}
}
