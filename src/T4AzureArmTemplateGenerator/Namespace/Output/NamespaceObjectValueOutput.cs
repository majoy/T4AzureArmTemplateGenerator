namespace T4AzureArmTemplateGenerator.Namespace.Output
{
	public class NamespaceObjectValueOutput
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Sku { get; set; }
		public TagOutput Tags { get; set; }

		public NamespaceObjectValueOutput()
		{
			Tags = new TagOutput();
		}
	}
}