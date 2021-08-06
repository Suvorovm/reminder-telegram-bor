namespace Reminder.Core.Repository
{
    public interface IRepository<T>
    {
        T Get(string userId);
        void Save(string userId, T model);
        bool Delete(string userId);

        bool Has(string userId);
    }
}