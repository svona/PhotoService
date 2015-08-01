using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.PhotoService
{
    public static class IDataReaderExtensions
    {
        public static T GetValue<T>(this IDataReader sdr, string columnName, T defaultValue = default(T))
        {
            object dbValue = sdr[columnName];
            return dbValue == null || dbValue == DBNull.Value ? defaultValue : (T)dbValue;
        }
    }
}
