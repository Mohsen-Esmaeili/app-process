namespace Hahn.ApplicationProcess.July2021.Web.MiddleWares
{
    internal class InternalServerError
    {
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}