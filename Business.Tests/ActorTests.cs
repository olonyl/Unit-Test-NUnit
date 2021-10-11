using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    [Category("slow")]
    public class ActorTests
    {
        private Character _character;

        [SetUp]
        public void Setup()
        {
            _character = new Character(Type.Elf);
        }

        [TearDown]
        public void Teardown()
        {
            _character.Dispose();
            _character = null;
        }

        [Test]
        [Ignore("this is the reason")]
        public void IsDead_KillCharacter_ReturnsTrue()
        {
            _character.Damage(500);
            Assert.That(_character.IsDead, Is.True);
        }

        [Test]
        [Category("slow")]
        public void IsDead_DefaultCharacter_ReturnsFalse()
        {
            Assert.That(_character.IsDead, Is.False);
        }

        /*[Test]
        public void Health_Damage100OnElf_Returns45()
        {
            _character.Damage(100);
            Assert.That(_character.Health, Is.EqualTo(45));
        }

        [Test]
        public void Health_Damage80OnElf_Returns65()
        {
            _character.Damage(80);
            Assert.That(_character.Health, Is.EqualTo(65));
        }*/

        //[TestCase(100,45)]
        //[TestCase(80,65)]
        [TestCaseSource(typeof(DamageSource))]
        [Category("slow")]
        public void Health_Damage_ReturnsCorrectValue(int damage, int expectedHealth)
        {
            _character.Damage(damage);
            Assert.That(_character.Health, Is.EqualTo(expectedHealth));
        }

        public class DamageSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new int[] { 100, 45 };
                yield return new int[] { 80, 65 };
            }
        }
    }
}
