﻿namespace UsersDataAcccesLayer
{
    /// <summary>
    /// The User
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public string email { get; set; }
    }
}
