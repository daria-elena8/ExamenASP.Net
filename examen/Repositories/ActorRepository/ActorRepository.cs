using examen.Repositories.GenericRepository;
using examen.Data;
using examen.Models;
using Microsoft.EntityFrameworkCore;


namespace examen.Repositories.ActorRepository
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(examenContext examenContext) : base(examenContext) { }

        public List<Actor> OrderByAge(int age)
        {
            var ActorsOrderedAsc1 = _table.OrderBy(x => x.Age);
            var ActorsOrderedDesc1 = _table.OrderByDescending(x => x.Age);
            var ActorsOrderedByMultiple = _table.OrderByDescending(x => x.Age).ThenBy(x => x.Id);
            var ActorsOrderedByMultiple2 = _table.OrderByDescending(x => x.Age).ThenByDescending(x => x.Id);

            // linq query syntax
            var ActorsOrderedAsc2 = from s in _table
                                      orderby s.Age
                                      select s;

            var ActorsOrderedDesc2 = from s in _table
                                       orderby s.Age descending
                                       select s;

            return ActorsOrderedAsc1.ToList();
        }

        public List<Actor> GetAllWithInclude()
        {

            var result = _table.Include(s => s.Models1).ThenInclude(m2 => m2.Models2).ToList();
            return _table.Include(s => s.Models1).ToList();

            // Model1 model1-a
            // Model2 model2-a
            // {...model1-a, {... model2 a}}
        }

        public List<dynamic> GetAllWithJoin()
        {
            var result = _examenContext.Models1.Join(_examenContext.Models2, model1 => model1.Id, model2 => model2.Model1Id,
                (model1, model2) => new { model1, model2 }).Select(ob => ob.model1);


            // model1, model
            // {...model1-a, model2-a}, {...model1-b, ...model2-b}

            return null;
        }

        public Actor Where(int age)
        {
            var result1 = _table.Where(x => x.Age < age).FirstOrDefault();
            var result2 = _table.FirstOrDefault(x => x.Age < age);

            var result3 = from s in _table
                          where s.Age < age
                          select s;

            return result1!;
        }

        public void GroupBy()
        {
            var groupedActors = _table.GroupBy(x => x.Id);

            var groupedActors2 = from s in _table
                                   group s by s.Age;

            foreach (var ActorGroupedByAge in groupedActors2)
            {
                Console.WriteLine("Actor group age: " + ActorGroupedByAge.Key);

                foreach (var s in ActorGroupedByAge)
                {
                    Console.WriteLine("Actor name: " + s.FirstName + " " + s.LastName);
                }
            }
        }
    }
}
