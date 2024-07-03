public class User
{
    public string Name { get; private set; }
    public int Score { get; private set; }

    public User(string name, int score)
    {
        Name = name;
        Score = score;
    }
}




