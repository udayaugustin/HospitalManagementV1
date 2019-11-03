using SQLite;

namespace BookingManager
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

