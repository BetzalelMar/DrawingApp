namespace DrawnigContracts.DTO
{
    public class RegisterRequest
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userConfirmPassword { get; set; }
    }
}
