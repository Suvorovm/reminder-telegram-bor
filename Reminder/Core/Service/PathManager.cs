using System;

namespace Reminder.Core.Service
{
    public class PathManager
    {
        public string GetCurrentPath()
        {
            return Environment.CurrentDirectory;
        }

        public string GetResourcePath()
        {
            return GetCurrentPath() + "\\";
        }
    }
}