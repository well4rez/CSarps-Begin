using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrikladMoy3.FileDataSource;

namespace PrikladMoy3
{
    public abstract class MainRecord
    {
        public int ID { get; set; } // Должен генерироваться автоматически после записи в хранилище. 0 обозначает новую, еще не сохраненную запись
        public string Account { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Description { get; set; }
    }
    internal class FileDataSource
    {
        public interface IDataSource
        {
            MainRecord Save(MainRecord record);
            MainRecord Get(int id);
            bool Delete(int id);
            List<MainRecord> GetAll();
        }
    }

    public class EmployeeRecord : MainRecord
    {
    }

    public class MemoryDataSource : IDataSource
    {
        private List<MainRecord> records = new List<MainRecord>();
        private int nextId = 1;

        public MainRecord Save(MainRecord record)
        {
            if (record.ID == 0)
            {
                record.ID = nextId;
                nextId++; 
                records.Add(record);
            }

            else
            {
                var existingRecord = Get(record.ID);
                if (existingRecord != null)
                {
                    records.Remove(existingRecord);
                    records.Add(record);
                }
            }
            return record;
        }

        public MainRecord Get(int id)
        {
            return records.Find(r => r.ID == id);
        }

        public bool Delete(int id)
        {
            var record = Get(id);
            if (record != null)
            {
                records.Remove(record);
                return true;
            }
            return false;
        }

        public List<MainRecord> GetAll()
        {
            return new List<MainRecord>(records);
        }
    }

}
