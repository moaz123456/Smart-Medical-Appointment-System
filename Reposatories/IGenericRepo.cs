namespace Smart_Medical_Appointment_System.Reposatories
{
    public interface IGenericRepo<T>
    {
        List<T> GetAll();
        T GetById(int id);

        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
        void Save();
    }
}
