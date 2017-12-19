using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string userName;
        private string firstName;
        private string lastName;
        private string passWord;
        private IList<IVehicle> vehicles;
        private int counter = 0;

        public string Username
        {
            get { return this.userName; }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Username must be between 2 and 20 characters long!");
                }

                if (!Regex.IsMatch(value, "^[A-Za-z0-9]+$"))
                {
                    throw new ArgumentException("Username contains invalid symbols!");
                }

                this.userName = value;
            }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Firstname must be between 2 and 20 characters long!");
                }

                if (!Regex.IsMatch(value, "^[A-Za-z0-9]+$"))
                {
                    throw new ArgumentException("Firstname contains invalid symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Lastname must be between 2 and 20 characters long!");
                }

                if (!Regex.IsMatch(value, "^[A-Za-z0-9]+$"))
                {
                    throw new ArgumentException("Lastname contains invalid symbols!");
                }

                this.lastName = value;
            }
        }

        public string Password
        {
            get { return this.passWord; }
            set
            {
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Password must be between 5 and 30 characters long!");
                }

                if (!Regex.IsMatch(value, "^[A-Za-z0-9@*_-]+$"))
                {
                    throw new ArgumentException("Lastname contains invalid symbols!");
                }
                this.passWord = value;
            }
        }


        public User(string userName, string firstName, string lastName, string passWord, string role)
        {
            this.Username = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = passWord;
            this.Role = (Role)Enum.Parse(typeof(Role), role);
            this.vehicles = new List<IVehicle>();
        }
        public Role Role { get; }

        public IList<IVehicle> Vehicles
        {
            get { return this.vehicles; }
            protected set { this.vehicles = value; }
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                Console.WriteLine("You are an admin and therefore cannot add vehicles!");
                return;
            }
            else if (this.Role == Role.Normal)
            {
                if (counter < 5)
                {
                    this.counter++;
                    this.vehicles.Add(vehicle);
                }
                if (counter == 5)
                {
                    Console.WriteLine("You are not VIP and cannot add more than 5 vehicles!");
                }
            }
            else if (this.Role == Role.Normal)
            {
                this.vehicles.Add(vehicle);
            }

        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.vehicles.Remove(vehicle);
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            //Guard.WhenArgument(commentToAdd, "CommentToAdd").IsNull().Throw();
            //Vehicles[Vehicles.IndexOf(vehicleToAddComment)].Comments.Add(commentToAdd);
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        //public string PrintVehicles()
        //{
        //    var sb = new StringBuilder();
        //    sb.AppendLine($"--USER {this.Username}--");
        //    if (Vehicles.Count == 0)
        //    {
        //        sb.AppendLine($"--NO VEHICLES--");
        //    }
        //    else
        //    {
        //        int counter = 0;
        //        foreach (var item in Vehicles)
        //        {
        //            counter++;
        //            sb.AppendLine($"{counter}. {item.Type}");
        //            sb.AppendLine(item.ToString());
        //        }
        //    }
        //    return sb.ToString();
        //}

        public string PrintVehicles()
        {
            var sb = new StringBuilder();

            var counter = 1;
            //builder.AppendLine(string.Format(UserHeader, this.Username));
            sb.AppendLine($"--USER {this.Username}--");

            if (this.Vehicles.Count <= 0)
            {
                sb.AppendLine($"--NO VEHICLES--");
                // sb.AppendLine(NoVehiclesHeader);
            }
            else
            {
                foreach (var vehicle in this.Vehicles)
                {
                    sb.AppendLine(string.Format("{0}. {1}", counter, vehicle.ToString()));
                    counter++;
                }
            }

            return sb.ToString().Trim();
        }
    }
}
