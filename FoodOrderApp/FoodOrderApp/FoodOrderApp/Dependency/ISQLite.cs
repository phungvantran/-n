using SQLite;

namespace FoodOrderApp.Dependency
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
