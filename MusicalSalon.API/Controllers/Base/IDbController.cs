namespace MusicalSalon.API.Controllers.Base {
    public interface IDbController<T> {
        IEnumerable<T> GetAll();
        void Delete(int id);
        void Add(T entity);
        void Edit(T updatedEntity);
        T GetById(int id);
    }
}
