namespace PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels
{
    public class Episode
    {
        public Episode(string title, long duration, string synopsis, int score)
        {
            Title = title;
            Duration = duration;
            Synopsis = synopsis;
            Score = score;
        }

        public int Number { get; set; }
        public string Title { get; set; }
        public long Duration { get; set; }
        public string Synopsis { get; set; }
        public int Score { get; set; }
    }
}