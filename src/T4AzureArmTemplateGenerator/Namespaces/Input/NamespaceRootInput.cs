using System.Collections.Generic;

namespace T4AzureArmTemplateGenerator.Namespaces.Input
{
	public class NamespaceRootInput
	{
		public List<LocationDefinitionInput> LocationDefinitions { get; set; }
		public List<NamespaceInput> Namespaces { get; set; }

		public NamespaceRootInput()
		{
			LocationDefinitions = new List<LocationDefinitionInput>();
			Namespaces = new List<NamespaceInput>();
		}
	}
}
