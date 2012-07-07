using System;
using System.Collections.Generic;
using FollowMyTv.DomainLayer;

namespace FollowMyTv.DataAccessLayer
{
    public class ShowMemoryRepository : BaseMemoryRepository<Show, string>
    {
        private static IDictionary<string, Show> Repo = new Dictionary<string, Show>();

        static ShowMemoryRepository()
        {
            Show show = new Show
            {
                Name = "Breaking Bad"
            ,
                Description = "Informed he has terminal cancer, an underachieving chemistry genius " +
                                "turned high school chemistry teacher turns to using his expertise in " +
                                "chemistry to provide a legacy for his family..." +
                                " by producing the world's highest quality crystal meth."
            };
            Season season = new Season
                                {
                                    Number = 1
                                 ,
                                    Name = "1"
                                 ,
                                    Debut = new DateTime( 2008, 1, 28 )
                                 ,
                                    Finale = new DateTime( 2008, 3, 10 )
                                };
            Episode episode = new Episode
                                  {
                                      Number = 1
                                      ,
                                      Title = "Pilot"
                                      ,
                                      Duration = 40
                                      ,
                                      Synopsis =
                                         "Walter White, a 50-year old chemistry teacher, secretly begins making crystal methamphetamine"
                                          + " to support his family when he finds out that he has terminal lung cancer. He teams up with a former student,"
                                          + " Jesse Pinkman, who is a meth dealer. Jesse is trying to sell the meth but the dealers snatch him and make him"
                                          + " show them the lab. Walter knows they intend to kill him so he poisons them while showing them his recipe."
                                      ,
                                      Score = 4
                                  };

            Show show2 = new Show { Name = "Lost", Description = "Lost" };
            Show show3 = new Show { Name = "Spartacus", Description = "Spartacus" };
            Show show4 = new Show { Name = "PDM", Description = "PDM" };
            Show show5 = new Show { Name = "Titus", Description = "Titus" };
            Show show6 = new Show { Name = "Buffy", Description = "Buffy" };
            Show show7 = new Show { Name = "Beavis & ButtHead", Description = "Beavis & ButtHead" };
            Show show8 = new Show { Name = "Jackass", Description = "Jackass" };

            season.Episodes.Add( episode );
            show.Seasons.Add( season );
            Repo.Add( show.Name, show );

            Repo.Add( show2.Name, show2 );
            Repo.Add( show3.Name, show3 );
            Repo.Add( show4.Name, show4 );
            Repo.Add( show5.Name, show5 );
            Repo.Add( show6.Name, show6 );
            Repo.Add( show7.Name, show7 );
            Repo.Add( show8.Name, show8 );
        }

        public ShowMemoryRepository() : base( Repo ) { }
    }
}