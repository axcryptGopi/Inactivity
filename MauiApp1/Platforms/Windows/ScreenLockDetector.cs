using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Platforms.Windows.Services
{
    public class ScreenLockDetector : IScreenLockDetector
    {
        public event EventHandler ScreenLocked;
        public event EventHandler ScreenUnlocked;

        public ScreenLockDetector()
        {
            ScreenDetector.Detector = this;
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
