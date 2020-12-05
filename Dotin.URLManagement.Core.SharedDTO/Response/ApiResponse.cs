namespace Dotin.URLManagement.Core.SharedDTO.Response
{
    using System.Collections.Generic;
    public class ApiResponse<TDataModel>
    {
        public TDataModel Data { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public List<ErrorInfo> Errors { get; set; } = new List<ErrorInfo>();
    }
}
