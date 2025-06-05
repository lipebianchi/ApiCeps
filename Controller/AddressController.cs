using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_CEPs.Controller.AddressService;
using ApiCeps.Context;
using ApiCeps.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ApiCeps.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressContext _context;
        private readonly AddressService _addressService;
        public AddressController(AddressContext context, AddressService addressService)
        {
            _context = context;
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertCepDb(string cep)
        {
            cep = cep.Replace("-", "").Trim();

            var address = await _addressService.GetAddressFromCepAsync(cep);

            if (address == null) return NotFound("CEP não encontrado na API ViaCep");


            try
            {
                _context.FelipeAddress.Add(address);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                return Conflict(new { message = "CEP já cadastrado no banco de dados" });
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("primary key property 'Cep' is null"))
            {
                return BadRequest(new { message = "Erro ao salvar: o campo 'Cep' está Nulo. Esse cep é inexistente no ViaCEP" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno no servidor.", details = ex.Message });
            }


            return CreatedAtAction(nameof(GetAddress), new { cep = address.Cep }, address);
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetAddress(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8) throw new ArgumentException("O CEP não pode ser nulo, vazio, conter mais/ou menos de 8 dígitos.");

            cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);

            var address = await _context.FelipeAddress.FindAsync(cep);
        
            if (address == null) return NotFound();

            return Ok(address);
        }
    }
}