using System.Collections.Generic;

namespace MyProject.Common.HttpResponses
{
    public class MicroservicesHttpGenericResponse
    {
        public string Text { get; set; }
        public string Severity { get; set; }
        public string Title { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }


}
