﻿using System;

namespace KiwiBankomaten
{
    public abstract class User
    {

        private string _userName;
        private string _password;
        private int _id;
        private bool _locked;

        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
            }
        }
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public bool Locked
        {
            get
            {
                return this._locked;
            }
            set
            {
                _locked = value;
            }
        }

    }
}
