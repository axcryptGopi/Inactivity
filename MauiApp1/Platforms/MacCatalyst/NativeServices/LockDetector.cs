using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Platforms.MacCatalyst.NativeServices
{
    static class LockDetector
    {
        public static event EventHandler ScreenLocked;
        public static event EventHandler ScreenUnlocked;

        static NSObject lockedObserver;
        static NSObject unlockedObserver;

        static void Start()
        {
            lockedObserver = NSDistributedNotificationCenter.DefaultCenter.AddObserver(
                   (NSString)"com.apple.screenIsLocked",
                (notification) => ScreenLocked?.Invoke(null, EventArgs.Empty)
            );

            unlockedObserver = NSDistributedNotificationCenter.DefaultCenter.AddObserver(
                (NSString)"com.apple.screenIsUnlocked",
                (notification) => ScreenUnlocked?.Invoke(null, EventArgs.Empty)
            );
        }

        static void Stop()
        {
            if (lockedObserver != null)
            {
                NSDistributedNotificationCenter.DefaultCenter.RemoveObserver(lockedObserver);
                lockedObserver = null;
            }
            if (unlockedObserver != null)
            {
                NSDistributedNotificationCenter.DefaultCenter.RemoveObserver(unlockedObserver);
                unlockedObserver = null;
            }
        }
    }
}
