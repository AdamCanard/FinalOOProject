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
        public int fine_id { get; set; }

        [Required]
        public int library_id { get; set; }

        [Required]
        public int amount { get; set; }

        public Fine() { }

        public Fine(int fineid, int library_id, int amount)
        {
            fine_id = fineid;
            this.library_id = library_id;
            this.amount = amount;
        }

        public override string ToString()
        {
            return $"FineId: {fine_id}\t" +
                $"LibraryID: {library_id}\t" +
                $"Amount: {amount}";
        }
    }
}
