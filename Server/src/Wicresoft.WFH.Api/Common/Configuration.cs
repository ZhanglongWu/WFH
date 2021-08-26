namespace Wicresoft.WFH.Api
{
    using System.Configuration;

    using Wicresoft.WFH.Core;

    public static class Configuration
    {
        public static int CommandTimeout => AppSettingsHelper.GetAppSetting("CommandTimeout", 600);
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["WorkFromHomeEntities"].ConnectionString;
        public static string Secret => AppSettingsHelper.GetAppSetting("Secret",
                "V41ofIdJ5u+RVUaYy6mJ28s9LYsRj7apvz8SOD24HLeMI2ddDwOnRCelxCc+Z76046w2ZLrapmwi0q6QEPJGuqvDLczyulfbx/Q3PiLzFEoG7QU4zn5ooJVHi3s+G1IGlgPwnJX1O1l5H3i8+oOlM9ww8/EJs6t/++PG5Z7gQhB0Fb4e5+yIbSkW4hBiK/ZzFVWygxy37rYigRm8MaVqIIKD4xlZcEX7T7FiQwG3rJPbghBkZwZ53Yt+Ee3B6DW+")
            .Decrypt();

        public static string CorsOrigin => "*";
    }
}