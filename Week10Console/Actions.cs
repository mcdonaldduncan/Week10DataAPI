using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Week10Console.Constants;

namespace Week10Console
{
    internal class Actions
    {
        List<Log> logs = new List<Log>();
        List<Error> errors = new List<Error>();

        public async void GetAllMonsters()
        {
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://localhost:7222/Monster/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("get-all").Result;
                    List<Monster> monsters = JsonConvert.DeserializeObject<List<Monster>>(await response.Content.ReadAsStringAsync());

                    Console.WriteLine("get-all");

                    foreach (var monster in monsters)
                    {
                        Console.WriteLine(monster.ToString());
                    }

                    logs.Add(new Log("get-all", response.RequestMessage?.ToString(), response.StatusCode.ToString(), DateTime.Now));

                }
				
			}
			catch (Exception e)
			{
                errors.Add(new Error(e.Message, e.Source));
            }
        }

        public async void GetMonsterByID(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7222/Monster/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync($"get-by-id/{id}").Result;
                    Monster monster = JsonConvert.DeserializeObject<Monster>(await response.Content.ReadAsStringAsync());

                    Console.WriteLine("get-by-id");
                    Console.WriteLine(monster?.ToString());

                    logs.Add(new Log("get-by-id", response.RequestMessage?.ToString(), response.StatusCode.ToString(), DateTime.Now));

                }

            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source));
            }
        }

        public async void UpdateMonsterByID(int id, string name, string type, string HP, string MP, string location)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7222/Monster/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsync($"update-by-id/{id}/{name}/{type}/{HP}/{MP}/{location}", new StringContent("")).Result;

                    logs.Add(new Log("update-by-id", response.RequestMessage?.ToString(), response.StatusCode.ToString(), DateTime.Now));

                }
            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source));
            }
        }

        public async void DeleteMonsterByID(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7222/Monster/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.DeleteAsync($"delete-by-id/{id}").Result;

                    logs.Add(new Log("delete-by-id", response.RequestMessage?.ToString(), response.StatusCode.ToString(), DateTime.Now));

                }
            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source));
            }

        }

        public void GenerateLogFile()
        {
            string writePath = Path.Combine(directoryPath, "logs.txt");

            try
            {
                if (File.Exists(writePath))
                {
                    File.Delete(writePath);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine($"Processed at: {DateTime.Now}");
                    sw.WriteLine();

                    foreach (var log in logs)
                    {
                        sw.WriteLine(log.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source));
            }
        }

        public void ReportErrors()
        {
            foreach (var error in errors)
            {
                Console.WriteLine($"Error: {error.ErrorMessage} Source: {error.Source}");
            }
        }
    }
}
