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
    public class ProvinciasApiController : ApiController
    {
        //  private _2011116302DbContext db = new _2011116302DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public ProvinciasApiController()
        {

        }

        public ProvinciasApiController(IUnityOfWork unityOfWork)
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
            var Provincias = _UnityOfWork.Provincias.GetAll();

            if (Provincias == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var ProvinciasDTO = new List<ProvinciaDTO>();

            foreach (var provincia in Provincias)
                ProvinciasDTO.Add(Mapper.Map<Provincia, ProvinciaDTO>(provincia));

            return Ok(ProvinciasDTO);
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
            var provincia = _UnityOfWork.Provincias.Get(id);

            if (provincia == null)
                return NotFound();

            return Ok(Mapper.Map<Provincia, ProvinciaDTO>(provincia));
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
        public IHttpActionResult Update(int id, ProvinciaDTO provinciaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var provinciaInPersistence = _UnityOfWork.Provincias.Get(id);
            if (provinciaInPersistence == null)
                return NotFound();

            Mapper.Map<ProvinciaDTO, Provincia>(provinciaDTO, provinciaInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(provinciaDTO);
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
        public IHttpActionResult Create(ProvinciaDTO provinciaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var provincia = Mapper.Map<ProvinciaDTO, Provincia>(provinciaDTO);

            _UnityOfWork.Provincias.Add(provincia);
            _UnityOfWork.SaveChanges();

            provinciaDTO.ProvinciaId = provincia.ProvinciaId;

            return Created(new Uri(Request.RequestUri + "/" + provincia.ProvinciaId), provinciaDTO);
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

            var provinciaInDataBase = _UnityOfWork.Provincias.Get(id);
            if (provinciaInDataBase == null)
                return NotFound();

            _UnityOfWork.Provincias.Delete(provinciaInDataBase);
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