using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Services.Services;

namespace travelRoute_test.TravelRouteServiceT;

public class TravelRouteServiceTests
{
    [Fact]
    [Trait("Category", "Unit")]
    public async Task Insert_Should_Return_Ok()
    {
        //Arrange
        var requestInsertTravelRoute = new RequestInsertTravelRouteDto{ Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>()};
        var travelRoute = new TravelRoute(requestInsertTravelRoute);

        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.InsertAsync(travelRoute)).Returns(Task.CompletedTask);

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var taskResult =  travelRouteService.InsertAsync(requestInsertTravelRoute);

        //Assert
        Assert.Equal(Task.CompletedTask, taskResult);


    }
    [Fact]
    [Trait("Category", "Unit")]
    public async Task Insert_Should_Return_Exception_On_Insert()
    {
        //Arrange
        var requestInsertTravelRoute = new RequestInsertTravelRouteDto { Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };
        var travelRoute = new TravelRoute(requestInsertTravelRoute);

        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.InsertAsync(It.IsAny<TravelRoute>())).Throws(new Exception());

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);


        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.InsertAsync(requestInsertTravelRoute));


    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task FindAll_Should_Return_List_TravelRoute()
    {
        //Arrange        
        var taskResult = Task.FromResult(new List<TravelRoute>
        {
            new TravelRoute {Id = It.IsAny<int>(),Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>()}
        }.AsEnumerable());


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindAllAsync()).Returns(taskResult);

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var result = await travelRouteService.FindAllAsync();

        //Assert
        Assert.NotEmpty(result);
        Assert.Equal(taskResult.Result, result);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task FindAll_Should_Return_List_TravelRoute_Empty_Ok()
    {
        //Arrange        
        var taskResult = Task.FromResult(new List<TravelRoute>().AsEnumerable());


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindAllAsync()).Returns(taskResult);

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var result = await travelRouteService.FindAllAsync();

        //Assert
        Assert.Empty(result);
        Assert.Equal(taskResult.Result, result);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task FindAll_Should_Return_Exception_On_Search()
    {
        //Arrange        
        var taskResult = Task.FromResult(new List<TravelRoute>().AsEnumerable());


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindAllAsync()).ThrowsAsync(new Exception());

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.FindAllAsync());
    }


    [Fact]
    [Trait("Category", "Unit")]
    public async Task FindById_Should_Return_TravelRoute()
    {
        //Arrange        
        var taskResult = Task.FromResult(new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() });


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Returns(taskResult);

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var result = await travelRouteService.FindByIdAsync(It.IsAny<int>());

        //Assert
        Assert.Equal(result, taskResult.Result);
        Assert.NotNull(result);
    }


    [Fact]
    [Trait("Category", "Unit")]
    public async Task FindById_Should_Return_Exception_On_Return_Object_Null()
    {
        //Arrange        
        var taskResult = Task.FromResult(new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() });
        

        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult((TravelRoute?)null));

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var result = travelRouteService.FindByIdAsync(It.IsAny<int>());

        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.FindByIdAsync(1));
    }
    [Fact]
    [Trait("Category", "Unit")]
    public async Task FindById_Should_Return_Exception_On_Search()
    {
        //Arrange        
        var taskResult = Task.FromResult(new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() });


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Throws(new Exception());

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var result = travelRouteService.FindByIdAsync(It.IsAny<int>());

        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.FindByIdAsync(1));
    }


    [Fact]
    [Trait("Category", "Unit")]
    public async Task Delete_Should_Return_Ok()
    {
        //Arrange        
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(travelRoute));
        travelRouteRepositoryMock.Setup(m => m.DeleteAsync(travelRoute)).Returns(Task.CompletedTask);

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var result = travelRouteService.Delete(It.IsAny<int>());

        //Assert
        Assert.Equal(result, Task.CompletedTask);
       
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task Delete_Should_Return_Exception_On_TravelRoute_Return_Null()
    {
        //Arrange        
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };

        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult((TravelRoute?)null));        

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var result = travelRouteService.Delete(It.IsAny<int>());

        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.Delete(1));

    }
    [Fact]
    [Trait("Category", "Unit")]
    public async Task Delete_Should_Return_Exception_On_search_Id()
    {
        //Arrange        
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };

        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Throws(new Exception());

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Act
        var result = travelRouteService.Delete(It.IsAny<int>());

        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.Delete(1));

    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task Delete_Should_Return_Exception_On_Delete()
    {
        //Arrange        
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };

        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(travelRoute));
        travelRouteRepositoryMock.Setup(m => m.DeleteAsync(travelRoute)).ThrowsAsync(new Exception());
        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);


        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.Delete(1));

    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task Update_Should_Return_Ok()
    {
        //Arrange
        int id = It.IsAny<int>();
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };

        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(travelRoute));
        travelRouteRepositoryMock.Setup(m => m.UpdateAsync(travelRoute)).Returns(Task.CompletedTask);

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        
        //Act
        var result = travelRouteService.UpdateAsync(id, travelRoute);


        //Assert
        Assert.Equal(Task.CompletedTask, result);
        Assert.Equal(id, travelRoute.Id);
    }
    [Fact]
    [Trait("Category", "Unit")]
    public async Task Update_Should_Return_Exception_On_TravelRoute_Null()
    {
        //Arrange
        int id = It.IsAny<int>();
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };
        TravelRoute route = null;


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(route));

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.UpdateAsync(id, travelRoute));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task Update_Should_Return_Exception_On_Search_Id()
    {
        //Arrange
        int id = It.IsAny<int>();
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };
        TravelRoute route = null;


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Throws(new Exception());

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.UpdateAsync(id, travelRoute));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task Update_Should_Return_Exception_On_Update()
    {
        //Arrange
        int id = It.IsAny<int>();
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };
        TravelRoute route = null;


        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        travelRouteRepositoryMock.Setup(m => m.FindByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(travelRoute));
        travelRouteRepositoryMock.Setup(m => m.UpdateAsync(travelRoute)).Throws(new Exception());

        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Assert
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.UpdateAsync(id, travelRoute));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task Update_Should_Return_Exception_On_Verify_Id()
    {
        //Arrange
        int id = 1;
        var travelRoute = new TravelRoute { Id = It.IsAny<int>(), Origin = It.IsAny<string>(), Destination = It.IsAny<string>(), Price = It.IsAny<int>() };

        var travelRouteRepositoryMock = new Mock<ITravelRouteRepository>();
        var travelRouteService = new TravelRouteService(travelRouteRepositoryMock.Object);

        //Assert
        Assert.NotEqual(id, travelRoute.Id);
        await Assert.ThrowsAsync<Exception>(async () => await travelRouteService.UpdateAsync(id, travelRoute));
        
    }

}
