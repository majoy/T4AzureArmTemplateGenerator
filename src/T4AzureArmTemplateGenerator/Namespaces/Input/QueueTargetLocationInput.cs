using System.Collections.Generic;

namespace T4AzureArmTemplateGenerator.Namespaces.Input
{
	public class QueueTargetLocationInput
	{
		public string LocationName { get; set; }
		
		public string NamespaceEnvironmentName { get; set; }
		public List<string> QueueEnvironments { get; set; }
		public QueueTargetLocationInput()
		{
			QueueEnvironments = new List<string>();
		}
	}
	
}
