namespace Dotin.URLManagement.EndPoints.URLShortenerAPI.Controllers
{
    using Dotin.URLManagement.Core.Contracts.URLShortener;
    using Dotin.URLManagement.Core.SharedDTO.Request;
    using Dotin.URLManagement.Core.SharedDTO.Response;
    using Dotin.URLManagement.EndPoints.URLShortenerAPI.Validator;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class URLShortenerController : ControllerBase
    {
        private readonly IURLShortenerService urlShortenerService;

        public URLShortenerController(IURLShortenerService urlShortenerService)
        {
            this.urlShortenerService = urlShortenerService;
        }
        [Route("AddURL")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InputData inputData)
        {
            ApiResponse<string> apiResponse = null;
            if (string.IsNullOrEmpty(inputData.URL))
            {
                apiResponse = new ApiResponse<string>
                {
                    Data = string.Empty,
                    Errors = new List<ErrorInfo> { new ErrorInfo {Key = "UrlEmpty"
                    ,Description = "URL is empty"} },
                    Message = "request failed",
                    StatusCode = "404"
                };
            }
            else if (!URLValidator.UrlIsValid(inputData.URL))
            {
                apiResponse = new ApiResponse<string>
                {
                    Data = string.Empty,
                    Errors = new List<ErrorInfo> { new ErrorInfo {Key = "URL is not valid"
                    ,Description = "you only can send http or https url"} },
                    Message = "request failed",
                    StatusCode = "404"
                };
            }
            else
            {
                try
                {
                    string generatedURL = await urlShortenerService.AddURL(inputData.URL);
                    apiResponse = new ApiResponse<string> { Data = generatedURL, Errors = null, Message = "URL shortener work successfully", StatusCode = "200" };
                }
                catch (Exception ex)
                {
                    apiResponse = new ApiResponse<string>
                    {
                        Data = string.Empty,
                        Errors = new List<ErrorInfo>
                        { new ErrorInfo
                        { Key = "Unknown Exception"
                    ,Description = ex.Message}
                        },
                        Message = "request failed",
                        StatusCode = "500"
                    };
                }
            }
            return Ok(apiResponse);
        }
    }
}