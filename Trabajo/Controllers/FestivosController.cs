using Microsoft.AspNetCore.Mvc;
using Trabajo.Context;
using System;

namespace Trabajo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivosController : ControllerBase
    {
        private readonly FestivosContext _context;

        public FestivosController(FestivosContext context)
        {
            _context = context;
        }

        [HttpGet("ValidarFecha")]
        public ActionResult<string> ValidarFecha(int dia, int mes, int año)
        {
            if (!EsFechaValida(dia, mes, año))
            {
                return BadRequest("La fecha proporcionada no es válida.");
            }

            bool esFestivo = EsFestivo(dia, mes, año);
            if (esFestivo)
            {
                return "Es festivo.";
            }
            else
            {
                return "No es festivo.";
            }
        }

        private bool EsFechaValida(int dia, int mes, int año)
        {

            try
            {
                DateTime fecha = new DateTime(año, mes, dia);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool EsFestivo(int dia, int mes, int año)
        {

            if ((dia == 1 && mes == 1) || 
                (dia == 6 && mes == 1) || 
                (dia == 1 && mes == 5) || 
                (dia == 25 && mes == 12)) 
            {
                return true;
            }


            if (EsSemanaSanta(dia, mes, año))
            {
                return true;
            }

            return false;
        }

        private bool EsSemanaSanta(int day, int month, int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int monthEaster = (h + l - 7 * m + 114) / 31;
            int dayEaster = ((h + l - 7 * m + 114) % 31) + 1;

            return false;
        }

    }
}
