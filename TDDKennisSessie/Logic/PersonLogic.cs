using System.Collections.Generic;
using System.Linq;
using TDDKennisSessie.Models;
using TDDKennisSessieDataLayer.Backend.Interfaces;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Logic
{
    public class PersonLogic
    {
        private readonly IPersonBackend _personBackend;

        public PersonLogic(IPersonBackend memoryPersonBackend)
        {
            _personBackend = memoryPersonBackend;
        }

        //Assignment 5
        //Make sure that the method below doesn't show a list with firstname, insertionname and lastname
        //instead it should show a list of formatted names as we created in assignment 4.
        public List<PersonModel> GetAllPersons()
        {
            return _personBackend.GetAllPersons()
                .Select(person =>
                    new PersonModel
                    {
                        Id = person.Id,
                        FirstName = person.FirstName,
                        InsertionName = person.InsertionName,
                        LastName = person.LastName
                    }).ToList();
        }

        public PersonModel GetPersonById(int id)
        {
            var person = _personBackend.GetPersonById(id);
            return new PersonModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                InsertionName = person.InsertionName,
                LastName = person.LastName
            };
        }

        public void CreatePerson(PersonModel person)
        {
            _personBackend.CreatePerson(new Person
            {
                FirstName = person.FirstName,
                InsertionName = person.InsertionName,
                LastName = person.LastName
            });
        }

        public void UpdatePerson(PersonModel personModel)
        {
            _personBackend.UpdatePerson(new Person
            {
                Id = personModel.Id,
                FirstName = personModel.FirstName,
                InsertionName = personModel.InsertionName,
                LastName = personModel.LastName
            });
        }

        public void DeletePerson(int id)
        {
            _personBackend.DeletePerson(id);
        }
    }
}