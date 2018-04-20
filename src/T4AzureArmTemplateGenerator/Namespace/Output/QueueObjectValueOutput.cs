namespace T4AzureArmTemplateGenerator.Namespace.Output
{
	public class QueueObjectValueOutput
	{
		public string NamespaceName { get; set; }
		public string NamespaceLocation { get; set; }
		public string QueueName { get; set; }

		public QueuePropertiesOutput QueueProperties { get; set; }
		public TagOutput Tags { get; set; }

		public QueueObjectValueOutput()
		{
			QueueProperties = new QueuePropertiesOutput();
			Tags = new TagOutput();

		}

	}
}