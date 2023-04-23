using System;
using FileProvider;

namespace ByteSync
{
    public static class FileProviderManager
    {
        public static void RegisterDomains()
        {
            Console.WriteLine("RegisterDomains starting");

            // List registered domains
            NSFileProviderManager.GetDomains((domains, err) =>
            {
                if (err != null)
                {
                    Console.WriteLine("Error getting domains: {0}", err);
                }
                else
                {
                    foreach (var domain in domains)
                    {
                        Console.WriteLine("Get Domain: {0}", domain.Identifier);
                    }
                }
                   
            });

            // Remove all domains
            NSFileProviderManager.RemoveAllDomains(err =>
            {
                if (err != null)
                {
                    Console.WriteLine("Error removing domains: {0}", err);
                }
            });

            // Register domain
            var domainIdentifier = "com.ymh.ByteSync";
            var domainDisplayName = "CloudFileProvider";
            var fileProviderDomain = new NSFileProviderDomain(domainIdentifier, domainDisplayName);
            NSFileProviderManager.AddDomain(
                fileProviderDomain,
                err =>
                {
                    if (err != null)
                    {
                        Console.WriteLine("Error adding domain: {0}", err);
                    }
                });
            var manager = NSFileProviderManager.FromDomain(fileProviderDomain);
            manager?.SignalEnumerator(NSFileProviderItemIdentifier.RootContainer, err =>
            {
                if (err != null)
                {
                    Console.WriteLine("signalEnumerator failed: {0}", err);
                }
                else
                {
                    Console.WriteLine("signalEnumerator succeeded");
                }
            });
        }

        public static void RemoveDomains()
        {
            NSFileProviderManager.RemoveAllDomains(err =>
            {
                if (err != null) Console.WriteLine("Error removing domains: {0}", err);
            });
        }
    }

    
}

