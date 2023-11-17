using Fantasy;

public class PlayerDatabase : Entity
{
    public string UserName;
    public string PassWord;
    public string CreateTime;

    public override void Dispose()
    {
        UserName = "";
        PassWord = "";
        CreateTime = "";

        base.Dispose();
    }
}
