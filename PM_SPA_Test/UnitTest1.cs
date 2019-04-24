using System;
using PM_SPA_BL;
using NUnit.Framework;

namespace PM_SPA_Test
{
    [TestFixture]
    public class UnitTest1
    {
        BL ObjBl = new BL();
       [Test]    
        public void GetAllTasksTest()
        {
            int result = ObjBl.GetAllTasks().Count;
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void GetAllTasks()
        {
            int result = ObjBl.GetAllTasks().Count;
            Assert.IsTrue(result > 0);
        }


    }
}
