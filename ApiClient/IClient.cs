namespace ApiClient
{
    public interface IClient
    {
        public QueryResult Get(FilterModel filterModel);
    }
}
