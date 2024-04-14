using SQLite;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;

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

        public Fine() { }

        public Fine(int fineid, int library_id, int amount)
        {
            FineId = fineid;
            LibraryID = library_id;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"FineId: {FineId}\t" +
                $"LibraryID: {LibraryID}\t" +
                $"Amount: {Amount}";
        }
    }
}
