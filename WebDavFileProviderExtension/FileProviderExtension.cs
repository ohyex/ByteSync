using System;
using Common;
using FileProvider;
using Foundation;

namespace WebDavFileProviderExtension
{
    [Register("WebDavFileProviderExtension")]
    public class FileProviderExtension : NSExtensionRequestHandling, INSFileProviderReplicatedExtension
    {
        [Export("initWithDomain:")]
        public FileProviderExtension()
        {
        }


        public NSProgress CreateItem(INSFileProviderItem itemTemplate, NSFileProviderItemFields fields, NSUrl url,
            NSFileProviderCreateItemOptions options, NSFileProviderRequest request,
            NSFileProviderCreateOrModifyItemCompletionHandler completionHandler)
        {
            NSLogHelper.NSLog("CreateItem:\nitemTemplate = {0}\nfields = {1}\nurl = {2}\noptions = {3}\nrequest = {4}",
                itemTemplate, fields, url, options, request);
            completionHandler(itemTemplate, fields, false, null);
            return new NSProgress();
        }

        public NSProgress DeleteItem(string identifier, NSFileProviderItemVersion version,
            NSFileProviderDeleteItemOptions options, NSFileProviderRequest request, Action<NSError> completionHandler)
        {
            NSLogHelper.NSLog("DeleteItem:\nidentifier = {0}\nversion = {1}\noptions = {2}\nrequest = {3}", identifier,
                version, options, request);
            completionHandler(new NSError(NSError.CocoaErrorDomain, 3328));
            return new NSProgress();
        }


        public NSProgress FetchContents(string itemIdentifier, NSFileProviderItemVersion requestedVersion,
            NSFileProviderRequest request, NSFileProviderFetchContentsCompletionHandler completionHandler)
        {
            NSLogHelper.NSLog("fetchContents:\nitemIdentifier = {0}\nrequestedVersion = {1}\nrequest = {2}",
                itemIdentifier, requestedVersion, request);
            completionHandler(null, null, new NSError(NSError.CocoaErrorDomain, 3328));
            return new NSProgress();
        }

        public INSFileProviderEnumerator GetEnumerator(string containerItemIdentifier, NSFileProviderRequest request,
            out NSError error)
        {
            NSLogHelper.NSLog("GetEnumerator:\ncontainerItemIdentifier = {0}\nrequest = {1}", containerItemIdentifier,
                request);
            error = null;
            return new FileProviderEnumerator(containerItemIdentifier);
        }

        public NSProgress GetItem(string identifier, NSFileProviderRequest request,
            Action<INSFileProviderItem, NSError> completionHandler)
        {
            NSLogHelper.NSLog("GetItem:\nidentifier = {0}\nrequest = {1}", identifier, request);
            completionHandler(new FileProviderItem(identifier), null);
            return new NSProgress();
        }

        public void Invalidate()
        {
        }

        public NSProgress ModifyItem(INSFileProviderItem item, NSFileProviderItemVersion version,
            NSFileProviderItemFields changedFields, NSUrl newContents, NSFileProviderModifyItemOptions options,
            NSFileProviderRequest request, NSFileProviderCreateOrModifyItemCompletionHandler completionHandler)
        {
            NSLogHelper.NSLog(
                "ModifyItem:\nitem = {0}\nversion = {1}\nchangedFields = {2}\nnewContents = {3}\noptions = {4}\nrequest = {5}",
                item, version, changedFields, newContents, options, request);
            return null;
        }

        public override void BeginRequestWithExtensionContext(NSExtensionContext context)
        {
        }
    }
}

