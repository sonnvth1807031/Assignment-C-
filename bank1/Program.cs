using System;
using bank1.controller;
using bank1.entity;

namespace bank1
{
    class Program
    {
        public static accBank AccBank { get; set; }
        public static History History { get; set; }
        public static string Ccc = "";

        private static void Main(string[] args)
        {
           var menu = new Menu();
           menu.CreateMenu();
        }
    }
}