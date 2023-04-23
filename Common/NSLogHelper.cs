using System;
using System.Runtime.InteropServices;
using CoreFoundation;
using Foundation;

namespace Common
{
    public static class NSLogHelper
    {
        [DllImport("/System/Library/Frameworks/Foundation.framework/Foundation")]
        private static extern void NSLog(IntPtr format, [MarshalAs(UnmanagedType.LPStr)] string s);

        public static void NSLog(string format, params object[] args)
        {
            var fmt = CFString.CreateNative("%s");
            var val = args == null || args.Length == 0 ? format : string.Format(format, args);

            NSLog(fmt, val);
            NSString.ReleaseNative(fmt);
        }
    }
}