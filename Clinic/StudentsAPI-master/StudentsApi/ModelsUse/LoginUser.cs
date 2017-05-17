using StudentsApi.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsApi.ModelsUse
{
    public class LoginUser
    {
        private UserProviders _userProvider;

        public LoginUser()
        {
            _userProvider = new UserProviders();
        }

        [Required(ErrorMessage = " Username incorect!")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = " Password incorect!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        public int TypeId { get; set; }

        public bool IsValid(string _username, string _password)
        {

            if (_userProvider.IsValid(_username, _password))
            {
                var user = _userProvider.GetByUsername(_username);
                TypeId = user.TypeId;

                return true;
            }
            return false;
        }
    }
}
