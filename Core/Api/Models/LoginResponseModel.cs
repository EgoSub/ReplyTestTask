namespace Core.Api.Models
{
    public class LoginResponseModel
    {
        public string result { get; set; }
        public string json_session_id { get; set; }
        public string user_id { get; set; }
        public string session_name { get; set; }
        public string redirect { get; set; }
    }
}
