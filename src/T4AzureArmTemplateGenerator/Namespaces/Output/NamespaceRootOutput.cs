using Newtonsoft.Json;

namespace T4AzureArmTemplateGenerator.Namespaces.Output
{
	public class NamespaceRootOutput : ISchema
	{
		[JsonProperty("$schema")]
		public string Schema { get; set; }

		public string ContentVersion { get; set; }

		public NamespaceParametersOutput Parameters { get; set; }

		public NamespaceRootOutput()
		{
			Schema = "https://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#";
			ContentVersion = "1.0.0.0";
			Parameters = new NamespaceParametersOutput();
		}
	}
}
