using Epilepsy_Health_App.Services.Identity.Core.Exceptions;
using System;

namespace Epilepsy_Health_App.Services.Identity.Core.Entities
{
    public class AggregateId : IEquatable<AggregateId>
    {
        public Guid Value { get; }

        public AggregateId()
        {
            Value = Guid.NewGuid();
        }

        public AggregateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidAggregateIdException();
            }

            Value = value;
        }

        public bool Equals(AggregateId other) => !(other is null) && (ReferenceEquals(this, other) || Value.Equals(other.Value));

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AggregateId)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator Guid(AggregateId id)
            => id.Value;

        public static implicit operator AggregateId(Guid id)
            => new AggregateId(id);

        public override string ToString() => Value.ToString();
    }
}
