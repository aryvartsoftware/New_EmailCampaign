using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DataAccessLayer
{
    public class ListToDataSet
    {
        public static DataTable newTableColumnAlone<T>(IEnumerable<T> list)
        {
            PropertyInfo[] pi = typeof(T).GetProperties();
            DataTable table = Table<T>(list, pi);
            IEnumerator<T> e = list.GetEnumerator();

            return table;
        }

        /// <summary>
        /// Method for getting and populating the DataTable that
        /// will be in the converted DataSet
        /// </summary>
        /// <typeparam name="T">List type that is being converted</typeparam>
        /// <param name="list">The list being converted</param>
        /// <returns>A populated DataTable</returns>
        public static DataTable newTable<T>(IEnumerable<T> list)
        {
            PropertyInfo[] pi = typeof(T).GetProperties();

            DataTable table = Table<T>(list, pi);

            IEnumerator<T> e = list.GetEnumerator();

            while (e.MoveNext())
                table.Rows.Add(newRow<T>(table.NewRow(), e.Current, pi));

            return table;
        }

        /// <summary>
        /// Method resposible for the generation of the DataTable
        /// </summary>
        /// <typeparam name="T">Type of the List being converted</typeparam>
        /// <param name="list">List being converted</param>
        /// <param name="pi">Properties for the list</param>
        /// <returns></returns>
        public static DataTable Table<T>(IEnumerable<T> list, PropertyInfo[] pi)
        {

            DataTable table = new DataTable();
            try
            {
                foreach (PropertyInfo p in pi)
                {
                    bool canBeNull = !p.PropertyType.IsValueType || (Nullable.GetUnderlyingType(p.PropertyType) != null);

                    //        if (p.PropertyType.IsGenericType &&
                    //p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    //        {
                    //            p.PropertyType = p.PropertyType.GetGenericArguments()[0];
                    //        }
                    table.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return table;
        }
        /// <summary>
        /// Method for getting the data from the list then create a new
        /// DataRow with the property values in the PropertyInfo being
        /// provided, then return the row to be added to the Dataable
        /// </summary>
        /// <typeparam name="T">Type of the Generic list being converted</typeparam>
        /// <param name="row">DatRow to populate and add</param>
        /// <param name="listItem">The current item in the list</param>
        /// <param name="pi">Properties for the current item in the list</param>
        /// <returns>A populated DataRow</returns>
        public static DataRow newRow<T>(DataRow row, T listItem, PropertyInfo[] pi)
        {
            foreach (PropertyInfo p in pi)
                row[p.Name.ToString()] = p.GetValue(listItem, null) ?? DBNull.Value;

            return row;
        }

        public void add()
        { string gg = ""; }
    }
}
