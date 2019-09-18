namespace LaunchPadAPI.Infrastructure
{
    public static class URIs
    {
        public static class SpaceX
        {
            public static class LaunchPad
            {
                public static string GetLaunchPads(string baseUri, int limit, int offset)
                {
                    return $"{baseUri}/launchpads?limit={limit}&offset={offset}";
                }
            }
        }
    }
}
