namespace ApiClient
{
    public interface IClient
    {
        public Task<QueryResult>? Get(FilterModel filterModel);

        public Task<bool> IsUp();

    }
}
