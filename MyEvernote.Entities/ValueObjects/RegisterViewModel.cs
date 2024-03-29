﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Entities.ValueObjects
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(25, ErrorMessage = "{0} Maksimum {1} karakter olmalıdır.")]

        public string Username { get; set; }
        [DisplayName("E-posta "), Required(ErrorMessage = "{0} alanı boş geçilemez."), EmailAddress(ErrorMessage = "Geçerli bir E-posta giriniz..."), StringLength(70, ErrorMessage = "{0} maksimum {1} karakter olmalıdır...")]

        public string EMail { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} maksimum {1} karakter olmalıdır...")]

        public string Password { get; set; }
        [DisplayName("Şifre Tekrarı"), Required(ErrorMessage = "{0} alanı boş geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} maksimum {1} karakter olmalıdır..."),Compare("Password", ErrorMessage = "{0} ile {1} uyuşmuyor.")]
        //compare burada password ile repassword ün aynı olup olmadığını kontrol eder kullanışlı birşeydir.
        public string RePassword { get; set; }

    }
}