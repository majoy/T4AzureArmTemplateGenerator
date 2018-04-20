using T4AzureArmTemplateGenerator.Namespace.Output;

namespace T4AzureArmTemplateGenerator.Namespace.Input
{
	public class QueueInput
	{
		public string QueueNamePrefix { get; set; }
		public QueuePropertiesOutput Properties { get; set; }
	}
}