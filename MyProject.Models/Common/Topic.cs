namespace MyProject.Models.Common
{
    public class Topic : BaseModel
    {
        public string Environment { get; set; }
        public string Alias { get; set; }
        public string Destination { get; set; }
        public string ApplicationType { get; set; }
    }
}
