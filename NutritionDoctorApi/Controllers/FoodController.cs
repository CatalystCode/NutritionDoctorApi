﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionDoctorApi.Model;
using NutritionDoctorApi.Services;

namespace NutritionDoctorApi.Controllers
{
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        Lazy<MySqlStore> _database = new Lazy<MySqlStore>(() => new MySqlStore());

        private MySqlStore Database { get { return _database.Value; } }

        [HttpGet("{foodName}")]
        public async Task<IList<FoodFact>> Get(string foodName)
        {
            var foodFacts = await Database.GetFoodFactsAsync(foodName);
            return foodFacts;
        }
    }
}