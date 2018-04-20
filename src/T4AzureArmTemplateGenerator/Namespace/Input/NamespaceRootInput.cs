using System.Collections.Generic;

namespace T4AzureArmTemplateGenerator.Namespace.Input
{
	public class NamespaceRootInput
	{
        public string NamespaceNameEndSuffix { get; set; }
		public List<LocationDefinitionInput> LocationDefinitions { get; set; }
		public List<NamespaceInput> Namespaces { get; set; }

		public NamespaceRootInput()
		{
			LocationDefinitions = new List<LocationDefinitionInput>();
			Namespaces = new List<NamespaceInput>();
		}
	}
}
