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
    public class TrabajadorsApiController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public TrabajadorsApiController()
        {

        }

        public TrabajadorsApiController(IUnityOfWork unityOfWork)
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
            var Trabajadors = _UnityOfWork.Trabajadors.GetAll();

            if (Trabajadors == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var TrabajadorsDTO = new List<TrabajadorDTO>();

            foreach (var trabajador in Trabajadors)
                TrabajadorsDTO.Add(Mapper.Map<Trabajador, TrabajadorDTO>(trabajador));

            return Ok(TrabajadorsDTO);
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
            var trabajador = _UnityOfWork.Trabajadors.Get(id);

            if (trabajador == null)
                return NotFound();

            return Ok(Mapper.Map<Trabajador, TrabajadorDTO>(trabajador));
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
        public IHttpActionResult Update(int id, TrabajadorDTO trabajadorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trabajadorInPersistence = _UnityOfWork.Trabajadors.Get(id);
            if (trabajadorInPersistence == null)
                return NotFound();

            Mapper.Map<TrabajadorDTO, Trabajador>(trabajadorDTO, trabajadorInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(trabajadorDTO);
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
        public IHttpActionResult Create(TrabajadorDTO trabajadorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trabajador= Mapper.Map<TrabajadorDTO, Trabajador>(trabajadorDTO);

            _UnityOfWork.Trabajadors.Add(trabajador);
            _UnityOfWork.SaveChanges();

            trabajadorDTO.TrabajadorId = trabajador.TrabajadorId;

            return Created(new Uri(Request.RequestUri + "/" + trabajador.TrabajadorId), trabajadorDTO);
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

            var trabajadorInDataBase = _UnityOfWork.Trabajadors.Get(id);
            if (trabajadorInDataBase == null)
                return NotFound();

            _UnityOfWork.Trabajadors.Delete(trabajadorInDataBase);
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