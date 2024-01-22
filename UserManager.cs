using System;
using System.Collections.Generic;

namespace ShanOS
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserManager
    {
        private List<User> users;
        private User loggedInUser;

        public UserManager()
        {
            this.users = new List<User>();
            this.loggedInUser = null;
        }

        public void AddUser(string username, string password)
        {
            if (!UserExists(username))
            {
                users.Add(new User { Username = username, Password = password });
               
            }
            else
            {
                Console.WriteLine($"User '{username}' already exists.");
            }
        }

        public void Login(string username, string password)
        {
            User user = GetUser(username);

            if (user != null && user.Password == password)
            {
                loggedInUser = user;
                Console.WriteLine($"Welcome, {username}! You are now logged in.");
            }
            else
            {
                Console.WriteLine("Login failed. Invalid username or password.");
            }
        }

        public void Logout()
        {
            if (IsUserLoggedIn())
            {
                Console.WriteLine($"Goodbye, {loggedInUser.Username}! You are now logged out.");
                loggedInUser = null;
            }
            else
            {
                Console.WriteLine("No user is currently logged in.");
            }
        }

        public bool IsUserLoggedIn()
        {
            return loggedInUser != null;
        }

        public string GetCurrentUsername()
        {
            return loggedInUser?.Username;
        }

        public User GetUser(string username)
        {
            return users.Find(u => u.Username == username);
        }

        public bool UserExists(string username)
        {
            return users.Exists(u => u.Username == username);
        }
    }
}
