using System.Collections.Generic;

namespace InterfaceLayer.DALs
{
    public interface IDataAccess
    {
        void ExecuteCommand<T>(string sql, T parameters);
        List<T> Query<T, U>(string sql, U parameters);
        T QuerySingle<T, U>(string sql, U parameters);
    }
}