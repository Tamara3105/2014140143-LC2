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

using AutoMapper;
using _2014140143_ENT.IRepositories;
using _2014140143_ENT.Entities;
using _2014140143_ENT.EntitiesDTO;

namespace LineaTelefonica.WebAPI.Controllers
{
    public class AdministradorLineasApiController : ApiController
    {
        //private _2011116302DbContext db = new _2011116302DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public AdministradorLineasApiController()
        {

        }

        public AdministradorLineasApiController(IUnityOfWork unityOfWork)
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
            var AdministradorLineas = _UnityOfWork.AdministrarLineas.GetAll();

            if (AdministradorLineas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var AdministradorLineasDTO = new List<AdministradorLineaDTO>();
            
            foreach (var administradorLinea in AdministradorLineas)
                AdministradorLineasDTO.Add(Mapper.Map<AdministradorLinea, AdministradorLineaDTO>(administradorLinea));

            return Ok(AdministradorLineasDTO);
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
            var administradorLinea = _UnityOfWork.AdministrarLineas.Get(id);

            if (administradorLinea == null)
                return NotFound();

            return Ok(Mapper.Map<AdministradorLinea, AdministradorLineaDTO>(administradorLinea));
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
        public IHttpActionResult Update(int id, AdministradorLineaDTO administradorLineaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var administradorLineaInPersistence = _UnityOfWork.AdministrarLineas.Get(id);
            if (administradorLineaInPersistence == null)
                return NotFound();

            Mapper.Map<AdministradorLineaDTO, AdministradorLinea>(administradorLineaDTO, administradorLineaInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(administradorLineaDTO);
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
        public IHttpActionResult Create(AdministradorLineaDTO administradorLineaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var administradorLinea = Mapper.Map<AdministradorLineaDTO, AdministradorLinea>(administradorLineaDTO);

            _UnityOfWork.AdministrarLineas.Add(administradorLinea);
            _UnityOfWork.SaveChanges();

            administradorLineaDTO.AdministradorLineaId = administradorLinea.AdministradorLineaId;
            return Created(new Uri(Request.RequestUri + "/" + administradorLinea.AdministradorLineaId), administradorLineaDTO);
        }

        // DELETE: api/GenresApi/
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

            var administradorLineaInDataBase = _UnityOfWork.AdministrarLineas.Get(id);
            if (administradorLineaInDataBase == null)
                return NotFound();

            _UnityOfWork.AdministrarLineas.Delete(administradorLineaInDataBase);
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