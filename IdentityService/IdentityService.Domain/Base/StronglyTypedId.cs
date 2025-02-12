namespace IdentityService.Domain.Base;

public class StronglyTypedId<Tkey>:ValueObject<StronglyTypedId<Tkey>>
{
    private Guid _id;

    public Guid Value
    {
        get { return _id; }
        private set
        {
            if (value == Guid.Empty)
                throw new BusinessRuleException("A valid id must be provided.");

            _id = value;
        }
    }

    protected StronglyTypedId(Guid value)
    {
        Value = value;
    }

    protected override bool EqualsCore(StronglyTypedId<Tkey> other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        unchecked
        {
            return Value.GetHashCode();
        }
    }
}