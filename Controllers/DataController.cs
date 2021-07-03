using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        [HttpGet]
        [Route("Getdata")]
        public IActionResult GetData()
        {
            List<int> categories =new List<int>();
            categories.Add(1);
            categories.Add(2);

            //List<Location> locations = new List<Location>();

            //locations.Add(new Location { Latitude = 1.5347282806345879, Longitude = 110.35632207358996 });

            Location location = new Location();
            dynamic myObject = new Location();
            location.Latitude = 1.5347282806345879;
            location.Longitude = 110.35632207358996;
            //myObject.AddProperty("DateOfBirth", new DateTime(1980, 23, 11));


            //Courier
            List<Courier> courier = new List<Courier>();
            courier.Add(new Courier { Avatar = "images.avatar_1", Name = "Amy" });


            List<Menu> menus = new List<Menu>();
            menus.Add(new Menu { MenuId = 1, Name = "Sheep", Photo = "images.Sheep2", Description = "Burger with crispy chicken, cheese and lettuce", Calories = 200, Price = 10 });


            Root root = new Root();

            root.Id = 1;
            root.Name = "Sheep";
            root.Rating = 4.8;
            root.Categories = categories;
            root.PriceRating = "priceRating";
            root.Photo = "images.Sheep1";
            root.Duration = "30 - 45 min";
            root.Location = location;
            root.Courier = courier;
            root.Menu = menus;






            return Ok(root);

        }


        public class Location
        {
            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            [JsonProperty("longitude")]
            public double Longitude { get; set; }
        }

        public class Courier
        {
            [JsonProperty("avatar")]
            public string Avatar { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class Menu
        {
            [JsonProperty("menuId")]
            public int MenuId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("photo")]
            public string Photo { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("calories")]
            public int Calories { get; set; }

            [JsonProperty("price")]
            public int Price { get; set; }
        }

        public class Root
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("rating")]
            public double Rating { get; set; }

            [JsonProperty("categories")]
            public List<int> Categories { get; set; }

            [JsonProperty("priceRating")]
            public string PriceRating { get; set; }

            [JsonProperty("photo")]
            public string Photo { get; set; }

            [JsonProperty("duration")]
            public string Duration { get; set; }

            [JsonProperty("location")]
            public Location Location { get; set; }

            //[JsonProperty("courier")]
            //public Courier Courier { get; set; }

            [JsonProperty("courier")]
            public List<Courier> Courier { get; set; }

            [JsonProperty("menu")]
            public List<Menu> Menu { get; set; }
        }





    }
}
