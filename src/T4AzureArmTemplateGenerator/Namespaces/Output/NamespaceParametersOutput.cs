namespace T4AzureArmTemplateGenerator.Namespaces.Output
{
	public class NamespaceParametersOutput
	{
		public NamespaceObjectsOutput NamespaceObjects { get; set; }
		public QueueObjectsOutput QueueObjects { get; set; }

		public NamespaceParametersOutput()
		{
			NamespaceObjects = new NamespaceObjectsOutput();
			QueueObjects = new QueueObjectsOutput();
		}
	}
}