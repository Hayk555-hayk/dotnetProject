using System.ComponentModel.DataAnnotations;

namespace dotnetProject.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email обязателен для заполнения")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email адреса")]
        [StringLength(100, ErrorMessage = "Email не должен превышать 100 символов")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Пароль обязателен для заполнения")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}