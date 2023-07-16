﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EG_2020_4069.Model
{
    public class User
    {
        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Image { get; set; }

        public string DateOfBirth { get; set; }

        public double GPA { get; set; }

        public String ImagePath
        {
            get { return $"/Model/Images/{Image}"; }
        }

        public User(int age, string firstName, string lastName, string dateOfBirth, string image, double gpa)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = image;
            GPA = gpa;
        }

        public User()
        {
        }
    }
}
