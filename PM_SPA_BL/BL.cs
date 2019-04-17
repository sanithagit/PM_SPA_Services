using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PM_SPA_DAL;
using PM_SPA_Models;

namespace PM_SPA_BL
{
    public class BL
    {
        DataAccess objDal = null;        
        // Get All Tasks 
        public List<Task> GetAllTasks()
        {
            objDal = new DataAccess();
            List<Task> allTasks = objDal.GetAllTasks();
            List<ParentTask> parentTasks = objDal.GetAllParentTasks();
            List<Task> finalTasks = new List<Task>();
            foreach (Task task in allTasks)
            {
                if (task.Parent_ID != null)
                {
                    task.Parent = parentTasks.Where(m => m.ParentTaskId == task.Parent_ID).FirstOrDefault();
                }
                finalTasks.Add(task);
            }
            return finalTasks;
        }
        //Get All Parent Tasks
        public List<ParentTask> GetAllParentTasks()
        {
            objDal = new DataAccess();
            return objDal.GetAllParentTasks();
        }

        //Add New Task
        public void AddTask(Task newTask)
        {
            objDal = new DataAccess();
            objDal.AddTask(newTask);
        }

        //Update Existing Task Method
        public void UpdateTask(Task editTask)
        {
            objDal = new DataAccess();
            objDal.UpdateTask(editTask);
        }
        //Delete Existing Task Method
        public void DeleteTask(int id)
        {
            objDal = new DataAccess();
            objDal.DeleteTask(id);
        }      
        //Get List of all projects
        public List<Project> GetAllProjects()
        {
            objDal = new DataAccess();
            List<Project> allProjects = objDal.GetAllProjects();
            List<User> allUsers = objDal.GetAllUsers();
            List<Task> allTasks = objDal.GetAllTasks();
            List<Project> finalProjects = new List<Project>();
            foreach (Project project in allProjects)
            {
                project.projectTotalTasks = allTasks.Where(m => m.Project_ID == project.Project_ID).Count();
                project.projectTasksCompleted = objDal.GetCompletedTasksByProjectId(project.Project_ID).Count();
                finalProjects.Add(project);
            }
            return finalProjects;
        }

        //Add New Project
        public void AddProject(Project newProject)
        {
            objDal = new DataAccess();
            objDal.AddProject(newProject);
        }

        //Update Exisitng Project
        public void UpdateProject(Project editProject)
        {
            objDal = new DataAccess();
            objDal.UpdateProject(editProject);
        }

        //Delete Existing Project
        public void DeleteProject(int id)
        {
            objDal = new DataAccess();
            objDal.DeleteProject(id);
        }
       
        //Get all Users  Method returns List
        public List<User> GetAllUsers()
        {
            objDal = new DataAccess();
            return objDal.GetAllUsers();
        }

        // Add New User 
        public void AddUser(User newUser)
        {
            objDal = new DataAccess();
            objDal.AddUser(newUser);
        }
        // Update Existing User
        public void UpdateUser(User editUser)
        {
            objDal = new DataAccess();
            objDal.UpdateUser(editUser);
        }
        //Delete Existing User
        public void DeleteUser(int id)
        {
            objDal = new DataAccess();
            objDal.DeleteUser(id);
        }
       
    }
}
