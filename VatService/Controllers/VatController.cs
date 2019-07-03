using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VatService.Models;
using VatService.Service;

namespace VatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatController : ControllerBase
    {
        private IVatService _vatService;
        private IResultPublisher _resultPublisher;
        public VatController(IVatService vatService, IResultPublisher resultPublisher)
        {
            _vatService = vatService;
            _resultPublisher = resultPublisher;
                            
            
            


        }
        
        // POST api/values
        [HttpPost]
        public InventoryResult Post([FromBody] Inventory value)
        {
            Scientist.ResultPublisher = new MyResultPublisher();

            return Scientist.Science<InventoryResult>("VatIsCorrect", experiment =>
            {
                experiment.Compare((x, y) => x.TotalPrice == y.TotalPrice);


                experiment.Use(() => _vatService.Result(value)); // old way
                experiment.Try(() => _vatService.NewResults(value)); // new way
                
            });

            
        }
    }
}