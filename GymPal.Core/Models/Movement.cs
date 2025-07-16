using SQLite;

namespace GymPal.Models
{
    // Base class for all movement types. Only use this class to define shared movement properties.
    // Any public property defined here will be included as a table column in inherited classes that use SQLite.
    public class Movement
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int Id { get; set; }
    }
}
