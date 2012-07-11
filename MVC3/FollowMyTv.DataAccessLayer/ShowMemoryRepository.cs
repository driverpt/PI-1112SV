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

            Episode episode2 = new Episode
                                   {
                                       Number = 2
                                       ,
                                       Title = "Cat's in the Bag..."
                                       ,
                                       Duration = 50
                                       ,
                                       Synopsis =
                                           "Walter and Jesse try to dispose of the two bodies in the RV, which becomes increasingly complicated when Krazy-8 wakes up. They eventually imprison him in Jesse's basement. Meanwhile, Skyler grows suspicious of Walter's recent behavior and discovers that their baby is a girl."
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
            Show show9 = new Show { Name = "Jackass-1", Description = "Jackass" };
            Show show10 = new Show { Name = "Jackass0", Description = "Jackass" };
            Show show11 = new Show { Name = "Jackass1", Description = "Jackass" };
            Show show12 = new Show { Name = "Jackass2", Description = "Jackass" };
            Show show13 = new Show { Name = "Jackass3", Description = "Jackass" };
            Show show14 = new Show { Name = "Jackass4", Description = "Jackass" };
            Show show15 = new Show { Name = "Jackass5", Description = "Jackass" };
            Show show16 = new Show { Name = "Jackass6", Description = "Jackass" };
            Show show17 = new Show { Name = "Jackass7", Description = "Jackass" };
            Show show18 = new Show { Name = "Jackass8", Description = "Jackass" };
            Show show19 = new Show { Name = "Jackass9", Description = "Jackass" };
            Show show20 = new Show { Name = "Jackass10", Description = "Jackass" };
            Show show21 = new Show { Name = "Jackass11", Description = "Jackass" };
            Show show22 = new Show { Name = "Jackass12", Description = "Jackass" };
            Show show23 = new Show { Name = "Jackass13", Description = "Jackass" };
            Show show24 = new Show { Name = "Jackass14", Description = "Jackass" };
            Show show25 = new Show { Name = "Jackass15", Description = "Jackass" };
            Show show26 = new Show { Name = "Jackass16", Description = "Jackass" };
            Show show27 = new Show { Name = "Jackass17", Description = "Jackass" };
            Show show28 = new Show { Name = "Jackass18", Description = "Jackass" };

            season.Episodes.Add( episode );
            season.Episodes.Add( episode2 );
            show.Seasons.Add( season );
            Repo.Add( show.Name, show );

            Repo.Add( show2.Name, show2 );
            Repo.Add( show3.Name, show3 );
            Repo.Add( show4.Name, show4 );
            Repo.Add( show5.Name, show5 );
            Repo.Add( show6.Name, show6 );
            Repo.Add( show7.Name, show7 );
            Repo.Add( show8.Name, show8 );

            Repo.Add( show9.Name, show9 );
            Repo.Add( show10.Name, show10 );
            Repo.Add( show11.Name, show11 );
            Repo.Add( show12.Name, show12 );
            Repo.Add( show13.Name, show13 );
            Repo.Add( show14.Name, show14 );
            Repo.Add( show15.Name, show15 );
            Repo.Add( show16.Name, show16 );
            Repo.Add( show17.Name, show17 );
            Repo.Add( show18.Name, show18 );
            Repo.Add( show19.Name, show19 );
            Repo.Add( show20.Name, show20 );
            Repo.Add( show21.Name, show21 );
            Repo.Add( show22.Name, show22 );
            Repo.Add( show23.Name, show23 );
            Repo.Add( show24.Name, show24 );
            Repo.Add( show25.Name, show25 );
            Repo.Add( show26.Name, show26 );
            Repo.Add( show27.Name, show27 );
            Repo.Add( show28.Name, show28 );
        }

        public ShowMemoryRepository() : base( Repo ) { }
    }
}