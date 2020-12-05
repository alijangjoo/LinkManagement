namespace Dotin.URLManagement.EndPoints.URLViewerAPI.Controllers
{
    using Dotin.URLManagement.Core.Contracts.URLViewer;
    using Dotin.URLManagement.Core.SharedDTO.Request;
    using Dotin.URLManagement.Core.SharedDTO.Response;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class URLViewerController : ControllerBase
    {
        private readonly IURLViewerService urlViewerService;

        public URLViewerController(IURLViewerService urlViewerService)
        {
            this.urlViewerService = urlViewerService;
        }

        [Route("GetMainURL")]
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] InputData inputData)
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
                return Ok(apiResponse);
            }

            else
            {
                try
                {
                    string mainURL = await urlViewerService.GetMainURL(inputData.URL);
                    Redirect(mainURL);
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
                return Ok(apiResponse);
            }

        }
    }
}
