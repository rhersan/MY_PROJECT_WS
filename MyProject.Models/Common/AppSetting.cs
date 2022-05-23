namespace MyProject.Models.Common
{
    public class AppSetting
    {
        public int MinimumLength { get; set; }
        public int MaximumAttempts { get; set; }
        public string PasswordRegex { get; set; }
        public bool ChangePassword { get; set; }
        public int MinimumMemorySpace { get; set; }
        public int PasswordLifeTime { get; set; }
        public bool ReusePassword { get; set; }

    }
}
