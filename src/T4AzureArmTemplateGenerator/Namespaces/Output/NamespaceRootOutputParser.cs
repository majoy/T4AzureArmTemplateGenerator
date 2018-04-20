using System.Collections.Generic;
using System.Data;
using T4AzureArmTemplateGenerator.Namespaces.Input;

namespace T4AzureArmTemplateGenerator.Namespaces.Output
{
	public class NamespaceRootOutputParser
	{
		private readonly Dictionary<string, LocationDefinitionInput> _locationDefinitions;
		private readonly Dictionary<string, NamespaceRootOutput> _parseResults;
		

		public NamespaceRootOutputParser()
		{
			_locationDefinitions = new Dictionary<string, LocationDefinitionInput>();
			_parseResults = new Dictionary<string, NamespaceRootOutput>();
		}

		public Dictionary<string, NamespaceRootOutput> Parse(NamespaceRootInput input)
		{
			InitLocationDefinitionsDictionary(input);

			InitParseResults(input);

			ParseNamespaces(input);

			return _parseResults;
		}

		private void ParseNamespaces(NamespaceRootInput input)
		{
			foreach (var namespaceInput in input.Namespaces)
			{
				foreach (var namespaceTargetLocation in namespaceInput.NamespaceTargetLocations)
				{
					var locationDefinition = _locationDefinitions[namespaceTargetLocation.LocationName];

					foreach (string namespaceEnvironment in namespaceTargetLocation.NamespaceEnvironments)
					{
						var namespaceRootOutput = _parseResults[namespaceEnvironment];
						var newNamespace = new NamespaceObjectValueOutput();
						newNamespace.Location = namespaceTargetLocation.LocationName;
						newNamespace.Sku = namespaceInput.Sku;
						newNamespace.Name = GetNamespaceName(namespaceInput.NamespaceNamePrefix, locationDefinition.NamespaceNameSuffix,
							namespaceEnvironment);
						newNamespace.Tags = namespaceInput.Tags;
						namespaceRootOutput.Parameters.NamespaceObjects.Value.Add(newNamespace);
					}

					ParseQueues(namespaceInput, input);
				}
			}
		}

		private string GetNamespaceName(string namespaceNamePrefix, string namespaceNameSuffix, string namespaceEnvironmentName)
		{
			return $"{namespaceNamePrefix}-{string.Format(namespaceNameSuffix, namespaceEnvironmentName)}";
		}

		private void ParseQueues(NamespaceInput namespaceInput, NamespaceRootInput input)
		{
			foreach (var queueTargetLocation in namespaceInput.QueueTargetLocations)
			{
				var namespaceRootOutput = _parseResults[queueTargetLocation.NamespaceEnvironmentName];
				var locationDefinition = _locationDefinitions[queueTargetLocation.LocationName];

				foreach (var queueEnvironment in queueTargetLocation.QueueEnvironments)
				{
					foreach (var queueInput in namespaceInput.Queues)
					{
						var newQueue = new QueueObjectValueOutput();
						newQueue.NamespaceName = GetNamespaceName(namespaceInput.NamespaceNamePrefix,
							locationDefinition.NamespaceNameSuffix, queueTargetLocation.NamespaceEnvironmentName);
						newQueue.NamespaceLocation = queueTargetLocation.LocationName;
						newQueue.QueueName = $"{queueInput.QueueNamePrefix}-{queueEnvironment}-wr";
						newQueue.QueueProperties = queueInput.Properties;
						newQueue.Tags = namespaceInput.Tags;
						namespaceRootOutput.Parameters.QueueObjects.Value.Add(newQueue);
					}
				}
			}
		}

		private void InitParseResults(NamespaceRootInput input)
		{
			foreach (var namespaceInput in input.Namespaces)
			{
				foreach (var namespaceTargetLocation in namespaceInput.NamespaceTargetLocations)
				{
					foreach (string namespaceEnvironment in namespaceTargetLocation.NamespaceEnvironments)
					{
						if (!_parseResults.ContainsKey(namespaceEnvironment))
						{
							_parseResults.Add(namespaceEnvironment, new NamespaceRootOutput());
						}
					}
				}
			}
		}


		private void InitLocationDefinitionsDictionary(NamespaceRootInput input)
		{
			for (int i = 0; i < input.LocationDefinitions.Count; i++)
			{
				var loc = input.LocationDefinitions[i];

				if (_locationDefinitions.ContainsKey(loc.LocationName))
					throw new DataException(
						$"Duplicate locationName property value of the LocationDefinition[{i}] which is not allowed");

				_locationDefinitions.Add(loc.LocationName, loc);
			}
		}
	}
}
