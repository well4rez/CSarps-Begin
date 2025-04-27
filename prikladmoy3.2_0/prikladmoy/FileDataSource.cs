using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static prikladmoy.FileDataSource;

namespace prikladmoy
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

        // Метод для сохранения записи

        public MainRecord Save(MainRecord record)
        {
            // Если ID записи равен 0, это новая запись
            if (record.ID == 0)
            {
                // Генерация нового ID
                record.ID = records.Count + 1; // Увеличиваем ID на 1
                records.Add(record); // Добавляем запись в список
            }
            else
            {
                var existingRecord = Get(record.ID); // получаем существующую запись по айди
                if (existingRecord != null)
                {
                    records.Remove(existingRecord); // удаляем старую запись
                    records.Add(record); // добавляем обновленную запись
                }
            }
            return record; // возвращаем сохранённую запись
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
