using SQLite;
using System.ComponentModel.DataAnnotations;

namespace OOProject.Models
{
    public class Fine
    {
        [Required]
        [PrimaryKey, AutoIncrement]
        public int FineId { get; set; }

        [Required]
        public int LibraryID { get; set; }

        [Required]
        public int Amount { get; set; }


        public override string ToString()
        {
            return $"FineId: {FineId}\t" +
                $"LibraryID: {LibraryID}\t" +
                $"Amount: {Amount}";
        }
    }
}
