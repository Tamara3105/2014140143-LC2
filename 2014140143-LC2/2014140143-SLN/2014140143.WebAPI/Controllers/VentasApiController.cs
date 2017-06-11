using _2014140143_ENT.Entities;
using _2014140143_ENT.EntitiesDTO;
using _2014140143_ENT.IRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace LineaTelefonica.WebAPI.Controllers
{
    public class VentasApiController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public VentasApiController()
        {

        }

        public VentasApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: api/GenresApi
        //public IQueryable<Genre> GetGenres()
        //{
        //	return db.Genres;
        //}

        // GET api/GenresApi
        [HttpGet]
        public IHttpActionResult Get()
        {
            //La capa de persistencia no debe ser modificada, porque es única para todo canal de atencion de la aplicacion
            //por lo tanto, a nivel de controlador se debe de hacer las modificaciones.
            var Ventas = _UnityOfWork.Ventas.GetAll();

            if (Ventas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var VentasDTO = new List<VentaDTO>();

            foreach (var venta in Ventas)
                VentasDTO.Add(Mapper.Map<Venta, VentaDTO>(venta));

            return Ok(VentasDTO);
        }

        // GET: api/GenresApi/5
        //[ResponseType(typeof(Genre))]
        //public IHttpActionResult GetGenre(int id)
        //{
        //	Genre genre = db.Genres.Find(id);
        //	if (genre == null)
        //	{
        //		return NotFound();
        //	}

        //	return Ok(genre);
        //}

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var venta = _UnityOfWork.Ventas.Get(id);

            if (venta == null)
                return NotFound();

            return Ok(Mapper.Map<Venta, VentaDTO>(venta));
        }

        // PUT: api/GenresApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutGenre(int id, Genre genre)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return BadRequest(ModelState);
        //	}

        //	if (id != genre.GenreId)
        //	{
        //		return BadRequest();
        //	}

        //	db.Entry(genre).State = EntityState.Modified;

        //	try
        //	{
        //		db.SaveChanges();
        //	}
        //	catch (DbUpdateConcurrencyException)
        //	{
        //		if (!GenreExists(id))
        //		{
        //			return NotFound();
        //		}
        //		else
        //		{
        //			throw;
        //		}
        //	}

        //	return StatusCode(HttpStatusCode.NoContent);
        //}
        [HttpPut]
        public IHttpActionResult Update(int id, VentaDTO ventaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ventaInPersistence = _UnityOfWork.Ventas.Get(id);
            if (ventaInPersistence == null)
                return NotFound();

            Mapper.Map<VentaDTO, Venta>(ventaDTO, ventaInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(ventaDTO);
        }


        // POST: api/GenresApi
        //[ResponseType(typeof(Genre))]
        //public IHttpActionResult PostGenre(Genre genre)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return BadRequest(ModelState);
        //	}

        //	db.Genres.Add(genre);
        //	db.SaveChanges();

        //	return CreatedAtRoute("DefaultApi", new { id = genre.GenreId }, genre);
        //}
        [HttpPost]
        public IHttpActionResult Create(VentaDTO ventaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var venta = Mapper.Map<VentaDTO, Venta>(ventaDTO);

            _UnityOfWork.Ventas.Add(venta);
            _UnityOfWork.SaveChanges();

            ventaDTO.VentaId = venta.VentaId;

            return Created(new Uri(Request.RequestUri + "/" + venta.VentaId), ventaDTO);
        }

        // DELETE: api/GenresApi/5
        //[ResponseType(typeof(Genre))]
        //public IHttpActionResult DeleteGenre(int id)
        //{
        //	Genre genre = db.Genres.Find(id);
        //	if (genre == null)
        //	{
        //		return NotFound();
        //	}

        //	db.Genres.Remove(genre);
        //	db.SaveChanges();

        //	return Ok(genre);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ventaInDataBase = _UnityOfWork.Ventas.Get(id);
            if (ventaInDataBase == null)
                return NotFound();

            _UnityOfWork.Ventas.Delete(ventaInDataBase);
            _UnityOfWork.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}