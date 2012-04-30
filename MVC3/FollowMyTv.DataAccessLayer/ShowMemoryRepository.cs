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
            Show show = new Show{ Name = "Breaking Bad"
                                , Description = "Informed he has terminal cancer, an underachieving chemistry genius "  +
                                                  "turned high school chemistry teacher turns to using his expertise in " +
                                                  "chemistry to provide a legacy for his family..."                       +
                                                  " by producing the world's highest quality crystal meth."
                                };
            Season season = new Season
                                {  
                                   Number = 1
                                 , Name = "1"
                                 , Debut = new DateTime(2008, 1, 28)
                                 , Finale = new DateTime(2008, 3, 10)
                                };
            Episode episode = new Episode
                                  {
                                        Title = "Pilot"
                                      , Duration = 40
                                      , Synopsis =
                                           "Walter White, a 50-year old chemistry teacher, secretly begins making crystal methamphetamine"
                                      +    " to support his family when he finds out that he has terminal lung cancer. He teams up with a former student,"
                                      +    " Jesse Pinkman, who is a meth dealer. Jesse is trying to sell the meth but the dealers snatch him and make him"
                                      +    " show them the lab. Walter knows they intend to kill him so he poisons them while showing them his recipe."
                                      , Score = 4
                                  };
        Repo.Add(show.Name, show);    
        }

        public ShowMemoryRepository() : base(Repo){}
    }
}