using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentService.Models;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> students = null;
        public StudentController()
        {
            if (students == null)
            {
                students = new List<Student>()
                {
                    new Student() {Id=1, Name="Ajay", Batch="B001", Marks=90 },
                    new Student() {Id=2, Name="Jay", Batch="B001", Marks=90 },
                    new Student() {Id=3, Name="Vijay", Batch="B002", Marks=90 },
                    new Student() {Id=4, Name="Ajay", Batch="B001", Marks=90 },
                    new Student() {Id=5, Name="Ajay", Batch="B001", Marks=90 }

                };
            }
        }
        // CRUD operations
        // R > Get (Get all records)x

        public List<Student> Get()
        {
            return students.ToList();
        }

        [HttpGet("{id}")]

        public Student GetById(int? id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Create(Student student)
        {
            students.Add(student);

        }

        [HttpDelete("{id}")]
        public void Delete(int? id)
        {
            Student obj = students.FirstOrDefault(x => x.Id == id);
            ;
            if (obj != null)
                students.Remove(obj);
                
        }

        [HttpPut("{id}")]
        public void Edit(int? id, Student student)
        {
            Student obj = students.FirstOrDefault(x => x.Id == id);
             
            if (obj != null)
                foreach(Student temp in students)
                {
                    if(temp.Id== id)
                    {
                        temp.Batch = student.Batch;
                    }
                }
                 
        }

    }
}
