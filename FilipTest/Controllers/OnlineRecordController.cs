using System;
using System.Collections.Generic;
using FilipTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilipTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineRecordController : ControllerBase
    {
        [HttpGet]
        public OnlineRecord Get()
        {
            return new OnlineRecord {
                ID = "SAMPLE",
                Time = DateTime.Now,
                Depth = 1203.25F,
                Parameters = new Dictionary<string, float> {
                    { "ROP", 195.25F },
                    { "WOB", 4.117F },
                    { "RPM", 155.0F }
                }
            };
        }
    }
}