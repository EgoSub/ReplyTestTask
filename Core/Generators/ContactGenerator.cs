using Bogus;
using Core.Models;

namespace Core.Generators
{
    public class ContactGenerator : Faker<Contact>
    {
        public ContactGenerator()
        {
            RuleFor(o => o.FirstName, f => f.Name.FirstName());
            RuleFor(o => o.LastName, f => f.Name.LastName());
            RuleFor(o => o.BusinessRole, f => f.PickRandom<BusinessRole>());
        }

        public static Contact Instance => new Faker<Contact>().Generate();
    }
}
