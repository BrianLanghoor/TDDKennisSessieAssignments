using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.Logic;
using TDDKennisSessieDataLayer.DBModels;
using FluentAssertions;
using TDDKennisSessieDataLayer.Backend.Memory;

namespace TDDKennisSessie.Tests.UnitTests.PersonTests
{
    [TestClass]
    public class GetAllPersonsTests
    {
        private PersonMemoryBackend _memoryBackend;
        private PersonLogic _personLogic;

        [TestInitialize]
        public void Initialize()
        {
            _memoryBackend = new PersonMemoryBackend();
            _personLogic = new PersonLogic(_memoryBackend);
        }

        [TestMethod]
        public void WhenThereAreNoPersonsGetAllPersonShouldNotReturnAnyPersons()
        {
            _personLogic.GetAllPersons().Count.Should().Be(0);
        }

        [TestMethod]
        public void WhenThereIsAPersonsGetAllPersonsShouldReturnOnePerson()
        {
            _memoryBackend.InternalPersons.Add(new Person { Id = 1, FirstName = "firstName", InsertionName = "InsertionName", LastName = "lastName" });
            _personLogic.GetAllPersons().Count.Should().Be(1);
        }

        [TestMethod]
        public void WhenThereIsAPersonsTheReturnedPersonShouldHaveTheCorrespondingFirstName()
        {
            _memoryBackend.InternalPersons.Add(new Person { FirstName = "Brian", InsertionName = "", LastName = "Langhoor"});
            _personLogic.GetAllPersons().First().FirstName.Should().Be("Brian");
        }

        [TestMethod]
        public void WhenThereIsAPersonsTheReturnedPersonShouldHaveTheCorrespondingLastName()
        {
            _memoryBackend.InternalPersons.Add(new Person { FirstName = "Brian", InsertionName = "", LastName = "Langhoor" });
            _personLogic.GetAllPersons().First().LastName.Should().Be("Langhoor");
        }

        [TestMethod]
        public void WhenThereIsAPersonsTheReturnedPersonShouldHaveTheCorrespondingInsertionName()
        {
            _memoryBackend.InternalPersons.Add(new Person { FirstName = "Brian", InsertionName = "", LastName = "Langhoor" });
            _personLogic.GetAllPersons().First().InsertionName.Should().Be("");
        }

        [TestMethod]
        public void WhenThereIsAPersonsTheReturnedPersonShouldHaveTheCorrespondingId()
        {
            _memoryBackend.InternalPersons.Add(new Person { Id = 1, FirstName = "firstName", InsertionName = "InsertionName", LastName = "lastName"});
            _personLogic.GetAllPersons().First().Id.Should().Be(1);
        }
    }
}
