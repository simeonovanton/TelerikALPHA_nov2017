namespace Dealership.Contracts
{
    public interface IComment
    {
        string Content { get; }

        string Username { get; set; }
    }
}
