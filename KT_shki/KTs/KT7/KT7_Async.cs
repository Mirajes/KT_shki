using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace KT_shki
{
    public class KT7_Async // no : KT
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        List<string> _urls = new List<string>();

        HttpClient _httpClient = new HttpClient();

        public void Execute()
        {
            Helper.MakeAnIndentation("КТ7: Асинхронность");

            while (true)
            {
                Console.WriteLine("\nСовершите действие:" +
                    "\n  >> 1 - Подсчитать символы из всех" +
                    "\n  >> 2 - Добавить свою ссылку" +
                    "\n  >> 3 - Очистить список" +
                    "\n  >> 4 - Показать весь список" +
                    "\n  >> fastDebug");

                string action = string.Empty;
                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "1":
                        Console.WriteLine("\n --- Подсчёт --- \n");
                        ProcessAllUrls().Wait();
                        break;
                    case "2":
                        Console.Write("\nВпишите ссылку\n >> ");
                        string newUrl = Console.ReadLine();
                        _urls.Add(newUrl);
                        break;
                    case "3":
                        _urls.Clear();
                        Console.WriteLine("\nОчищен список");
                        break;
                    case "4":
                        Console.WriteLine("\nВаш список");
                        foreach (var url in _urls)
                            Console.WriteLine($"{url}");
                        break;
                    case "fastDebug":
                        _urls.Add("https://yandex.ru/search/?text=a&clid=2411726&lr=2");
                        _urls.Add("https://www.rbc.ru/technology_and_media/03/12/2025/693049d99a794725af5720be?ysclid=mou22ft0q2300517703");
                        ProcessAllUrls();
                        break;
                    default:
                        Console.WriteLine("invalid");
                        break;
                }
            }
        }

        private async Task ProcessAllUrls()
        {
            if (_urls.Count == 0)
            {
                Console.WriteLine("Список URL пуст!");
                return;
            }

            List<Task> tasks = new List<Task>();

            foreach (var url in _urls)
            {
                tasks.Add(TextCounterTask(url));
            }

        }

        private async Task TextCounterTask(string url)
        {
            try
            {
                string text = await _httpClient.GetStringAsync(url);
                int charCount = 0;
                foreach (var c in text)
                {
                    if (!char.IsWhiteSpace(c))
                        charCount++;
                }

                Console.WriteLine($"URL - {url}" +
                    $"\n Кол-во символов без пробелов: {charCount}");
            }
            catch (System.Exception)
            {
                Console.WriteLine($"issue with < {url} >");
                throw;
            }



            await _httpClient.DeleteAsync(url);
        }
    }
}
/*
 using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace KT_shki
{
    public class KT7_Async
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private List<string> _urls = new List<string>();
        private HttpClient _httpClient = new HttpClient();

        public void Execute()
        {
            Helper.MakeAnIndentation("КТ7: Асинхронность");

            while (true)
            {
                Console.WriteLine("\nСовершите действие:" +
                    "\n  >> 1 - Подсчитать символы из всех" +
                    "\n  >> 2 - Добавить свою ссылку" +
                    "\n  >> 3 - Очистить список" +
                    "\n  >> 4 - Показать весь список" +
                    "\n  >> fastDebug");

                string action = string.Empty;
                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "1":
                        Console.WriteLine("\n --- Подсчёт --- \n");
                        ProcessAllUrls().Wait(); // Ждём завершения подсчёта
                        break;
                    case "2":
                        Console.Write("\nВпишите ссылку\n >> ");
                        string newUrl = Console.ReadLine();
                        _urls.Add(newUrl);
                        break;
                    case "3":
                        _urls.Clear();
                        Console.WriteLine("\nОчищен список");
                        break;
                    case "4":
                        Console.WriteLine("\nВаш список");
                        foreach (var url in _urls)
                            Console.WriteLine($"{url}");
                        break;
                    case "fastDebug":
                        _urls.Add("https://yandex.ru/search/?text=a&clid=2411726&lr=2");
                        _urls.Add("https://www.rbc.ru/technology_and_media/03/12/2025/693049d99a794725af5720be?ysclid=mou22ft0q2300517703");
                        ProcessAllUrls().Wait(); // Ждём завершения
                        break;
                    default:
                        Console.WriteLine("invalid");
                        break;
                }
            }
        }

        private async Task ProcessAllUrls()
        {
            if (_urls.Count == 0)
            {
                Console.WriteLine("Список URL пуст!");
                return;
            }

            // Создаём задачи для каждой ссылки
            var tasks = new List<Task<int>>();

            foreach (var url in _urls)
            {
                tasks.Add(TextCounterTask(url));
            }

            try
            {
                // Ожидаем завершения всех задач и получаем результаты
                var results = await Task.WhenAll(tasks);

                // Выводим результаты
                Console.WriteLine("\nРезультаты подсчёта:");
                for (int i = 0; i < _urls.Count; i++)
                {
                    Console.WriteLine($"URL: {_urls[i]}");
                    Console.WriteLine($"Кол-во символов без пробелов: {results[i]}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке URL: {ex.Message}");
            }
        }

        private async Task<int> TextCounterTask(string url)
        {
            try
            {
                string text = await _httpClient.GetStringAsync(url);
                int charCount = 0;

                foreach (var c in text)
                {
                    if (!char.IsWhiteSpace(c))
                        charCount++;
                }

                return charCount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке {url}: {ex.Message}");
                return -1; // Возвращаем -1 для обозначения ошибки
            }
        }
    }
}
 */