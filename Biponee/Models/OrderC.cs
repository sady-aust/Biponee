using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class OrderC
    {
        public int OrderId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public int UserId { get; set; }
        public String PaymentMethod { get; set; }
        public Double Total { get; set; }

       /* public OrderC(int orderId, string firstName, string lastName, string phone, string address, string state, string city, int userId, string paymentMethod, double total)
        {
            OrderId = orderId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Address = address;
            State = state;
            City = city;
            UserId = userId;
            PaymentMethod = paymentMethod;
            Total = total;
        }

        public OrderC(string firstName, string lastName, string phone, string address, string state, string city, int userId, string paymentMethod, double total)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Address = address;
            State = state;
            City = city;
            UserId = userId;
            PaymentMethod = paymentMethod;
            Total = total;
        }*/
    }
}