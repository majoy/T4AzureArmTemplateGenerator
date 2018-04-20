using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using T4AzureArmTemplateGenerator.Namespace.Input;

namespace T4AzureArmTemplateGenerator.Namespace.Output
{
	public class NamespaceRootOutputJsonConverter
	{
		private readonly NamespaceRootOutputParser _rootOutputParser;

		public NamespaceRootOutputJsonConverter(NamespaceRootOutputParser rootOutputParser)
		{
			_rootOutputParser = rootOutputParser;
		}

		public Dictionary<string, string> ToJson(string namespaceRootInputAsJson)
		{
			var input = JsonConvert.DeserializeObject<NamespaceRootInput>(namespaceRootInputAsJson,
				new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				});

			return ToJson(input);
		}

		public Dictionary<string, string> ToJson(NamespaceRootInput input)
		{
			Dictionary<string, NamespaceRootOutput> parseResults = _rootOutputParser.Parse(input);

			Dictionary<string, string> results = new Dictionary<string, string>();

			foreach (KeyValuePair<string, NamespaceRootOutput> kvp in parseResults)
			{
				string outputAsString = JsonConvert.SerializeObject(kvp.Value, Formatting.Indented, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				});

				results.Add(kvp.Key, outputAsString);
			}


			return results;
		}
	}
}
