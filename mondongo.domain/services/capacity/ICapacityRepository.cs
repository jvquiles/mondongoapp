namespace mondongo.domain.services.capacity
{
    public interface ICapacityRepository
    {
        void Increase();
        void Decrease();
        int GetCurrent();
    }
}