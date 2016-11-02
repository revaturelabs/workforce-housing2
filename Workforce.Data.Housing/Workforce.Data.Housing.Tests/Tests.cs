using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Data.Housing.Domain;
using Xunit;

namespace Workforce.Data.Housing.Tests
{
    public class Tests
    {
    AccessHelper ah = new AccessHelper();
    Apartment apt = new Apartment()
    {
      HotelID = 1,
      RoomNumber = 1,
      CurrentCapacity = 5,
      MaxCapacity = 6,
      GenderID = 1,
      ActiveBit = true,
    };
    HousingComplex hc = new HousingComplex()
    {
      HotelID = 100,
      Name = "some name",
      Address = "some address",
      IsHotel = false,
      PhoneNumber = "7325555555",
      ActiveBit = true
    };
    HousingData hd = new HousingData()
    {
      AssociateID = 100,
      MoveInDate = DateTime.Today,
      MoveOutDate = DateTime.Today
    };
    Status status = new Status()
    {
      StatusID = 100,
      StatusColor = "red",
      StatusMessage = "mess",
      ActiveBit = true
    };
    #region gets
    [Fact]
    public void Test_GetApartments()
    {
      var data = new List<Apartment>
            {
                apt
            }.AsQueryable();

      var mockSet = new Mock<DbSet<Apartment>>();
      mockSet.As<IQueryable<Apartment>>().Setup(m => m.Provider).Returns(data.Provider);
      mockSet.As<IQueryable<Apartment>>().Setup(m => m.Expression).Returns(data.Expression);
      mockSet.As<IQueryable<Apartment>>().Setup(m => m.ElementType).Returns(data.ElementType);
      mockSet.As<IQueryable<Apartment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

      var mockContext = new Mock<WorkforceHousingDB_Entities>();
      mockContext.Setup(c => c.Apartment).Returns(mockSet.Object);

      var access = new AccessHelper(mockContext.Object);
      var apts = access.GetApartments();

      Assert.Equal(1, apts.Count);
      Assert.Equal(6, apts[0].MaxCapacity);
      Assert.Equal(5, apts[0].CurrentCapacity);
    }
    [Fact]
    public void Test_GetHousingComplexes()
    {
      var data = new List<HousingComplex>
            {
                hc
            }.AsQueryable();

      var mockSet = new Mock<DbSet<HousingComplex>>();
      mockSet.As<IQueryable<HousingComplex>>().Setup(m => m.Provider).Returns(data.Provider);
      mockSet.As<IQueryable<HousingComplex>>().Setup(m => m.Expression).Returns(data.Expression);
      mockSet.As<IQueryable<HousingComplex>>().Setup(m => m.ElementType).Returns(data.ElementType);
      mockSet.As<IQueryable<HousingComplex>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

      var mockContext = new Mock<WorkforceHousingDB_Entities>();
      mockContext.Setup(c => c.HousingComplex).Returns(mockSet.Object);

      var access = new AccessHelper(mockContext.Object);
      var housingComplexes = access.GetComplexes();

      Assert.Equal(1, housingComplexes.Count);
      Assert.Equal("some name", housingComplexes[0].Name);
      Assert.Equal("some address", housingComplexes[0].Address);
    }
    [Fact]
    public void Test_GetHousingData()
    {
      var data = new List<HousingData>
            {
                hd
            }.AsQueryable();

      var mockSet = new Mock<DbSet<HousingData>>();
      mockSet.As<IQueryable<HousingData>>().Setup(m => m.Provider).Returns(data.Provider);
      mockSet.As<IQueryable<HousingData>>().Setup(m => m.Expression).Returns(data.Expression);
      mockSet.As<IQueryable<HousingData>>().Setup(m => m.ElementType).Returns(data.ElementType);
      mockSet.As<IQueryable<HousingData>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

      var mockContext = new Mock<WorkforceHousingDB_Entities>();
      mockContext.Setup(c => c.HousingData).Returns(mockSet.Object);

      var access = new AccessHelper(mockContext.Object);
      var housingData = access.GetHousingData();

      Assert.Equal(1, housingData.Count);
      Assert.Equal(DateTime.Today, housingData[0].MoveInDate);
      Assert.Equal(DateTime.Today, housingData[0].MoveOutDate);
    }
    [Fact]
    public void Test_GetStatus()
    {
      var data = new List<Status>
            {
                status
            }.AsQueryable();

      var mockSet = new Mock<DbSet<Status>>();
      mockSet.As<IQueryable<Status>>().Setup(m => m.Provider).Returns(data.Provider);
      mockSet.As<IQueryable<Status>>().Setup(m => m.Expression).Returns(data.Expression);
      mockSet.As<IQueryable<Status>>().Setup(m => m.ElementType).Returns(data.ElementType);
      mockSet.As<IQueryable<Status>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

      var mockContext = new Mock<WorkforceHousingDB_Entities>();
      mockContext.Setup(c => c.Status).Returns(mockSet.Object);

      var access = new AccessHelper(mockContext.Object);
      var statuses = access.GetStatuses();

      Assert.Equal(1, statuses.Count);
      Assert.Equal("mess", statuses[0].StatusMessage);
      Assert.Equal("red", statuses[0].StatusColor);
    }
    #endregion
    #region inserts
    [Fact]
    public void Test_InsertApartments()
    {
      var mockSet = new Mock<DbSet<Apartment>>();

      var mockContext = new Mock<WorkforceHousingDB_Entities>();
      mockContext.Setup(m => m.Apartment).Returns(mockSet.Object);

      var access = new AccessHelper(mockContext.Object);
      access.InsertApartment(apt);

      mockSet.Verify(m => m.Add(It.IsAny<Apartment>()), Times.Once());
      mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
    [Fact]
    public void Test_InsertHousingComplex()
    {
      var mockSet = new Mock<DbSet<HousingComplex>>();

      var mockContext = new Mock<WorkforceHousingDB_Entities>();
      mockContext.Setup(m => m.HousingComplex).Returns(mockSet.Object);

      var access = new AccessHelper(mockContext.Object);
      access.InsertHousingComplex(hc);

      mockSet.Verify(m => m.Add(It.IsAny<HousingComplex>()), Times.Once());
      mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
    [Fact]
    public void Test_InsertHousingData()
    {
      var mockSet = new Mock<DbSet<HousingData>>();

      var mockContext = new Mock<WorkforceHousingDB_Entities>();
      mockContext.Setup(m => m.HousingData).Returns(mockSet.Object);

      var access = new AccessHelper(mockContext.Object);
      access.InsertHousingData(hd);

      mockSet.Verify(m => m.Add(It.IsAny<HousingData>()), Times.Once());
      mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
    [Fact]
    public void Test_InsertStatus()
    {
      var mockSet = new Mock<DbSet<Status>>();

      var mockContext = new Mock<WorkforceHousingDB_Entities>();
      mockContext.Setup(m => m.Status).Returns(mockSet.Object);

      var access = new AccessHelper(mockContext.Object);
      access.InsertStatus(status);

      mockSet.Verify(m => m.Add(It.IsAny<Status>()), Times.Once());
      mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
    #endregion

    #region updates
    [Fact]
    public void Test_UpdateApartments()
    {
      Assert.True(ah.UpdateApartment(apt));
    }
    [Fact]
    public void Test_UpdateHousingComplex()
    {
      Assert.True(ah.UpdateHousingComplex(hc));
    }
    [Fact]
    public void Test_UpdateHousingData()
    {
      Assert.True(ah.UpdateHousingData(hd));
    }
    [Fact]
    public void Test_UpdateStatus()
    {
      Assert.True(ah.UpdateStatus(status));
    }
    #endregion
    #region deletes
    [Fact]
    public void Test_DeleteApartments()
    {
      Assert.True(ah.DeleteApartment(apt));
    }
    [Fact]
    public void Test_DeleteHousingComplex()
    {
      Assert.True(ah.DeleteHousingComplex(hc));
    }
    [Fact]
    public void Test_DeleteHousingData()
    {
      Assert.True(ah.DeleteHousingData(hd));
    }
    [Fact]
    public void Test_DeleteStatus()
    {
      Assert.True(ah.DeleteStatus(status));
    }
    #endregion
  }
}
