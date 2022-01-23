using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamsManage.Models
{
    public class LinkModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string titulo { get; set;}

        [ForeignKey("User")]
        public int idUser { get; set; }
    }
}
