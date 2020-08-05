using System;
using Bogus;

namespace EntityFrameworkCoreTester.Helpers
{
    public static class FakeDataGenerator
    {
        public static Model.Program ProgramFaker(int rows)
        {
            var programFaker = new Faker<Model.Program>()
                .RuleFor(p => p.Description, p => p.Lorem.Paragraph())
                .RuleFor(p => p.Name, p => p.Name.JobTitle())
                .RuleFor(p => p.CreatorUserKey, p => Guid.NewGuid());
            return programFaker.UseSeed(rows).Generate();

        }
    }
}
