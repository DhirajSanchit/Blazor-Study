namespace InterfaceLayer.DALs
{
    public interface IDataAccess
    {
        int ExecuteCommand<T>(string sql, T parameters);
        List<T> Query<T, U>(string sql, U parameters);
        T QueryFirstOrDefault<T, U>(string sql, U parameters);
    }
}