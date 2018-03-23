using System.Data.Entity;

namespace SocialNetwork.Data.Configurations.Contracts
{
    public interface IFluentConfiguration
    {
        void Register(DbModelBuilder modelBuilder);
    }
}