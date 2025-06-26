namespace check_users.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
