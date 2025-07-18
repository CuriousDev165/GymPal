using SQLite;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace GymPal.Models
{
    // Base class for all movement types. Only use this class to define shared movement properties.
    // Any public property defined here will be included as a table column in inherited classes that use SQLite.
    [Table("movement")]
    public record Movement
    {
        [Column("id"), PrimaryKey, Unique, AutoIncrement]
        public int Id { get; set; }
        [Column("name"), NotNull, MaxLength(40)]
        public string? Name { get; set; }
    }
}
