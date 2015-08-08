using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Portfolio.PhotoService
{
    public static class IDataReaderExtensions
    {
        public static T GetValue<T>(this IDataReader sdr, string columnName, T defaultValue = default(T))
        {
            object dbValue = sdr[columnName];
            return dbValue == null || dbValue == DBNull.Value ? defaultValue : (T)dbValue;
        }

        public static byte[] GetByteArray(this SqlDataReader sdr, string columnName)
        {
            var length = sdr.GetBytes(sdr.GetOrdinal(columnName), 0, null, 0, 1);
            byte[] result = new byte[length];
            sdr.GetBytes(sdr.GetOrdinal(columnName), 0, result, 0, result.Length);
            return result;
        }
    }
}
