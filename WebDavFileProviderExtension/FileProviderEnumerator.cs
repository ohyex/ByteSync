using System;
using FileProvider;
using Foundation;

namespace WebDavFileProviderExtension
{
    public class FileProviderEnumerator : NSObject, INSFileProviderEnumerator
    {
        private string _containerItemIdentifier;

        public FileProviderEnumerator(string containerItemIdentifier)
        {
            _containerItemIdentifier = containerItemIdentifier;
        }


        void INSFileProviderEnumerator.EnumerateItems(INSFileProviderEnumerationObserver observer, NSData startPage)
        {
            observer.DidEnumerateItems(new INSFileProviderItem[] { });
            observer.FinishEnumerating((NSData)null);
        }

        void INSFileProviderEnumerator.Invalidate()
        {
        }
    }
}

