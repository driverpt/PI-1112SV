using System.Collections.Generic;
using FollowMyTv.DomainLayer.Interfaces;

namespace FollowMyTv.DomainLayer
{
    // Must not define the setter for Collections : http://softwareblog.alcedo.com/post/2010/01/21/Readonly-collection-properties-and-XmlSerializer.aspx

    public class Show : IDomainModel<string>
    {
        public Show()
        {
            Seasons = new List<Season>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Season> Seasons { get; set; }

        public string Id
        {
            get { return Name;  }
            set { Name = value; }
        }
    }
}