using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankLocator.Api.Models
{
    public static class BankLocatorInitializer
    {
        public static void Initialize(BankLocatorContext context)
        {
            context.Database.EnsureCreated();

            if (context.Bankoffices.Any())
            {
                return;
            }

            var bankoffices = new Bankoffice[]
            {
                new Bankoffice { Company = "Belfius", Name = "Nieuwrode", Latitude = 8.5544M, Longitude = 57.445454M  },
                new Bankoffice { Company = "KBC", Name = "Holsbeek", Latitude = 3.5544M, Longitude = 56.445454M  },
                new Bankoffice { Company = "Fortis", Name = "Aarschot", Latitude = 2.5544M, Longitude = 54.445454M  },
            };
            
            foreach (var bankoffice in bankoffices)
            {
                context.Bankoffices.Add(bankoffice);
            }

            context.SaveChanges();
        }
    }
}
