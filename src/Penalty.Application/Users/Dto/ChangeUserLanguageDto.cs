using System.ComponentModel.DataAnnotations;

namespace Penalty.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}