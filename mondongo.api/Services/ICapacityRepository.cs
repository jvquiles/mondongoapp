namespace mondongo.api.Services
{
    public interface ICapacityRepository
    {
        void Increase();
        void Decrease();
        int GetCurrent();
    }
}