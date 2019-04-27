using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBench;
using PM_SPA_BL;
using PM_SPA_Models;

namespace NBenchTest
{
    public class NBenchTest
    {
        BL ObjBl = new BL();


        //[PerfBenchmark(Description = "To check if the operation executes within 5 seconds", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        //[ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]

        ////Performance Method used for adding new Users
        //public void AddUserTest()
        //{
        //    User obj = new User();
        //    obj.UserId = 0;
        //    obj.FirstName = "Nivi";
        //    obj.LastName = "Pauly";
        //    obj.EmployeeId = 3488;
        //    ObjBl.AddUser(obj);
        //}


        //[PerfBenchmark(Description = "To verify if the memory allocated inside the block is more than 64 KB", NumberOfIterations = 3, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        //[MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.SixtyFourKb)]
        ////Performance Method used for updating existing User

        //public void UpdateUserTest()
        //{
        //    List<User> result = ObjBl.GetAllUsers();
        //    User obj1 = result.Find(x => x.FirstName == "Nivi");
        //    int userIdDummy = obj1.UserId;


        //    User obj = new User();
        //    obj.UserId = userIdDummy;
        //    obj.FirstName = "Nivy Updated";
        //    obj.LastName = "Paul";
        //    obj.EmployeeId = 3488;

        //    ObjBl.UpdateUser(obj);
        //}

        //[PerfBenchmark(Description = "To check if the operation executes within 5 seconds", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        //[ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        ////Performance Method used for adding new Projects

        //public void AddProjectTest()
        //{
        //    List<User> result = ObjBl.GetAllUsers();
        //    User obj1 = result.Find(x => x.FirstName == "Nivi");
        //    int userIdDummy = obj1.UserId;

        //    Project obj = new Project();
        //    obj.ProjectName = "Project New";
        //    obj.User_ID = userIdDummy;
        //    obj.ProjectStartDate = DateTime.Now;
        //    obj.ProjectEndDate = DateTime.Now;
        //    obj.Priority = 1;
        //    ObjBl.AddProject(obj);
        //}

        [PerfBenchmark(Description = "To verify if the memory allocated inside the block is more than 64 KB", NumberOfIterations = 3, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.SixtyFourKb)]
        //Performance Method used for updating existing Projects

        public void UpdateProjectTest()
        {
            List<Project> result = ObjBl.GetAllProjects();
            Project obj1 = result.Find(x => x.ProjectName == "Project New");
            int projectIdDummy = obj1.ProjectId;

            Project obj = new Project();
            obj.ProjectId = projectIdDummy;
            obj.ProjectName = "Project updated";
            obj.User_ID = 1;
            obj.ProjectStartDate = DateTime.Now;
            obj.ProjectEndDate = DateTime.Now;
            obj.Priority = 1;
            ObjBl.UpdateProject(obj);
        }


        [PerfBenchmark(Description = "To check if the operation executes within 5 seconds", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        //Performance Method used for Adding new Tasks
        public void AddParentTaskTest()
        {
            ParentTask obj = new ParentTask();
            obj.Parent_Task = "Task New Parent";
            ObjBl.AddParentTask(obj);
        }

        [PerfBenchmark(Description = "To check if the operation executes within 5 seconds", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        //Performance Method used for Adding new Tasks
        public void AddTaskTest()
        {
            List<ParentTask> result1 = ObjBl.GetAllParentTasks();
            ParentTask obj1 = result1.Find(x => x.Parent_Task == "Task New Parent");
            int parentTaskIdDummy = obj1.ParentId;


            List<User> result2 = ObjBl.GetAllUsers();
            User obj2 = result2.Find(x => x.FirstName == "Nivi");
            int userIdDummy = obj2.UserId;

            List<Project> result3 = ObjBl.GetAllProjects();
            Project obj3 = result3.Find(x => x.ProjectName == "Project New");
            int projectIdDummy = obj3.ProjectId;

            Task obj = new Task();
            obj.TaskId = 0;
            obj.TaskName = "Task New";
            obj.Project_ID = projectIdDummy;
            obj.TaskStartDate = DateTime.Now;
            obj.TaskEndDate = DateTime.Now;
            obj.Priority = 3;
            obj.User_ID = userIdDummy;
            ObjBl.AddTask(obj);
        }




        [PerfBenchmark(Description = "To find out the performance of the garbage collector", NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //Performance Method used for Delete Existing Task
        public void DeleteTaskTest()
        {
            List<Task> result3 = ObjBl.GetAllTasks();
            Task obj3 = result3.Find(x => x.TaskName == "Task New");
            int taskIdDummy = obj3.TaskId;

            ObjBl.DeleteTask(taskIdDummy);

        }

        [PerfBenchmark(Description = "To find out the performance of the garbage collector", NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //Performance Method used for Delete Existing Task
        public void DeleteProjectTest()
        {
            List<Project> result3 = ObjBl.GetAllProjects();
            Project obj3 = result3.Find(x => x.ProjectName == "Project New");
            int projectIdDummy = obj3.ProjectId;

            ObjBl.DeleteTask(projectIdDummy);

        }

        [PerfBenchmark(Description = "To find out the performance of the garbage collector", NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //Performance Method used for Delete Existing Task
        public void DeleteUserTest()
        {
            List<User> result2 = ObjBl.GetAllUsers();
            User obj2 = result2.Find(x => x.FirstName == "Nivi");
            int userIdDummy = obj2.UserId;

            ObjBl.DeleteTask(userIdDummy);

        }





    }
}
