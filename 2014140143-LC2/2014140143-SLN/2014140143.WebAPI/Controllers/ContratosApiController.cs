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
    public class ContratosApiController : ApiController
    {
        // private _2011116302DbContext db = new _2011116302DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public ContratosApiController()
        {

        }

        public ContratosApiController(IUnityOfWork unityOfWork)
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
            var Contratos = _UnityOfWork.Contratos.GetAll();

            if (Contratos == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var ContratosDTO = new List<ContratoDTO>();

            foreach (var contrato in Contratos)
                ContratosDTO.Add(Mapper.Map<Contrato, ContratoDTO>(contrato));

            return Ok(ContratosDTO);
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
            var contrato = _UnityOfWork.Contratos.Get(id);

            if (contrato == null)
                return NotFound();

            return Ok(Mapper.Map<Contrato, ContratoDTO>(contrato));
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
        public IHttpActionResult Update(int id, ContratoDTO contratoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var contratoInPersistence = _UnityOfWork.Contratos.Get(id);
            if (contratoInPersistence == null)
                return NotFound();

            Mapper.Map<ContratoDTO, Contrato>(contratoDTO, contratoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(contratoDTO);
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
        public IHttpActionResult Create(ContratoDTO contratoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var contrato = Mapper.Map<ContratoDTO, Contrato>(contratoDTO);

            _UnityOfWork.Contratos.Add(contrato);
            _UnityOfWork.SaveChanges();

            contratoDTO.ContratoId = contrato.ContratoId;

            return Created(new Uri(Request.RequestUri + "/" + contrato.ContratoId), contratoDTO);
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

            var contratoInDataBase = _UnityOfWork.Contratos.Get(id);
            if (contratoInDataBase == null)
                return NotFound();

            _UnityOfWork.Contratos.Delete(contratoInDataBase);
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