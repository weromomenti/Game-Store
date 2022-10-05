using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store_Tests
{
    internal class GameEqualityComparer : IEqualityComparer<Game>
    {
        public bool Equals(Game? x, Game? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Price == y.Price;
        }

        public int GetHashCode([DisallowNull] Game obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class PEGIRatingComparer : IEqualityComparer<PEGIRating>
    {
        public bool Equals(PEGIRating? x, PEGIRating? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.RatingName == y.RatingName;
        }

        public int GetHashCode([DisallowNull] PEGIRating obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class GenreComparer : IEqualityComparer<Genre>
    {
        public bool Equals(Genre? x, Genre? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.GenreName == y.GenreName;
        }

        public int GetHashCode([DisallowNull] Genre obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class CommentComparer : IEqualityComparer<Comment>
    {
        public bool Equals(Comment? x, Comment? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Text == y.Text;
        }

        public int GetHashCode([DisallowNull] Comment obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User? x, User? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.UserName == y.UserName;
        }

        public int GetHashCode([DisallowNull] User obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.FirstName == y.FirstName
                && x.LastName == y.LastName
                && x.BirthDate == y.BirthDate;
        }
        public int GetHashCode([DisallowNull] Person obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class RoleComparer : IEqualityComparer<Role>
    {
        public bool Equals(Role? x, Role? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.RoleName == y.RoleName;
        }

        public int GetHashCode([DisallowNull] Role obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class OrderComparer : IEqualityComparer<Order>
    {
        public bool Equals(Order? x, Order? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.UserId == y.UserId
                && x.OrderDate == y.OrderDate;
        }

        public int GetHashCode([DisallowNull] Order obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class OrderDetailsComparer : IEqualityComparer<OrderDetails>
    {
        public bool Equals(OrderDetails? x, OrderDetails? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.Quantity == y.Quantity
                && x.UnitPrice == y.UnitPrice
                && x.OrderId == y.OrderId
                && x.GameId == y.OrderId;
        }

        public int GetHashCode([DisallowNull] OrderDetails obj)
        {
            return obj.GetHashCode();
        }
    }
}
