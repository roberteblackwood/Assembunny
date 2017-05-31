using NUnit.Framework;
using TestDrivenDevelopmentTarget;

namespace TestDrivenDevelopment
{
    public class Assembunny_should_
    {
        [Test]
        public void increases_the_value_of_a_register_by_one()
        {
            // arrange
            var register = Any.Register();
            var initialValue = register.Value;
            var sut = new Assembunny(new [] {register});

            // act
            sut.Execute($"inc {register.Name}");

            // assert
            Assert.AreEqual(initialValue + 1, register.Value);
        }

        [Test]
        public void decreases_the_value_of_a_register_by_one()
        {
            // arrange
            var register = Any.Register();
            var initialValue = register.Value;
            var sut = new Assembunny(new[] {register});
            
            // act 
            sut.Execute($"dec {register.Name}");

            // assert
            Assert.AreEqual(initialValue - 1, register.Value);
        }

        [Test]
        public void copies_the_value_of_a_defined_register_to_target_register()
        {
            // arrange
            var existingRegister = Any.Register();
            var targetRegister = Any.Register(existingRegister.Value - 1);
            var sut = new Assembunny(new[] { existingRegister, targetRegister });

            // act
            sut.Execute($"cpy {existingRegister.Name} {targetRegister.Name}");

            // assert
            Assert.AreEqual(existingRegister.Value, targetRegister.Value);
        }

        [Test]
        public void copies_a_value_to_target_register()
        {
            // arrange
            var targetRegister = Any.Register();
            var initialValue = targetRegister.Value;
            var newValue = initialValue - 1;
            var sut = new Assembunny(new [] {targetRegister});

            // act
            sut.Execute($"cpy {newValue} {targetRegister.Name}");

            // assert
            Assert.AreEqual(newValue, targetRegister.Value);
        }
    }
}
