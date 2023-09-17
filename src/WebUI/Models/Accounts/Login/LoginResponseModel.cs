namespace WebUI.Models.Accounts.Login
{
    public class LoginResponseModel
    {
        public Data Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

    }

    public class Data
    {
        public TokenModel Token { get; set; }
    }

}
