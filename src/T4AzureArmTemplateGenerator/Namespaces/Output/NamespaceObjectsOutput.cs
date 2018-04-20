using System.Collections.Generic;

namespace T4AzureArmTemplateGenerator.Namespaces.Output
{
	public class NamespaceObjectsOutput
	{
		public List<NamespaceObjectValueOutput> Value { get; set; }

		public NamespaceObjectsOutput()
		{
			Value = new List<NamespaceObjectValueOutput>();
		}
	}
}