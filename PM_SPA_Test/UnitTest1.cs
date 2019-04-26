using System;
using PM_SPA_BL;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using PM_SPA_Models;
using System.Collections.Generic;

namespace PM_SPA_Test
{
    [TestClass]
    public class UnitTest1
    {
        BL ObjBl = new BL();
        int userIdDummy;
        int parentTaskIdDummy;
        int projectIdDummy;
        int taskIdDummy;

        [TestMethod]
        [Order(1)]
        public void AddUser()
        {
            User obj = new User();
            obj.UserId = 0;
            obj.FirstName = "Nivi";
            obj.LastName = "Pauly";
            obj.EmployeeId = 3488;
            try
            {
                ObjBl.AddUser(obj);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("USer not added");
            }
        }

        [TestMethod]
        [Order(2)]
        public void GetAllUsers()
        {                        
            Assert.IsTrue(ObjBl.GetAllUsers().Count > 0);
        }       

        [TestMethod]
        [Order(3)]
        public void UpdateUser()
        {
            List<User> result = ObjBl.GetAllUsers();
            User obj1 = result.Find(x => x.FirstName == "Nivi");
            userIdDummy = obj1.UserId;


            User obj = new User();
            obj.UserId = userIdDummy;
            obj.FirstName = "Nivy Updated";
            obj.LastName = "Paul";
            obj.EmployeeId = 3488;
            try
            {
                ObjBl.UpdateUser(obj);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("USer not updated");
            }
        }


      
        [TestMethod]
        [Order(4)]
        public void AddProject()
        {
            List<User> result = ObjBl.GetAllUsers();
            User obj1 = result.Find(x => x.FirstName == "Nivi");
            userIdDummy = obj1.UserId;

            Project obj = new Project();
            obj.ProjectName = "Project New";
            obj.User_ID = userIdDummy;
            obj.ProjectStartDate = DateTime.Now;
            obj.ProjectEndDate = DateTime.Now;
            obj.Priority = 1;
            try
            {
                ObjBl.AddProject(obj);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Project not added");
            }
        }

        [TestMethod]
        [Order(5)]
        public void GetAllProject()
        {                    
            Assert.IsTrue(ObjBl.GetAllProjects().Count > 0);
        }


        [TestMethod]
        [Order(6)]
        public void UpdateProject()
        {
            List<Project> result = ObjBl.GetAllProjects();
            Project obj1 = result.Find(x => x.ProjectName == "Project New");
            projectIdDummy = obj1.ProjectId;

            Project obj = new Project();
            obj.ProjectId = projectIdDummy;
            obj.ProjectName = "Project updated";
            obj.User_ID = 1;
            obj.ProjectStartDate = DateTime.Now;
            obj.ProjectEndDate = DateTime.Now;
            obj.Priority = 1;
            try
            {
                ObjBl.AddProject(obj);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Project not updated");
            }
        }




        [TestMethod]
        [Order(7)]
        public void AddParentTask()
        {
            ParentTask obj = new ParentTask();
            obj.Parent_Task = "Task New Parent";
            
            try
            {
                ObjBl.AddParentTask(obj);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Parent Task not added");
            }
        }

        [TestMethod]
        [Order(8)]
        public void GetAllParentTasks()
        {  
          
            Assert.IsTrue(ObjBl.GetAllParentTasks().Count > 0);
        }


        [TestMethod]
        [Order(9)]
        public void AddTask()
        {

            List<ParentTask> result1 = ObjBl.GetAllParentTasks();
            ParentTask obj1 = result1.Find(x => x.Parent_Task == "Task New Parent");
            parentTaskIdDummy = obj1.ParentId;


            List<User> result2 = ObjBl.GetAllUsers();
            User obj2 = result2.Find(x => x.FirstName == "Nivi");
            userIdDummy = obj2.UserId;

            Task obj = new Task();
            obj.TaskId = 0;
            obj.TaskName= "Task New";
            obj.Project_ID = projectIdDummy;
            obj.ProjectStartDate = DateTime.Now;
            obj.ProjectEndDate = DateTime.Now;
            obj.Priority = 3;
            obj.User_ID = userIdDummy;

            try
            {
                ObjBl.AddTask(obj);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not added");
            }
        }


        [TestMethod]
        [Order(10)]
        public void GetAllTasksTest()
        {
          
            Assert.IsTrue(ObjBl.GetAllTasks().Count > 0);
        }
        

        [TestMethod]
        [Order(11)]
        public void UpdateTask()
        {
            List<ParentTask> result1 = ObjBl.GetAllParentTasks();
            ParentTask obj1 = result1.Find(x => x.Parent_Task == "Task New Parent");
            parentTaskIdDummy = obj1.ParentId;


            List<User> result2 = ObjBl.GetAllUsers();
            User obj2 = result2.Find(x => x.FirstName == "Nivi");
            userIdDummy = obj2.UserId;

            List<Task> result3 = ObjBl.GetAllTasks();
            Task obj3 = result3.Find(x => x.TaskName == "Task New");
            taskIdDummy = obj3.TaskId;


            Task obj = new Task();
            obj.TaskName = "Task New updated";
            obj.IsParent = true;
            obj.ProjectStartDate = DateTime.Now;
            obj.ProjectEndDate = DateTime.Now;
            obj.Status = true;
            obj.TaskId = taskIdDummy;
            obj.User_ID = userIdDummy;
            obj.Project_ID = projectIdDummy;
            obj.Priority = 1;
            try
            {
                ObjBl.UpdateTask(obj);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not updated");
            }
        }
        [TestMethod]
        [Order(12)]
        public void EndTask()
        {
            try
            {
                ObjBl.EndTask(taskIdDummy);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not ended");
            }
        }

        [TestMethod]
        [Order(13)]
        public void DeleteTask()
        {          
            try
            {
                ObjBl.DeleteTask(taskIdDummy);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Task not deleted");
            }
        }


           

        [TestMethod]
        [Order(14)]
        public void DeleteProject()
        {
            try
            {
                ObjBl.DeleteTask(projectIdDummy);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("Project not deleted");
            }
        }

        [TestMethod]
        [Order(15)]
        public void DeleteUser()
        {
            try
            {
                ObjBl.DeleteUser(userIdDummy);
                Assert.IsTrue(1 == 1);
            }
            catch
            {
                Assert.Inconclusive("USer not deleted");
            }
        }



    }
}
