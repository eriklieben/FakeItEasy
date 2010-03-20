namespace FakeItEasy.Expressions
{
    internal class RootValidations<T>
        : ArgumentConstraintScope<T>
    {
        internal override bool IsValid(T argument)
        {
            return true;
        }

        internal override bool ResultOfChildConstraintIsValid(bool result)
        {
            return result;
        }
    }
}
