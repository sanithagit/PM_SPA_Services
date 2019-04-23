using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PM_SPA_BL;
using PM_SPA_Models;

namespace PM_SPA_Services.Controllers
{
    public class PMController : ApiController
    {
         BL ObjBl = null;

        [HttpGet]
        //Get all Tasks
        [Route("api/PM/GetAllTasks")]
        [ResponseType(typeof(List<Task>))]
        public IHttpActionResult GetAllTasks()
        {
            ObjBl = new BL();
            List<Task> tasks = ObjBl.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        //Get all Parent Tasks
        [Route("api/PM/GetAllParentTasks")]
        [ResponseType(typeof(List<ParentTask>))]
        public IHttpActionResult GetAllParentTasks()
        {
            ObjBl = new BL();
            List<ParentTask> tasks = ObjBl.GetAllParentTasks();
            return Ok(tasks);
        }

        [HttpPost]
        [Route("api/PM/AddTask")]
        //Add task
        [ResponseType(typeof(void))]
        public IHttpActionResult AddTask([FromBody]Task newTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ObjBl = new BL();
            ObjBl.AddTask(newTask);
            return Ok();
        }

        [HttpPost]
        [Route("api/PM/AddParentTask")]
        //Add task
        [ResponseType(typeof(void))]
        public IHttpActionResult AddParentTask([FromBody]ParentTask newTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ObjBl = new BL();
            ObjBl.AddParentTask(newTask);
            return Ok();
        }


        [HttpPut]
        [Route("api/PM/UpdateTask")]
        //MUpdate Task
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateTask([FromBody]Task editTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ObjBl = new BL();
            ObjBl.UpdateTask(editTask);
            return Ok();
        }

        [HttpDelete]
        //Delete task
        [Route("api/PM/DeleteTask/{Id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteTask(int Id)
        {
            ObjBl = new BL();
            ObjBl.DeleteTask(Id);
            return Ok();
        }

        [HttpPut]
        //Complete task
        [Route("api/PM/EndTask/{Id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult EndTask(int Id)
        {
            ObjBl = new BL();
            ObjBl.EndTask(Id);
            return Ok();
        }


        [HttpGet]
        //get all users
        [Route("api/PM/GetAllUsers")]
        [ResponseType(typeof(List<User>))]
        public IHttpActionResult GetAllUsers()
        {
            ObjBl = new BL();
            List<User> users = ObjBl.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("api/PM/AddUser")]
        //Add user
        [ResponseType(typeof(void))]
        public IHttpActionResult AddUser(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ObjBl = new BL();
            ObjBl.AddUser(newUser);
            return Ok();
        }

        [HttpPut]
        //Update User
        [Route("api/PM/UpdateUser")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateUser([FromBody]User editUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ObjBl = new BL();
            ObjBl.UpdateUser(editUser);
            return Ok();
        }

        [HttpDelete]
        //Delete user
        [Route("api/PM/DeleteUser/{Id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUser(int Id)
        {
            ObjBl = new BL();
            ObjBl.DeleteUser(Id);
            return Ok();
        }

        [HttpGet]
        //get all projects
        [Route("api/PM/GetAllProjects")]
        [ResponseType(typeof(List<Project>))]
        public IHttpActionResult GetAllProjects()
        {
            ObjBl = new BL();
            List<Project> projects = ObjBl.GetAllProjects();
            return Ok(projects);
        }

        [HttpPost]
        //Add new project
        [Route("api/PM/AddProject")]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddProject([FromBody]Project newProject)
        {
            ObjBl = new BL();
            ObjBl.AddProject(newProject);
            return Ok();
        }

        [HttpPut]
        //update project
        [Route("api/PM/UpdateProject")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateProject([FromBody]Project editProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ObjBl = new BL();
            ObjBl.UpdateProject(editProject);
            return Ok();
        }

        [HttpDelete]
        //Delete project
        [Route("api/PM/DeleteProject/{Id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteProject(int Id)
        {
            ObjBl = new BL();
            ObjBl.DeleteProject(Id);
            return Ok();
        }
    }
}