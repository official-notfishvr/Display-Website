using System;
using System.IO;

namespace DisplayWebsite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Enter the website URL:");
                string url = Console.ReadLine();

                if (!IsValidUrl(url))
                {
                    Console.WriteLine("Invalid URL. Exiting program.");
                    Console.ReadLine();
                    return;
                }

                Console.Title = $"Display Website {url}";
                CreateHtmlFile(url);

                Console.WriteLine($"HTML file 'output.html' created successfully.");
                Console.ReadLine();
            }
            else
            {
                Console.Title = $"Display Website {args.ToString()}";
                CreateHtmlFile(args.ToString());

                Console.WriteLine($"HTML file 'output.html' created successfully.");
                Console.ReadLine();
            }
        }

        static bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }

        static void CreateHtmlFile(string url)
        {
            string htmlContent = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>{url}</title>
    <style>
        body, html {{
            margin: 0;
            padding: 0;
            overflow: hidden;
        }}
        object {{
            width: 100%;
            height: 1000px;
        }}
    </style>
</head>
<body>
    <object data=""{url}"" type=""text/html""></object>
</body>
</html>";

            try
            {
                File.WriteAllText("output.html", htmlContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}
