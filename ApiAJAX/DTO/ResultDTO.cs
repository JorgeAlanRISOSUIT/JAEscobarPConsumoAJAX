namespace ApiAJAX.Result
{
    public class ResultDTO
    {
        public bool Success { get; set; }
        public object Error { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
        public List<object> Objects { get; set; }
    }
}
