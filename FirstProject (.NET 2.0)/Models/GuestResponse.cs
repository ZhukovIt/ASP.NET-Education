using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Пожалуйста, введите Ваше имя!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Ваш e-mail!")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Пожалуйста, введите корректный e-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Ваш номер телефона!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите, примете ли Вы участие в вечеринке!")]
        public bool? WillAttend { get; set; }
    }
}
