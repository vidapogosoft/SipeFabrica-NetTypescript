namespace BackendTaller.Interfaces
{
    public interface IJwt
    {
        string auth(string username, string password);
    }
}
