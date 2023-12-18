namespace MusicalSalon.Database.DbWorkers.Base {
    public interface IDbWorker<T> {

        List<T> GetAll();
        void Edit(T updatedEntity);
        void Delete(int id);
        void Add (T entity);
        T GetById (int id);

    }
}
