using PI.WebGarten.Pipeline;

namespace PI.WebGarten.Demos.FollowMyTv.Filters
{
    public abstract class BaseFilter : IHttpFilter
    {
        protected readonly string _name;
        protected IHttpFilter _nextFilter;

        public string Name
        {
            get { return _name; }
        }

        protected BaseFilter(string name)
        {
            _name = name;
        }

        public void SetNextFilter(IHttpFilter nextFilter)
        {
            _nextFilter = nextFilter;
        }

        public abstract HttpResponse Process(RequestInfo requestInfo);
    }
}