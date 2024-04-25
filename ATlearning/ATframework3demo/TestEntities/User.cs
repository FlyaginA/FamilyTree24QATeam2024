public class User
{
    public User(List<string> userData = null)
    {
        if (userData != null && userData.Count != 5)
        {
            throw new ArgumentException("Invalid argument: userData list should contain exactly 5 elements.");
        }
        if (userData != null)
        {
            this.Id = userData[0];
            this.Name = userData[1];
            this.Surname = userData[2];
            this.Login = userData[3];
            this.Password = userData[4];
        }
        
    }

    public string Login { get; set; }
    public string Password { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}