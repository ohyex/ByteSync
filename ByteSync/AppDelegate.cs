using AppKit;
using Foundation;

namespace ByteSync
{
	[Register ("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate
	{
		public AppDelegate ()
		{
		}

		public override void DidFinishLaunching (NSNotification notification)
		{
			FileProviderManager.RegisterDomains();
			// Insert code here to initialize your application
		}

		public override void WillTerminate (NSNotification notification)
		{
			FileProviderManager.RemoveDomains();
			// Insert code here to tear down your application
		}
	}
}

