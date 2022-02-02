using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }


        [Required(ErrorMessage = "isim alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "İsim alanı 50 karakteden uzun olmamalı.")]
        public string Name { get; set; }


        [StringLength(50, ErrorMessage = "Soyisim alanı 50 karakteden uzun olmamalı.")]
        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        public string SurName { get; set; }


        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Eposta alanı 50 karakteden uzun olmamalı.")]
        [EmailAddress(ErrorMessage ="E-posta formatı hatalı.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Parola alanı zorunludur.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Rol alanı zorunludur.")]
        public string Role { get; set; }


        public bool Status { get; set; }
    }
}
