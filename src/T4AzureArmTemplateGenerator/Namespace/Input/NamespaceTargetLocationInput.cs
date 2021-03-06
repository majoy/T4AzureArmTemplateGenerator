﻿using System.Collections.Generic;

namespace T4AzureArmTemplateGenerator.Namespace.Input
{
	public class NamespaceTargetLocationInput
	{
		public string LocationName { get; set; }
		public List<string> NamespaceEnvironments { get; set; }

		public NamespaceTargetLocationInput()
		{
			NamespaceEnvironments = new List<string>();
		}
	}
}