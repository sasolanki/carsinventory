using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarsInventory.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarsInventory.Web.Controllers.Tests
{
    [TestClass()]
    public class CarsControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            CarsController controller = new CarsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNull(result);
        }
    }
}