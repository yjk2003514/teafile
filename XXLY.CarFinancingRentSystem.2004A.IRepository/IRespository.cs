namespace XXLY.CarFinancingRentSystem._2004A.Repository
{
    public interface IRespository<T> where T : class, new()
    {
        int Add(T Model);
        int Del(int id);
        IEnumerable<T> Find(int Id);
        IEnumerable<T> Show();
        int Upt(T Model);
    }
}