using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Autenticacao
{
    [Table("User")]
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [StringLength(80)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Role { get; set; }
        [Required]
        public bool Ativo = true;
    }
}
