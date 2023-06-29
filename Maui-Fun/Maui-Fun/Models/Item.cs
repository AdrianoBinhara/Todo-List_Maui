using SQLite;
namespace Maui_Fun.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ScheduledDate { get; set; }




        public List<Item> SeedList(int dayOfMonth)
        {
            return new List<Item>()
            {
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = dayOfMonth,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Trein",
                     Description = "Jiu Jitsu",
                     ScheduledDate = dayOfMonth,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 18,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 18,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 22,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 19,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 19,
                     Time = DateTime.Now
                },new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 20,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 20,
                     Time = DateTime.Now
                },new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 22,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 23,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 23,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 23,
                     Time = DateTime.Now
                },
                 new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 24,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 24,
                     Time = DateTime.Now
                },
            };
        }
    }
}

