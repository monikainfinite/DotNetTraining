using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidprinciples
{
    public interface IDatabase
    {
        void Save();
    }
    public class SqlDatabase : IDatabase
    {
        public void Save()
        {
            Console.WriteLine("Saving data to SQL");
        }
    }
    public class OrderProcessor
    {
        private IDatabase database;

        public OrderProcessor(IDatabase data)
        {
            database = data;
        }

        public void Process()
        {
            database.Save();
        }
    }
    public class OracleDatabase : IDatabase
    {
        public void Save()
        {
            Console.WriteLine("Saving to Oracle");
        }
    }
    internal class DIP
    {
        public static void Main(string[] args)
        {
            IDatabase db = new SqlDatabase();
            OrderProcessor order = new OrderProcessor(db);

            order.Process();
            OrderProcessor order1 = new OrderProcessor(new OracleDatabase());
            order1.Process();
        }
    }
}
