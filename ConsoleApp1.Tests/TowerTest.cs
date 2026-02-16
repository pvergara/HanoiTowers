using System.Linq;
using JetBrains.Annotations;
using Xunit;

namespace ConsoleApp1.Tests;

[TestSubject(typeof(Tower))]
public class TowerTest
{
    [Fact]
    public void WhenICreateATowerTheListSizeWillBe5Length()
    {
        //Arrange
        //Act
        var tower = new Tower();
        //Assertions
        Assert.Equal(5, tower.GetValueAsList().Count);
    }

    [Fact]
    public void HowToAddADisk()
    {
        //Arrange
        var tower = new Tower();
        //Act
        tower.Add(5);
        //Assertions
        Assert.Equal(5, tower.GetValueAsList().Count);

        Assert.Equal(0, tower.GetValueAsList().First());
        Assert.Equal(5, tower.GetValueAsList().Last());
    }

    [Fact]
    public void HowToAddASecondDiskHappyPath()
    {
        //Arrange
        var tower = new Tower();
        tower.Add(5);
        //Act
        var result = tower.Add(4);
        //Assertions
        var valueAsList = tower.GetValueAsList();
        Assert.True(result);
        Assert.Equal(2, valueAsList.Count(i => i != 0));
        Assert.Equal(5, valueAsList.Last());
        Assert.Equal(4, valueAsList[^2]);
    }

    [Fact]
    public void HowToAddASecondDiskSadPath()
    {
        //Arrange
        var tower = new Tower();
        tower.Add(4);
        //Act
        var result = tower.Add(5);
        //Arrange
        var valueAsList = tower.GetValueAsList();
        Assert.False(result);
        Assert.Equal(1, valueAsList.Count(i => i != 0));
        Assert.Equal(4, valueAsList.Last());
        Assert.Equal(0, valueAsList[^2]);
    }

    [Fact]
    public void WhatIfTheUserTriesToAddMoreThan5Disks()
    {
        //Arrange
        var tower = new Tower();
        tower.Add(5);
        tower.Add(4);
        tower.Add(3);
        tower.Add(2);
        tower.Add(1);

        tower.Add(0);
        tower.Add(0);
        tower.Add(0);

        //Act
        tower.Add(0);
        //Arrange
        var valueAsList = tower.GetValueAsList();
        Assert.Equal(0, valueAsList.Count(i => i == 0));
        Assert.Equal([1, 2, 3, 4, 5], valueAsList);
    }

    [Fact]
    public void HowToExtractAPreviouslyAddedDiskHappyPath()
    {
        //Arrange
        var tower = new Tower();
        tower.Add(5);
        //Act
        var result = tower.Extract();
        //Arrange
        var valueAsList = tower.GetValueAsList();
        Assert.Equal(5, result);
        Assert.Equal([0, 0, 0, 0, 0], valueAsList);
    }
    
    [Fact]
    public void HowToExtractAPreviouslyAddedTwoDisksHappyPath()
    {
        //Arrange
        var tower = new Tower();
        tower.Add(5);
        tower.Add(4);
        //Act
        var result = tower.Extract();
        //Arrange
        var valueAsList = tower.GetValueAsList();
        Assert.Equal(4, result);
        Assert.Equal([0, 0, 0, 0, 5], valueAsList);
    }
    
        
    [Fact]
    public void HowToExtractAPreviouslyAddedAllDisksHappyPath()
    {
        //Arrange
        var tower = new Tower();
        tower.Add(5);
        tower.Add(4);
        tower.Add(3);
        tower.Add(2);
        tower.Add(1);
        //Act
        var result = tower.Extract();
        //Arrange
        var valueAsList = tower.GetValueAsList();
        Assert.Equal(1, result);
        Assert.Equal([0, 2, 3, 4, 5], valueAsList);
    }
}