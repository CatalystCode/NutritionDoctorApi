﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionDoctorApi.Services;

namespace NutritionDoctorApi.Controllers
{
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        Lazy<MySqlStore> _database = new Lazy<MySqlStore>(() => new MySqlStore());

        private MySqlStore Database { get { return _database.Value; } }

        [HttpGet("{foodName}")]
        [ResponseCache(Duration = 3600)]
        public async Task<IActionResult> Get(string foodName)
        {
            if (String.IsNullOrEmpty(foodName))
            {
                return BadRequest();
            }

            var foodFacts = await Database.GetFoodFactsAsync(foodName);
            return Ok(foodFacts);
        }
    }
}
