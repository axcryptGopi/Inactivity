using MauiApp1.Platforms.MacCatalyst.NativeServices;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppKit;

namespace MauiApp1.Platforms.MacCatalyst.Services
{
    public class ScreenLockDetector : IScreenLockDetector
    {
        public event EventHandler ScreenLocked;
        public event EventHandler ScreenUnlocked;

        public ScreenLockDetector()
        {
            ScreenDetector.Detector = this;
            LockDetector.ScreenLocked += LockDetector_ScreenLocked;
            LockDetector.ScreenUnlocked += LockDetector_ScreenUnlocked;
        }

        private void LockDetector_ScreenUnlocked(object? sender, EventArgs e)
        {
            ScreenLocked?.Invoke(this, e);
        }

        private void LockDetector_ScreenLocked(object? sender, EventArgs e)
        {
            ScreenUnlocked?.Invoke(this, e);
        }
    }
}
