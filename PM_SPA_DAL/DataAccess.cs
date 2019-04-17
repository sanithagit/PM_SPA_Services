﻿using PM_SPA_Models;
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
            var tasks = dbCtxt.Tasks.Where(m => m.Project_ID == projectId && m.ProjectEndDate > DateTime.Now);
            return tasks.ToList();
        }
        // Add new Task
        public void AddTask(Task newTask)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            dbCtxt.Tasks.Add(newTask);
            dbCtxt.SaveChanges();          
        }
        // Update Task
        public void UpdateTask(Task editTask)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            var existingTask = dbCtxt.Tasks.Where(m => m.Task_ID == editTask.Task_ID).FirstOrDefault();

            existingTask.Parent_ID = editTask.Parent_ID;
            existingTask.TaskName = editTask.TaskName;
            existingTask.ProjectStartDate = editTask.ProjectStartDate;
            existingTask.ProjectEndDate = editTask.ProjectEndDate;
            existingTask.Priority = editTask.Priority;
            existingTask.User_ID = editTask.User_ID;
            dbCtxt.SaveChanges();
        }
        // delete Task
        public void DeleteTask(int id)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
          
            var deleteTask = dbCtxt.Tasks.Where(m => m.Task_ID == id).FirstOrDefault();
            dbCtxt.Tasks.Remove(deleteTask);
            dbCtxt.SaveChanges();
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
            var existingProject = dbCtxt.Projects.Where(m => m.Project_ID == editProject.Project_ID).FirstOrDefault();

            existingProject.Project_ID = editProject.Project_ID;
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
            var deleteProject = dbCtxt.Projects.Where(m => m.Project_ID == id).FirstOrDefault();
            dbCtxt.Projects.Remove(deleteProject);
            dbCtxt.SaveChanges();
        }
       
        // Get All Users
        public List<User> GetAllUsers()
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            List<User> UserList = new List<User>();
            UserList = dbCtxt.Users.ToList();
            UserList = UserList.GroupBy(i => i.Employee_ID).Select(g => g.First()).ToList();
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
            var existingUser = dbCtxt.Users.Where(m => m.User_ID == editUser.User_ID).FirstOrDefault();
                       
            existingUser.FirstName = editUser.FirstName;
            existingUser.LastName = editUser.LastName;
            existingUser.Employee_ID = editUser.Employee_ID;

            dbCtxt.SaveChanges();
        }
        //Delete User
        public void DeleteUser(int id)
        {
            ProjectManagerContext dbCtxt = new ProjectManagerContext();
            var deleteUser = dbCtxt.Users.Where(m => m.User_ID == id).FirstOrDefault();
            dbCtxt.Users.Remove(deleteUser);
            dbCtxt.SaveChanges();
        }       
    }
}
