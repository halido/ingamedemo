using System.ComponentModel.DataAnnotations;

namespace InGame.BestPractice.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}