using Maui_Fun.Models;
using SQLite;

namespace Maui_Fun.Context
{
    public class ItemRepository
    {
        private readonly SQLiteConnection _database;

        public ItemRepository()
        {
            var nameTable = $"{nameof(Item).ToLower()}.db";
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nameTable);
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Item>();
        }


        public List<Item> GetItems()
        {
            return _database.Table<Item>().ToList();
        }

        public List<Item> GetVisibleItems(int dayOfMonth)
        {
            return _database.Table<Item>().Where(t => t.ScheduledDate == dayOfMonth).ToList();
        }

        public Item GetItem(int id)
        {
            return _database.Table<Item>().Where(i => i.Id == id).FirstOrDefault();
        }

        public int SaveItem(Item item)
        {
            if (item.Id != 0)
                return _database.Update(item);
            else
                return _database.Insert(item);
        }

        public int DeleteItem(Item item)
        {
            return _database.Delete(item);
        }


        public int AddRangeItems(List<Item> items)
        {
            if (DatabateExists())
                return 0;

            return _database.InsertAll(items);
        }


        private bool DatabateExists()
        {
            return _database is not null;
        }
    }
}
