namespace MemberJWTDemo
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; internal set; }
    }
}