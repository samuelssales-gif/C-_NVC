using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadAlunoTorloni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadAlunoTorloni.Controllers
{
    public class FrutasController : Controller
    {
        private readonly ILogger<FrutasController> _logger;

        public FrutasController(ILogger<FrutasController> logger)
        {
            _logger = logger;
        }

        private List<Frutas> frutas = new List<Frutas>
        {
            new Frutas { Id = 1, Nome = "maca",    Cor = "vermelha", Categoria = "Tropical" },
            new Frutas { Id = 2, Nome = "Banana",  Cor = "Amarela",  Categoria = "Tropical" },
            new Frutas { Id = 3, Nome = "uva",     Cor = "Roxa",     Categoria = "Tropical" },
            new Frutas { Id = 4, Nome = "Limao",   Cor = "verde",    Categoria = "Citrica"  },
            new Frutas { Id = 5, Nome = "Abacaxi", Cor = "Amarelo",  Categoria = "Citrica"  },
        };

        public IActionResult Index()
        {
            return View(frutas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Frutas fruta)
        {
            fruta.Id = frutas.Max(f => f.Id) + 1;
            frutas.Add(fruta);
            return RedirectToAction("Index");
        }

        public IActionResult FrutasCitricas()
        {
            return View();
        }

        public IActionResult FrutasTropicais()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
