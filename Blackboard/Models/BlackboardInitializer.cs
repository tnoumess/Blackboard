using Blackboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MVC1.Models
{
    public class BlackboardInitializer //: DropCreateDatabaseIfModelChanges<BlackboardContext>
    {/*
        protected override void Seed(BlackboardContext context)
        {
            Console.Out.WriteLine(this);


            //instructor
            var Instructor = new List<Instructor>{
            new Instructor{InstructorID="G005555", LastName="Noumessi", DateofBirth=DateTime.Parse("02/02/1980"), FirstName="Thierry", Email="offut@gmu.edu"},
                                  
            };
            try
            {
                foreach (var tem in Instructor)
                {
                    context.Instructors.Add(tem);
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }


            //department
            var Department = new List<Department>{
            new Department{DepartmentID="CS", Name="Computer Science", InstructorID="G005555"},           
                       
            };

            try
            {
                foreach (var tem in Department)
                {
                    context.Departments.Add(tem);
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            //major
            var Major = new List<Major>{
            new Major{MajorID="SWE", Name="Software Engineering"},
            new Major{MajorID="CS", Name="Computer Science"},
            new Major{MajorID="ISA", Name="Information Security and Assurance"},
            new Major{MajorID="INFS", Name="Information System"},         
                       
            };

            try
            {
                foreach (var tem in Major)
                {
                    context.Majors.Add(tem);
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }



            //Student
            var student = new List<Student>
        {
            new Student{StudentID="G000000", FirstName="edson", LastName="Noumessi", Email="noume55i@mail.fr", MajorID="SWE", DateofBirth=DateTime.Parse("02/02/1987")},
            
        };

            try
            {
                foreach (var tem in student)
                {
                    context.Students.Add(tem);
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            //course
            var course = new List<Course>{
            new Course{CourseID="SWE619", Name="Object Oriented Software",Description="java programming", DepartmentID="CS",Credit=3},
            new Course{CourseID="SWE622", Name="Distributed Software Engineering",Description="Indepth study of how to design high-scale distributed systems ", DepartmentID="CS",Credit=3},
                               
            };
            try
            {
                foreach (var tem in course)
                {
                    context.Courses.Add(tem);
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }





        }*/
    }
}