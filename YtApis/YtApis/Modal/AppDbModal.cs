using System.ComponentModel.DataAnnotations;

namespace YtApis.Modal
{
    public class AppDbModal
    {
        public class Users{
            [Key]
            public int ID { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }   
            public string? Mobile { get; set; }

            }
    }
}
