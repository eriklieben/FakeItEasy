namespace FakeItEasy.Tests
{
    using System.Collections.Generic;
    using FakeItEasy.Core;
    using FakeItEasy.Expressions;
    using NUnit.Framework;

    public abstract class ArgumentConstraintTestBase
    {
        protected IArgumentConstraint constraint;
        protected abstract IEnumerable<object> InvalidValues { get; }
        protected abstract IEnumerable<object> ValidValues { get; }
        protected abstract string ExpectedDescription { get; }

        [Test]
        [TestCaseSource("InvalidValues")]
        public void IsValid_should_return_false_for_invalid_values(object invalidValue)
        {
            Assert.That(this.constraint.IsValid(invalidValue), Is.False);
        }

        [Test]
        [TestCaseSource("ValidValues")]
        public void IsValid_should_return_true_for_valid_values(object validValue)
        {
            var result = this.constraint.IsValid(validValue);
            
            Assert.That(result, Is.True);
        }

        [Test]
        public virtual void Constraint_should_provide_correct_description()
        {
            Assert.That(this.constraint.ToString(), Is.EqualTo("<" + this.ExpectedDescription + ">"));
        }
    }

    public abstract class ArgumentConstraintTestBase<T>
        : ArgumentConstraintTestBase
    {
        protected new ArgumentConstraint<T> Constraint
        {
            get
            {
                return (ArgumentConstraint<T>)base.constraint;
            }
            set
            {
                base.constraint = value;
            }
        }

        [Test]
        public void FullDescription_should_provide_expected_description()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(this.Constraint.FullDescription, Is.EqualTo(this.ExpectedDescription));
        }

    }

}
