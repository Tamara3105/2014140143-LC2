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
    public class DepartamentoesApiController : ApiController
    {
        //private _2011116302DbContext db = new _2011116302DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public DepartamentoesApiController()
        {

        }

        public DepartamentoesApiController(IUnityOfWork unityOfWork)
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
            var Departamentoes = _UnityOfWork.Departamentos.GetAll();

            if (Departamentoes == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var DepartamentosDTO = new List<DepartamentoDTO>();

            foreach (var departamento in Departamentoes)
                DepartamentosDTO.Add(Mapper.Map<Departamento, DepartamentoDTO>(departamento));

            return Ok(DepartamentosDTO);
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
            var departamento = _UnityOfWork.Departamentos.Get(id);

            if (departamento== null)
                return NotFound();

            return Ok(Mapper.Map<Departamento, DepartamentoDTO>(departamento));
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
        public IHttpActionResult Update(int id, DepartamentoDTO departamentoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var departamentoInPersistence = _UnityOfWork.Departamentos.Get(id);
            if (departamentoInPersistence == null)
                return NotFound();

            Mapper.Map<DepartamentoDTO, Departamento>(departamentoDTO, departamentoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(departamentoDTO);
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
        public IHttpActionResult Create(DepartamentoDTO departamentoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var departamento = Mapper.Map<DepartamentoDTO, Departamento>(departamentoDTO);

            _UnityOfWork.Departamentos.Add(departamento);
            _UnityOfWork.SaveChanges();

            departamentoDTO.DepartamentoId = departamento.DepartamentoId;

            return Created(new Uri(Request.RequestUri + "/" + departamento.DepartamentoId), departamentoDTO);
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

            var departamentoInDataBase = _UnityOfWork.Departamentos.Get(id);
            if (departamentoInDataBase == null)
                return NotFound();

            _UnityOfWork.Departamentos.Delete(departamentoInDataBase);
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