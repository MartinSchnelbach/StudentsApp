using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StudentsCRUDApp.Models.Students;
using StudentsCRUDApp.Services;
using Microsoft.AspNetCore.Mvc;
using StudentsCRUDApp.Models.Student;

namespace StudentsCRUDApp.Controllers
{
    [Route("students")]
    public class StudentsController : Controller
    {

        private readonly StudentsInterface service;

        public StudentsController(StudentsInterface service)
        {
            this.service = service;
        }

        // GET: Students
        [HttpGet]
        public IActionResult Get()
        {
            var model = service.GetStudents();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult Get(int id)
        {
            var model = service.GetStudent(id);
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }


        [HttpPost]
        public IActionResult Create([FromBody]InputStudents inputModel)
        {
            if (inputModel == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = ToDomainModel(inputModel);
            service.AddStudent(model);

            var outputModel = ToOutputModel(model);
            return CreatedAtRoute("GetSTudent", new { id = outputModel.Id }, outputModel);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]InputStudents inputModel)
        {
            if (inputModel == null || id != inputModel.Id)
                return BadRequest();

            if (!service.StudentExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var model = ToDomainModel(inputModel);
            service.UpdateStudent(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.StudentExists(id))
                return NotFound();

            service.DeleteStudent(id);

            return NoContent();
        }

        #region 

        private OutputStudents ToOutputModel(Student model)
        {
            return new OutputStudents
            {
                Id = model.Id,
                Name = model.Name,
                Lastn = model.Lastn,
                Age = model.Age,
                Course = model.Course,
                Score = model.Score,
            };
        }

        private List<OutputStudents> ToOutputModel(List<Student> model)
        {
            return model.Select(item => ToOutputModel(item))
                        .ToList();
        }

        private Student ToDomainModel(InputStudents inputModel)
        {
            return new Student
            {
                Id = inputModel.Id,
                Name = inputModel.Name,
                Lastn = inputModel.Lastn,
                Age = inputModel.Age,
                Course = inputModel.Course,
                Score = inputModel.Score,
            };
        }
        #endregion

    }
}