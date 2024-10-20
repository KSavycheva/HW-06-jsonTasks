using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text;


namespace JsonTask 
{

    public class Book
    {
     public required PublishingHouse PublishingHouse { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public int PublishingHouseId {  get; set; }

        [JsonProperty("Name")]
        public string Title { get; set; }

     public Book(string Title, PublishingHouse publH, int publHId)     
      { 
       this.Title = Title;
       this.PublishingHouse = publH; 
       this.PublishingHouseId = publHId; 
      }

    } 
    
    public class PublishingHouse 
    {
     public int ID { get; set; }
     public string Name { get; set; }
     public string Adress { get; set; }

        public PublishingHouse(string name, string adress, int id) 
        {
            this.Name = name;
            this.Adress = adress;
            this.ID = id;
        }
      
    }

    class Program
    {
       static void Main(string[] args)
       {
        Console.OutputEncoding = Encoding.UTF8;

        string filePath = "C:\\Users\\admin\\jsonTaskHW.json";
        string jsonString = File.ReadAllText(filePath);
        
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonString);

            if(books != null)
            {
               foreach (var book in books)
               {
                   Console.WriteLine(book.Title);
               }

            }
            else
            {
                Console.WriteLine("No valid books found in json!");
            }

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nNow lets check if Serializer ignores PublishingHouseID and renames Title into Name in json: \n");
            
        var jsonStringTest = JsonConvert.SerializeObject(books[1]);
        Console.WriteLine(jsonStringTest);

        Console.ForegroundColor = ConsoleColor.White;
        }
        
    }
        
}