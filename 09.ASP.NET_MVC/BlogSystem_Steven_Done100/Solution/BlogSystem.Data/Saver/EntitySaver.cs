namespace BlogSystem.Data.Saver
{
    public class EntitySaver : ISaver
    {
        private readonly BlogSystemDbContext context;

        public EntitySaver(BlogSystemDbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
