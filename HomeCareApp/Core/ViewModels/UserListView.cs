﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Data;

namespace HomeCareApp.Core.ViewModels
{
    public class UserListView
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public string Fullname { get { return string.Format("{0} {1}", FirstName, LastName); } }



    }
}
