using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SchoolAPI.Data;
using SchoolAPI.Data.Entities;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator linkGenerator;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper,
                                                            LinkGenerator linkGenerator)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Returns Lidt of all students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StudentModel>> Get(int? departmentId)
        {
            try
            {
                IEnumerable<Student> students = _studentRepository.AllStudents;
                if(departmentId.HasValue)
                {
                    students = _studentRepository.AllStudents.Where(s => s.DepartmentId == departmentId);
                }
                List<StudentModel> result = _mapper.Map<List<StudentModel>>(students);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("id")]
        public ActionResult<StudentModel> Get(int id)
        {
            try
            {
                Student students = _studentRepository.GetById(id);
                StudentModel result = _mapper.Map<StudentModel>(students);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        public ActionResult<StudentModel> Post(StudentModel student)
        {
            
            try
            {
                Student studentDomainModel = _mapper.Map<Student>(student);
                var newStudentDM = _studentRepository.AddStudent(studentDomainModel);
                StudentModel result = _mapper.Map<StudentModel>(student);

                string location = linkGenerator.GetPathByAction("Get", "Students", new { id = result.Id});
                return Created(location, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public ActionResult<StudentModel> Put(StudentModel student)
        {
            try
            {
                
                var studentDomainModel = _mapper.Map<Student>(student);
                var updatedStudent = _studentRepository.Update(studentDomainModel);
                var result = _mapper.Map<StudentModel>(updatedStudent);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool isSuccess = _studentRepository.Remove(id);

                return Ok(isSuccess);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
