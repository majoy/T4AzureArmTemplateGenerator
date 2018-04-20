namespace T4AzureArmTemplateGenerator.Namespaces.Output
{
	public class QueuePropertiesOutput
	{
		public string LockDuration { get; set; } 
		public int? MaxSizeInMegabytes { get; set; }
		public bool? RequiresDuplicateDetection { get; set; }
		public bool? RequiresSession { get; set; }
		public string DefaultMessageTimeToLive { get; set; }
		public bool? DeadLetteringOnMessageExpiration { get; set; }
		public string DuplicateDetectionHistoryTimeWindow { get; set; }
		public int? MaxDeliveryCount { get; set; }
		public string Status { get; set; }
		public string AutoDeleteOnIdle { get; set; }
		public bool? EnablePartitioning { get; set; }
		public bool? EnableExpress { get; set; }
		public string ForwardTo { get; set; }
		public string ForwardDeadLetteredMessagesTo { get; set; }
	}
}