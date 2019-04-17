using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM_SPA_BL;

namespace PM_SPA_Test
{
    [TestClass]
    public class UnitTest1
    {
        BL ObjBl = new BL();
        [TestMethod()]       
        public void GetAllTasksTest()
        {
            int result = ObjBl.GetAllTasks().Count;
            Assert.IsTrue(result > 0);
        }

    }
}
