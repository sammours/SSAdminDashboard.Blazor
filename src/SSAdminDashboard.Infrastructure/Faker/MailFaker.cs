namespace SSAdminDashboard.Infrastructure.Faker;

using Bogus;
using SSAdminDashboard.Domain.Mails;

public static class MailFaker
{
    public static List<Mail> Create(int count = 100)
    {
        Random random = new Random();

        var faker = new Faker<Mail>()
            .RuleFor(p => p.Date, f => f.Date.Past())
            .RuleFor(p => p.Sender, f => f.Person.FullName)
            .RuleFor(p => p.Subject, f => f.Lorem.Sentence())
            .RuleFor(p => p.Avatar, f => f.Person.Avatar)
            .RuleFor(p => p.IsRead, f => f.Random.Bool())
            .RuleFor(p => p.From, f => f.Person.Email)
            .RuleFor(p => p.Body, f => f.Lorem.Paragraph(min: 50))
            .RuleFor(p => p.Folder, f => f.Random.Enum<MailFolder>());

        return faker.Generate(count);
    }
}
