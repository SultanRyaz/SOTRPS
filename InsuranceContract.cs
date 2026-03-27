using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class InsuranceContract
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Идентификатор стращика обязателен")]
        public string InsurerIndentity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Идентификатор страхователя обязателен")]
        public string InsurantIdentity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Идентификатор объекта обязателен")]
        public string ObjectIdentity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Страховая сумма обязательна")]
        [Range(0.01, 100000000, ErrorMessage = "Страховая сумма должна быть от 0.01 до 100 000 000")]
        public decimal InsuredAmount { get; set; }

        [Required(ErrorMessage = "Дата обязательна")]
        public DateOnly Date { get; set; }
    }
}