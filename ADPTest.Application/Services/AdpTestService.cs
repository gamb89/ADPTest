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
        protected readonly IAdpTestRepository _repository;

        public ADPTestService(IAdpTestRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseObjectDto> Calculate(bool save = false)
        {
            //return object
            ResponseObjectDto dto;

            //Get Task and values
            var task = await this.GetTask(true);

            if (task != null)
            {
                this.GetOperationResult(ref task);

                // check if need to save in the database (BONUS)
                if(save)
                {
                   await _repository.SaveResult(task); 
                }
                
                // Post Result
                using (var httpClient = new HttpClient())
                {
                    var url = @"https://interview.adpeai.com/api/v1/submit-task";
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.PostAsJsonAsync(url, task);

                    dto = new ResponseObjectDto()
                    {
                        StatusCode = response.StatusCode.ToString(),
                        Message = response.IsSuccessStatusCode ? "Success" : await response.Content.ReadAsStringAsync()
                    };

                    return dto;

                }
            }
            else
                return dto = new ResponseObjectDto()
                {
                    Message = "Values not found",
                    StatusCode = "404"
                };

        }

        private async Task<TaskResult> GetTask(bool save = false)
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

        private void GetOperationResult(ref TaskResult task)
        {
            switch (task.Operation.ToUpper())
            {
                case "SUBTRACTION":
                    task.Result = task.Left - task.Right;
                    break;
                case "ADDITION":
                    task.Result = task.Left + task.Right;
                    break;
                case "MULTIPLICATION":
                    task.Result = task.Left * task.Right;
                    break;
                case "DIVISION":
                    task.Result = task.Left / task.Right;
                    break;
                default:
                    task.Result = 0;
                    break;
            }
        }
    }
}
