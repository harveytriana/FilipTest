using MessagePack;
using MessagePack.Resolvers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

// WebApiContrib.Core.MessagePack.Tests

namespace FilpTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FILIP TEST");

            Console.WriteLine("\nPause");
            Console.ReadKey();

            //DoGetJson();

            PostMessagePack();
            DoGetMessagePack();

            Console.WriteLine("\nPause");
            Console.ReadKey();
        }

        private static void DoGetJson()
        {
            var apiRoot = "http://localhost:52647";

            var httpClient = new HttpClient() {
                BaseAddress = new Uri(apiRoot)
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var rawData = httpClient.GetStringAsync("/api/books/").Result;

            var books = JsonConvert.DeserializeObject<List<Book>>(rawData);

            books.ForEach(x => {
                Console.WriteLine(x);
            });

            httpClient.Dispose();
        }

        private static void DoGetMessagePack()
        {
            var apiRoot = "http://localhost:52647";

            var httpClient = new HttpClient() {
                BaseAddress = new Uri(apiRoot)
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-msgpack"));

            var rawData = httpClient.GetStreamAsync("/api/books/").Result;

            var books = MessagePackSerializer.Deserialize<List<Book>>(rawData);

            books.ForEach(x => {
                Console.WriteLine(x);
            });

            httpClient.Dispose();
        }

        private static void PostMessagePack()
        {
            var apiRoot = "http://localhost:52647";

            var httpClient = new HttpClient() {
                BaseAddress = new Uri(apiRoot)
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();

            var book = new Book {
                Author = "Harvey Triana",
                Title = "The improvements over SignalR",
                Price = 6542.25,
                Words = 987645
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-msgpack"));

            var content = new ByteArrayContent(MessagePackSerializer.Serialize(book, ContractlessStandardResolver.Instance));

            var response = httpClient.PostAsync("/api/books/", content).Result;

            if (response.IsSuccessStatusCode) {
                Console.WriteLine("Success.");
            } else {
                Console.Write("Error");
            }

            httpClient.Dispose();
        }
    }




    [MessagePackObject]
    public class Book
    {
        [Key(0)]
        public string Title { get; set; }
        [Key(1)]
        public string Author { get; set; }
        [Key(2)]
        public double Price { get; set; }
        [Key(3)]
        public long Words { get; set; }

        public override string ToString()
        {
            return $"Author: {Author} Title: {Title} Price: {Price} Words: {Words}";
        }
    }
}
