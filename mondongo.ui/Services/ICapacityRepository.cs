namespace mondongo.ui.Services
{
    public interface ICapacityRepository
    {
        void Increase();
        void Decrease();
        int GetCurrent();
    }
}