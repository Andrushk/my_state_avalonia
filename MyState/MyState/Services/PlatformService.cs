namespace MyState.Services
{
    public enum RunPlatform {Windows, MacOs, Android, AndroidEmulator, IOs, Web}

    public static class PlatformService
    {
        static PlatformService()
        {
            //TODO получать платформу, а не присваивать руками
            CurrentPlatform = RunPlatform.Web;

            ApiUri = GetApiUri();
        }

        public static RunPlatform CurrentPlatform { get; }

        public static string ApiUri { get; }

        public static string GetApiUri()
        {
            switch (CurrentPlatform)
            {
                case RunPlatform.AndroidEmulator:
                    return "http://10.0.2.2:5479";
            }

            //TODO брать из конфига
            return "http://localhost:5479";
        }
    }
}
