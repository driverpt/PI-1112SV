using System.Collections.Generic;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels.Interfaces;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels
{
    public class Show : IDomainModel<string>
    {
        public Show(string name, string description)
        {
            Name = name;
            Description = description;
            Seasons = new List<Season>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Season> Seasons { get; private set; }

        public string Id
        {
            get { return Name;  }
            set { Name = value; }
        }
    }
}