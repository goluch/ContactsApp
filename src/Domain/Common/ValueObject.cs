namespace Domain.Common
{
    // Learn more: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
    //public abstract class ValueObject
    //{
    //    protected static bool EqualOperator(ValueObject left, ValueObject right)
    //    {
    //        if (left is null ^ right is null)
    //        {
    //            return false;
    //        }

    //        return left?.Equals(right!) != false;
    //    }

    //    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    //    {
    //        return !(EqualOperator(left, right));
    //    }

    //    protected abstract IEnumerable<object> GetEqualityComponents();

    //    public override bool Equals(object? obj)
    //    {
    //        if (obj == null || obj.GetType() != GetType())
    //        {
    //            return false;
    //        }

    //        var other = (ValueObject)obj;
    //        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    //    }

    //    public override int GetHashCode()
    //    {
    //        var hash = new HashCode();

    //        foreach (var component in GetEqualityComponents())
    //        {
    //            hash.Add(component);
    //        }

    //        return hash.ToHashCode();
    //    }
    //}

    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var valueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
    }
}
