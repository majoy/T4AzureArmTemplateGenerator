using System.Collections.Generic;

namespace T4AzureArmTemplateGenerator.Namespace.Input
{
	public class NamespaceRootInputValidator
	{
		public (bool IsValid, List<string> Reasons) IsValid(NamespaceRootInput input)
		{
			bool isValid = true;
			List<string> reasons = new List<string>();

			if (input.LocationDefinitions.Count == 0)
			{
				isValid = false;
				reasons.Add("LocationDefinitions array must have at least one item");
			}

			for (var index = 0; index < input.Namespaces.Count; index++)
			{
				NamespaceInput namespaceInput = input.Namespaces[index];
				if (string.IsNullOrEmpty(namespaceInput.NamespaceNamePrefix))
				{
					isValid = false;
					reasons.Add($"Namespace[{index}] does not contain a namespace name prefix");
				}
			}

			//TODO: add more validation rules

			return (isValid, reasons);
		}
	}
}
