using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet8__minimal_false__API.Context;
using Dotnet8__minimal_false__API.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8__minimal_false__API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContatoController (AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterViaId), new {id = contato.Id}, contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterViaId(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
            
                return NotFound();
    
            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var Contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(Contatos);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();
            
            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if (contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}