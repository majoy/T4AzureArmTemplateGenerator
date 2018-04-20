using System.Collections.Generic;

namespace T4AzureArmTemplateGenerator.Namespace.Output
{
	public class QueueObjectsOutput
	{
		public List<QueueObjectValueOutput> Value { get; set; }

		public QueueObjectsOutput()
		{
			Value = new List<QueueObjectValueOutput>();
		}
	}
}