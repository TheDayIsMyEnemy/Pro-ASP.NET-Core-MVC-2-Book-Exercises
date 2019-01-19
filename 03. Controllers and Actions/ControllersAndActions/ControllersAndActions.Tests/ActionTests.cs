using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void JsonActionMethod()
        {
            //Arrange
            ExampleController controller = new ExampleController();

            // Act
            JsonResult result = controller.Index();

            // Assert
            Assert.Equal(new[] { "Pesho", "Ivan", "Maria" }, result.Value);

        }

        //[Fact]
        //public void ViewSelected()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();
        //
        //    // Act
        //    ViewResult result = controller.ReceiveForm("Peter", "Sofia");
        //
        //    // Assert
        //    Assert.Equal("Result", result.ViewName);
        //}

        //View model objects are assigned to the ViewResult.ViewData.Model property, which means you
        //can test that an action method sends the expected data when the View method is used.
       //[Fact]
       //public void StronglyTypedModelObject()
       //{
       //    // Arrange
       //    ExampleController controller = new ExampleController();
       //
       //    // Act
       //    ViewResult result = controller.Index();
       //
       //    // Assert
       //    Assert.IsType<System.DateTime>(result.ViewData.Model);
       //}
       //
       //[Fact]
       //public void DynamicObjectType()
       //{
       //    //Arrange
       //    ExampleController controller = new ExampleController();
       //    // Act
       //    ViewResult result = controller.Index();
       //    // Assert
       //    Assert.IsType<string>(result.ViewData["Message"]);
       //    Assert.Equal("Hello", result.ViewData["Message"]);
       //    Assert.IsType<System.DateTime>(result.ViewData["Date"]);
       //}
        
        //[Fact]
        //public void LiteralRedirection()
        //{
        //    // Arrange
        //    ExampleController controller = new ExampleController();
        //
        //     // Act
        //    RedirectResult result = controller.Redirect();
        //
        //    // Assert 
        //    Assert.Equal("/Example/Index", result.Url);
        //    Assert.True(result.Permanent);
        //}

        //[Fact]
        //public void RoutedRedirection()
        //{
        //    // Arrange
        //    ExampleController controller = new ExampleController();
        //
        //    // Act
        //    RedirectToRouteResult result = controller.Redirect();
        //
        //    // Assert
        //    Assert.False(result.Permanent);
        //    Assert.Equal("Example", result.RouteValues["controller"]);
        //    Assert.Equal("Index", result.RouteValues["action"]);
        //    Assert.Equal("MyID", result.RouteValues["ID"]);
        //}

        [Fact]
        public void ActionMethodRedirection()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectToActionResult result = controller.Redirect();

            // Asssert
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);
        }
    }   
}
