using System;
using FileProvider;
using Foundation;
using UniformTypeIdentifiers;

namespace WebDavFileProviderExtension
{
    public class FileProviderItem : NSObject, INSFileProviderItem
    {
        public string Identifier;

        public FileProviderItem(string identifier)
        {
            Identifier = identifier;
        }


        string INSFileProviderItem.Identifier => Identifier;
        string INSFileProviderItem.ParentIdentifier => NSFileProviderItemIdentifier.RootContainer;
        string INSFileProviderItem.Filename => Identifier;

        string INSFileProviderItem.TypeIdentifier => Identifier == NSFileProviderItemIdentifier.RootContainer
            ? UTTypes.Folder.ToString()
            : UTTypes.PlainText.ToString();
    }
}

