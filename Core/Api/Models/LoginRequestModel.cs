namespace Core.Api.Models
{
    public class LoginRequestModel
    {
        public string res_width { get; set; }
        public string res_height { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string remember { get; set; }
        public string language { get; set; }
        public string theme { get; set; }
        public string login_module { get; set; }
        public string login_action { get; set; }
        public string login_record { get; set; }
        public string login_layout { get; set; }
        public string mobile { get; set; }
        public string no_persist_theme { get; set; }
        public string gmto { get; set; }

        public LoginRequestModel(
            string resWidth,
            string resHeight,
            string username,
            string password,
            string remember,
            string language,
            string theme,
            string loginModule,
            string loginAction,
            string loginRecord,
            string loginLayout,
            string mobile,
            string noPersistTheme,
            string gmto)
        {
            res_width = resWidth;
            res_height = resHeight;
            this.username = username;
            this.password = password;
            this.remember = remember;
            this.language = language;
            this.theme = theme;
            login_module = loginModule;
            login_action = loginAction;
            login_record = loginRecord;
            login_layout = loginLayout;
            this.mobile = mobile;
            no_persist_theme = noPersistTheme;
            this.gmto = gmto;
        }
    }
}
