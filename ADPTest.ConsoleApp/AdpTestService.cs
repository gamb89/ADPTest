using ADPTest.Application.Abstract;
using ADPTest.Application.DTO;
using ADPTest.Domain.Abstract.Repository;
using ADPTest.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Application.Services
{
    public class ADPTestService : IAdpTestService
    {
       
        public ADPTestService()
        {
         
        }

        public async Task<ResponseObjectDto> ExecuteOperation(bool save = false)
        {
            //return object
            ResponseObjectDto dto;

            //Get Task and values
            var task = await this.GetTask(true);

            if (task != null)
            {
                task.Result = this.GetOperationResult(task.Left, task.Right, task.Operation);

                // Post Result
                using (var httpClient = new HttpClient())
                {
                    var url = @"https://interview.adpeai.com/api/v1/submit-task";
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.PostAsJsonAsync(url, task);

                    dto = new ResponseObjectDto()
                    {
                        StatusCode = response.StatusCode.ToString(),
                        Message = response.IsSuccessStatusCode ? "Success" : await response.Content.ReadAsStringAsync(),
                        Result = task.Result 
                    };

                    return dto;

                }
            }
            else
                return new ResponseObjectDto() { Message = "Task Not Found", StatusCode = "400" }; 
        }


        private async Task<TaskResult?> GetTask(bool save = false)
        {

            using (var httpClient = new HttpClient())
            {
                var url = @"https://interview.adpeai.com/api/v1/get-task";
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<TaskResult>(json);

                    return task; 
                }
                else
                    return null;
            }
        }

        public double GetOperationResult(double left, double right, string operation)
        {
            double result = 0; 
            switch (operation.ToUpper())
            {
                case "SUBTRACTION":
                    result = left - right; ;
                    break;
                case "ADDITION":
                    result = left + right; 
                    break;
                case "MULTIPLICATION":
                    result = left * right;
                    break;
                case "DIVISION":
                    result = left / right;
                    break;
                case "REMAINDER":
                    result = left % right;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result; 
        }
    }
}
