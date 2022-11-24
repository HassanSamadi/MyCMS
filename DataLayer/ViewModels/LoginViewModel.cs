﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
