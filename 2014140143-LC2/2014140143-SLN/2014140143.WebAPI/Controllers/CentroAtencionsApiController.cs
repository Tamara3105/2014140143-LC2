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
using _2014140143_ENT.EntitiesDTO;
using _2014140143_ENT.Entities;

namespace LineaTelefonica.WebAPI.Controllers
{
    public class CentroAtencionsApiController : ApiController
    {
        //private _2011116302DbContext db = new _2011116302DbContext();

        // GET: api/CentroAtencionsApi
        private readonly IUnityOfWork _UnityOfWork;

        public CentroAtencionsApiController()
        {

        }

        public CentroAtencionsApiController(IUnityOfWork unityOfWork)
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
            var CentroAtencions = _UnityOfWork.CentroAtencions.GetAll();

            if (CentroAtencions == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var CentroAtencionsDTO = new List<CentroAtencionDTO>();

            foreach (var centroAtencion in CentroAtencions)
                CentroAtencionsDTO.Add(Mapper.Map<CentroAtencion, CentroAtencionDTO>(centroAtencion));

            return Ok(CentroAtencionsDTO);
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
            var centroAtencion = _UnityOfWork.CentroAtencions.Get(id);

            if (centroAtencion == null)
                return NotFound();

            return Ok(Mapper.Map<CentroAtencion, CentroAtencionDTO>(centroAtencion));
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
        public IHttpActionResult Update(int id, CentroAtencionDTO centroAtencionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var centroAtencionInPersistence = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencionInPersistence == null)
                return NotFound();

            Mapper.Map<CentroAtencionDTO, CentroAtencion>(centroAtencionDTO, centroAtencionInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(centroAtencionDTO);
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
        public IHttpActionResult Create(CentroAtencionDTO centroAtencionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var centroAtencion = Mapper.Map<CentroAtencionDTO, CentroAtencion>(centroAtencionDTO);

            _UnityOfWork.CentroAtencions.Add(centroAtencion);
            _UnityOfWork.SaveChanges();

            centroAtencionDTO.CentroAtencionId = centroAtencion.CentroAtencionId;

            return Created(new Uri(Request.RequestUri + "/" + centroAtencion.CentroAtencionId), centroAtencionDTO);
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

            var centroAtencionInDataBase = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencionInDataBase == null)
                return NotFound();

            _UnityOfWork.CentroAtencions.Delete(centroAtencionInDataBase);
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