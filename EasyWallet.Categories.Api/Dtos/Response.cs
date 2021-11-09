namespace EasyWallet.Categories.Api.Dtos
{
    public class Response<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class Response
    {
        public string Message { get; set; }
        public object Data => null;
    }
}
