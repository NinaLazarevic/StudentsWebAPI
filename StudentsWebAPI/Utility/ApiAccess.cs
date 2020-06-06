using StudentsWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentsWebAPI.Web.Utility
{
    public static class APIAccess
    {
        public static List<StudentModel> GetStudentsFromAPI(string baseAdress, string requestUri)
        {
            List<StudentModel> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAdress);
                //HTTP GET
                var responseTask = client.GetAsync(requestUri);
                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Result.Content.ReadAsAsync<List<StudentModel>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else
                {
                    return null;
                }

                return students;
            }

        }
    }
}
