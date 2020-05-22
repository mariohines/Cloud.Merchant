using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cloud.Merchant.Domain.Base
{
    public abstract class Enumeration<T> : IComparable
        where T : struct, IComparable
    {
        public string Name { get; }
        public T Id { get; }

        protected Enumeration(T id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration<T> other))
            {
                return false;
            }

            var doesTypeMatch = GetType() == obj.GetType();
            var doesValueMatch = Id.Equals(other.Id);

            return doesTypeMatch && doesValueMatch;
        }

        protected bool Equals(Enumeration<T> other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(object obj) => Id.CompareTo(((Enumeration<T>) obj).Id);

        public static IEnumerable<TY> GetAll<TY>() where TY : Enumeration<T>
        {
            var fields = typeof(TY).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<TY>();
        }
    }
}