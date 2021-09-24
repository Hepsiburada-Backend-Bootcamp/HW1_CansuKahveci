using HomeworkW1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HomeworkW1.Controllers
{
    [Route("api/v1/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private List<ReservationDTO> _list;

        //gecici database
        public ReservationController()
        {
            _list = new List<ReservationDTO>();
            _list.Add(new ReservationDTO(1,"Fatih", 6, 10, "Ayşe", "Er", 11111111111));
            _list.Add(new ReservationDTO(2,"Kadıköy", 2,8, "Veli", "Kocabaş", 11111111222));
            _list.Add(new ReservationDTO(3,"Kadıköy", 4, 14, "Ahmet", "Akın", 11111111133));
            _list.Add(new ReservationDTO(4, "Fatih", 5, 9, "Seda", "Senar", 11111111188));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reservation = _list.FirstOrDefault(x => x.id == id);
            if (reservation != null)
            {
                return Ok(reservation);
            } // islem basarlı ama reservation bulunamıyor
            return NotFound();
        }

        [HttpGet("{location}")]
        public IActionResult Get(string location)
        {
            return Ok();
        }


        [HttpPost("")]
        public IActionResult Add([FromBody]ReservationDTO reservation)
        {
            _list.Add(reservation);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ReservationDTO reservation)
        {
            var reservation = _list.FirstOrDefault(x => x.id == id);
            if(reservation != null)
            {
                return Ok();                
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var reservation = _list.FirstOrDefault(x => x.id == id);
            if (reservation != null)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
