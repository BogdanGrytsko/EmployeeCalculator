﻿using Newtonsoft.Json;
using System.Text;

namespace EmployeeCalcucatorTest.ChatGpt;

public class OpenAIApiCaller
{
    public const string Gpt4Mini = "gpt-4o-mini";
    public const string Gpt4 = "gpt-4";

    private readonly string apiKey;
    private readonly string endpoint;
    private readonly string model;

    public OpenAIApiCaller(string apiKey, string endpoint, string model)
    {
        this.apiKey = apiKey;
        this.endpoint = endpoint;
        this.model = model;
    }

    public async Task<OpenAIResponse> Execute(string prompt)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        var payload = new
        {
            model = model,
            messages = new object[]
            {
                  new {
                      role = "system",
                      content = new object[] {
                          new {
                              type = "text",
                              text = "You are an AI assistant that helps people analyze data."
                          }
                      }
                  },
                  new {
                      role = "user",
                      content = new object[] {
                          new {
                              type = "text",
                              text = prompt
                          }
                      }
                  }
            },
            temperature = 0.7,
            top_p = 0.95,
            max_tokens = 800,
            stream = false
        };

        var response = await httpClient.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<OpenAIResponse>(content);
            var dymanicText = JsonConvert.DeserializeObject<dynamic>(content);
            Console.WriteLine(dymanicText);
            return responseData!;
        }
        else
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {response.StatusCode}, {response.ReasonPhrase}, {responseBody}");
            throw new Exception(responseBody);
        }
    }
}
