
using CadAlunoTorloni.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadAlunoTorloni.Controllers
{
      public class AlunosController : Controller
    {
        private readonly ILogger<AlunosController> _logger;

        public AlunosController(ILogger<AlunosController> logger)
        {
            _logger = logger;
        }

        private List<Alunos> alunos = new List<Alunos>
        {
            new Alunos { Id = 1, Nome = "Davi",   Idade = 17, CPF = "123456789" },
            new Alunos { Id = 2, Nome = "Henrique", Idade = 17,  CPF = "213456789" },
            new Alunos { Id = 3, Nome = "Murilo",    Idade = 16,     CPF = "312456789" },
            new Alunos { Id = 4, Nome = "Pedro",  Idade = 17,    CPF = "412356789"  },
            new Alunos { Id = 5, Nome = "Samuel",Idade = 17,  CPF = "512346789"  },
        };

        public IActionResult Index()
        {
            return View(alunos);
        }
        public IActionResult Create()
        {
            return View();
        }

      [HttpPost]
public IActionResult Create(Alunos aluno)
{
    if (alunos.Count > 0)
    {
        aluno.Id = alunos.Max(a => a.Id) + 1;
    }
    else
    {
        aluno.Id = 1;
    }

    alunos.Add(aluno);

    return RedirectToAction("Index");
}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}