using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VatService.Models;

namespace VatService.Service
{
    public interface IVatService
    {


        InventoryResult Result(Inventory value);
        InventoryResult NewResults(Inventory value);
    }
}
