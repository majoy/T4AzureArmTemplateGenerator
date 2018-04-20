using System.Collections.Generic;

namespace T4AzureArmTemplateGenerator.Namespace.Input
{
	public class NamespaceInput
	{
		public string NamespaceNamePrefix { get; set; }
		public string Sku { get; set; }
		public TagOutput Tags { get; set; }
		public List<NamespaceTargetLocationInput> NamespaceTargetLocations { get; set; }
		public List<QueueTargetLocationInput> QueueTargetLocations { get; set; }

		public List<QueueInput> Queues { get; set; }

		public NamespaceInput()
		{
			NamespaceTargetLocations = new List<NamespaceTargetLocationInput>();
			QueueTargetLocations = new List<QueueTargetLocationInput>();
			Queues = new List<QueueInput>();
			Tags = new TagOutput();
		}
	}
}
