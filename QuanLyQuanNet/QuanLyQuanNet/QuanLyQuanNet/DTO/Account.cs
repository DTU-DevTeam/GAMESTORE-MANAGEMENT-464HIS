﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DTO
{
    public class Account
    {
        public Account(string userName, string displayName, int type, string password = null) 
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.PassWord = password;
        }
        public Account(DataRow row) 
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayTen"].ToString();
            this.Type = (int)row["Type"];
            this.PassWord = row["PassWord"].ToString();
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        private int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        private string passWord;
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
     
    }
}
