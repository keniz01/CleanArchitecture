//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using CleanArchitecture.Domain.Entities;

//namespace CleanArchitecture.Persistence.Repositories
//{
//    public class GenericRepository
//    {
//        private readonly GeoCitiesContext _context;

//        public GenericRepository(GeoCitiesContext context)
//        {
//            _context = context ?? throw new ArgumentNullException(nameof(context));
//        }

//        public async Task<IList<Country>> GetAsync(Guid id)
//        {
//            //var continents = new Dictionary<Guid, List<Country>>
//            //{
//            //    {Guid.NewGuid(), new List<Country> {
//            //        new Country(Guid.NewGuid(), "Scotland", 110000, new Coordinate(34.748383, -12.828839),
//            //            new CapitalCity(Guid.NewGuid(), "Edinburgh", 264, new Coordinate(34.748383, -12.828839))),
//            //        new Country(Guid.NewGuid(), "Wales", 110000, new Coordinate(34.748383, -12.828839),
//            //            new CapitalCity(Guid.NewGuid(), "Cardiff", 264, new Coordinate(34.748383, -12.828839))),
//            //        new Country(Guid.NewGuid(), "Republic of Ireland", 110000, new Coordinate(34.748383, -12.828839),
//            //            new CapitalCity(Guid.NewGuid(), "Dublin", 264, new Coordinate(34.748383, -12.828839)))
//            //    }}
//            //};

//            //var countries = continents.ContainsKey(id) ? continents[id] : new List<Country>();
//            //return await Task.FromResult<IList<Country>>(countries);

//            //var countries = await Context.Jobs
//            //    .FromSql(new RawSqlString("SELECT * FROM [dbo].[EDMArchiveManagerDocumentDeletionJob] WHERE [Name] = @Name"), new SqlParameter("@Name", jobName))
//            //    .ToListAsync(cancellationToken);
//        }
//    }
//}