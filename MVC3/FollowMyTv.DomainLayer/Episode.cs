namespace FollowMyTv.DomainLayer
{
    public class Episode
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public long Duration { get; set; }
        public string Synopsis { get; set; }
        public int Score { get; set; }
    }
}