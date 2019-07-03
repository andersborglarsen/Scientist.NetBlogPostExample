using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VatService.Models;

namespace VatService.Service
{
    public class VatService : IVatService
    {
        public InventoryResult NewResults(Inventory value)
        {
            if (value.Vat < 1)
            {
                return Result(value);
            }
            else
            {
                decimal vatsum = value.Vat / 100;

                decimal vat = (value.Units * value.Price) * vatsum;

                return new InventoryResult
                {
                    Id = value.Id,
                    Name = value.Name,
                    TotalPrice = (value.Price * value.Units) + vat
                };
            }

          
        }

        public InventoryResult Result(Inventory value)
        {

            decimal vat = (value.Units * value.Price) * value.Vat;

            return new InventoryResult
            {
                Id = value.Id,
                Name = value.Name,
                TotalPrice = (value.Price * value.Units) + vat
            };

           
        }
    }
}
