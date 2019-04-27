using PM_SPA_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM_SPA_DAL
{
   public  class DataAccess
    {
       
        //Get List of All Tasks
        public List<Task> GetAllTasks()
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            return dbCtxt.Tasks.ToList();
        }
        //Get All Parent Tasks
        public List<ParentTask> GetAllParentTasks()
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            return dbCtxt.ParentTasks.ToList();
        }
        //Get Completed Tasks 
        public List<Task> GetCompletedTasksByProjectId(int projectId)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            var tasks = dbCtxt.Tasks.Where(m => m.Project_ID == projectId && m.TaskEndDate < DateTime.Now);
            return tasks.ToList();
        }
        // Add new Task
        public void AddTask(Task newTask)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();  
           
            dbCtxt.Tasks.Add(newTask);
            dbCtxt.SaveChanges();
       
        }

        // Add new Task
        public void AddParentTask(ParentTask newTask)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();

            dbCtxt.ParentTasks.Add(newTask);
            dbCtxt.SaveChanges();

        }

        // Update Task
        public void UpdateTask(Task editTask)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            var existingTask = dbCtxt.Tasks.Where(m => m.TaskId == editTask.TaskId).FirstOrDefault();

            existingTask.ParentId = editTask.ParentId;
            existingTask.TaskName = editTask.TaskName;
            existingTask.TaskStartDate = editTask.TaskStartDate;
            existingTask.TaskEndDate = editTask.TaskEndDate;
            existingTask.Priority = editTask.Priority;
            existingTask.User_ID = editTask.User_ID;
            dbCtxt.SaveChanges();
        }
        // delete Task
        public void DeleteTask(int id)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
          
            var deleteTask = dbCtxt.Tasks.Where(m => m.TaskId == id).FirstOrDefault();
            if (deleteTask != null)
            {
                dbCtxt.Tasks.Remove(deleteTask);
                dbCtxt.SaveChanges();
            }
        }

        // end Task
        public void EndTask(int id)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();

            var endTask = dbCtxt.Tasks.Where(m => m.TaskId == id).FirstOrDefault();
            if (endTask != null)
            {
                endTask.Status = false;
                dbCtxt.SaveChanges();
            }
        }


        //Get all projects

        public List<Project> GetAllProjects()
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            return dbCtxt.Projects.ToList();
        }

        // Add New Project
        public void AddProject(Project newProject)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            dbCtxt.Projects.Add(newProject);
            dbCtxt.SaveChanges();
        }


        // Update Existing Project
        public void UpdateProject(Project editProject)

        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            var existingProject = dbCtxt.Projects.Where(m => m.ProjectId == editProject.ProjectId).FirstOrDefault();

            existingProject.ProjectId = editProject.ProjectId;
            existingProject.ProjectName = editProject.ProjectName;
            existingProject.ProjectStartDate = editProject.ProjectStartDate;
            existingProject.ProjectEndDate = editProject.ProjectEndDate;
            existingProject.Priority = editProject.Priority;
            existingProject.User_ID = editProject.User_ID;

            dbCtxt.SaveChanges();          

        }

        //Delete Existing project Method
        public void DeleteProject(int id)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            var deleteProject = dbCtxt.Projects.Where(m => m.ProjectId == id).FirstOrDefault();
            if (deleteProject != null)
            {
                dbCtxt.Projects.Remove(deleteProject);
                dbCtxt.SaveChanges();
            }
        }
       
        // Get All Users
        public List<User> GetAllUsers()
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            List<User> UserList = new List<User>();
            UserList = dbCtxt.Users.ToList();
            UserList = UserList.ToList();
            return UserList;
        }

        //Add New User
        public void AddUser(User newUser)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            dbCtxt.Users.Add(newUser);
            dbCtxt.SaveChanges();
        }

        // Update User
        public void UpdateUser(User editUser)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            var existingUser = dbCtxt.Users.Where(m => m.UserId == editUser.UserId).FirstOrDefault();
                       
            existingUser.FirstName = editUser.FirstName;
            existingUser.LastName = editUser.LastName;
            existingUser.EmployeeId = editUser.EmployeeId;

            dbCtxt.SaveChanges();
        }
        //Delete User
        public void DeleteUser(int id)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            var deleteUser = dbCtxt.Users.Where(m => m.UserId == id).FirstOrDefault();
            if (deleteUser != null)
            {
                dbCtxt.Users.Remove(deleteUser);
                dbCtxt.SaveChanges();
            }
        }       
    }
}
