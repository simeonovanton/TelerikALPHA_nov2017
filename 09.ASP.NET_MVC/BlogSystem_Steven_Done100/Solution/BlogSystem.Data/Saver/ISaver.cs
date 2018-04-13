namespace BlogSystem.Data.Saver
{
    public interface ISaver
    {
        void SaveChanges();

        void SaveChangesAsync();
    }
}