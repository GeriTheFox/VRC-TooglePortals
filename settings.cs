using MelonLoader;

namespace meow
{
    class settings
    {
        private const string catagory = "PortalToggle";
        public static MelonPreferences_Entry<bool> enabled;
        public static void Settings()
        {
            MelonPreferences.CreateCategory(catagory, "PortalToggle");
            enabled = MelonPreferences.CreateEntry(catagory, nameof(enabled), true, "Enable/disable portals");
        }
    }
}

