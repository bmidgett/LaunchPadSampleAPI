using System.Runtime.Serialization;

namespace LaunchPadAPI.Models
{
    [DataContract]
    public class LaunchPad
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "full_name")]
        public string Name { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}
