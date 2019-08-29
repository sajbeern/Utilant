﻿using System.Collections.Generic;
using UtilantDemo.Models;

namespace UtilantDemo.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
        public IEnumerable<PostModel> Post { get; set; }

        public UserViewModel()
        {
            Post = new List<PostModel>();
        }
    }
    
}