
using DevTorloni.Contexts;
using DevTorloni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DevTorloni.Controllers
{
    public class FeedController : Controller
    {
        private readonly ILogger<FeedController> _logger;
        private readonly DevConnectContext _context;

        public FeedController(ILogger<FeedController> logger, DevConnectContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
             List<TbPublicacao> TbPublicacao = await _context.TbPublicacao.Include(p => p.IdUsuarioNavigation).ToListAsync();
                return View(TbPublicacao);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            TbPublicacao novaPublicacao = new TbPublicacao
            {
                Descricao = form["Descricao"].ToString(),
                DataPublicacao = DateOnly.FromDateTime(DateTime.Now)
            };


            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                novaPublicacao.ImagemUrl = file.FileName;
            }

            try
            {
                _context.TbPublicacao.Add(novaPublicacao);
                await _context.SaveChangesAsync();
                ViewBag.publicacaocadastrada = "Cadastrada";
                return View();
            }
            catch (System.Exception)
            {
                ViewBag.publicacaocadastrada = "Nao cadastrada";
                throw;
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}