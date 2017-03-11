namespace T4.Business.Models.Interfaces
{
    public interface ICoreCommandFactory
    {
        ICoreCommand Create(string intent);
    }
}
