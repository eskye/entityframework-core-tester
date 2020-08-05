using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCoreTester.DatabaseContext;
using ProgramModel = EntityFrameworkCoreTester.Model.Program;

namespace EntityFrameworkCoreTester.DataInitializer
{
    public interface IDatabaseSeeder
    {
        Task SeedProgram(List<ProgramModel> programs);
    }
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ApplicationDbContext _context;

        public DatabaseSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task SeedProgram(List<ProgramModel> programs)
        {
            if (!programs.Any()) return Task.CompletedTask;
             _context.Programs.AddRange(programs);
             var result = _context.SaveChanges(); 
             return result > 0 ? Task.CompletedTask : throw new Exception($"An error occurred");
        }

        public Task SeedApplicant(List<Model.Program> programs)
        {
            if (!programs.Any()) return Task.CompletedTask;
            _context.Programs.AddRange(programs);
            var result = _context.SaveChanges();
            return result > 0 ? Task.CompletedTask : throw new Exception($"An error occurred");
        }

    }


}
