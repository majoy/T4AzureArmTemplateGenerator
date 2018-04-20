using T4AzureArmTemplateGenerator.Namespaces.Output;

namespace T4AzureArmTemplateGenerator.Namespaces.Input
{
	public class QueueInput
	{
		public string QueueNamePrefix { get; set; }
		public QueuePropertiesOutput Properties { get; set; }
	}
}