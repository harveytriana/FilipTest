using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MML.Shared;

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
                ID = "SAMP-0001",
                Time = DateTime.Now,
                Depth = 1203.0F,
                Parameters = new List<Parameter> {
                    new Parameter { Mnemonic = "ROP", Value= 95.25F },
                    new Parameter { Mnemonic = "WOB", Value= 4.117F },
                    new Parameter { Mnemonic = "RPM", Value= 155.0F }                }
            };
        }
    }
}