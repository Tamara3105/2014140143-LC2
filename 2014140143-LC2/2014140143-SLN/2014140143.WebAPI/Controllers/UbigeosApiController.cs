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
    public class UbigeosApiController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public UbigeosApiController()
        {

        }

        public UbigeosApiController(IUnityOfWork unityOfWork)
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
            var Ubigeos = _UnityOfWork.Ubigeos.GetAll();

            if (Ubigeos == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var UbigeosDTO = new List<UbigeoDTO>();

            foreach (var ubigeo in Ubigeos)
                UbigeosDTO.Add(Mapper.Map<Ubigeo, UbigeoDTO>(ubigeo));

            return Ok(UbigeosDTO);
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
            var ubigeo = _UnityOfWork.Ubigeos.Get(id);

            if (ubigeo == null)
                return NotFound();

            return Ok(Mapper.Map<Ubigeo, UbigeoDTO>(ubigeo));
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
        public IHttpActionResult Update(int id, UbigeoDTO ubigeoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ubigeoInPersistence = _UnityOfWork.Ubigeos.Get(id);
            if (ubigeoInPersistence == null)
                return NotFound();

            Mapper.Map<UbigeoDTO, Ubigeo>(ubigeoDTO, ubigeoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(ubigeoDTO);
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
        public IHttpActionResult Create(UbigeoDTO ubigeoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ubigeo = Mapper.Map<UbigeoDTO, Ubigeo>(ubigeoDTO);

            _UnityOfWork.Ubigeos.Add(ubigeo);
            _UnityOfWork.SaveChanges();

            ubigeoDTO.UbigeoId = ubigeo.UbigeoId;

            return Created(new Uri(Request.RequestUri + "/" + ubigeo.UbigeoId), ubigeoDTO);
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

            var ubigeoInDataBase = _UnityOfWork.Ubigeos.Get(id);
            if (ubigeoInDataBase == null)
                return NotFound();

            _UnityOfWork.Ubigeos.Delete(ubigeoInDataBase);
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