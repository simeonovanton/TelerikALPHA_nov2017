using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public User(string userName, string firstName, string lastName, string passWord)
        {
            this.Username = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = passWord;
        }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Password { get; }

        public User(string userName, string firstName, string lastName, string passWord, string role)
            :this(userName, firstName, lastName, passWord)
        {
            this.Role = (Role) Enum.Parse(typeof(Role), role);
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

        public string PrintVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
