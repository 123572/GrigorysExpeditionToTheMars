using MartianRobots.Domain.Models;

namespace MartianRobots.Test.UnitTests.Domain;

[TestFixture]
public class CoordinatesTest
{
    [Test]
    [TestCase(1, 2, 1, 1, 2, 3)]
    [TestCase(0, 1, 1, 0, 1, 1)]

    public void SumTest(int xA, int yA, int xB, int yB, int xR, int yR)
    {
        var result = new Coordinates(xA, yA) + new Coordinates(xB, yB);

        Assert.That(new Coordinates(xR, yR), Is.EqualTo(result));   
    }

    [Test]
    [TestCase(1, 2, 2, 1)]
    [TestCase(2, 3, 3, 2)]
    [TestCase(3, 4, 4, 3)]
    [TestCase(1, 0, 0, 1)]
    public void EqualsTest(int x, int y, int x1, int y1)
    {
        var trueArrange = new Coordinates(x, y);
        var trueexpected = new Coordinates(x, y);

        var falseArrange = new Coordinates(x1, y1);
        var falseexpected = new Coordinates(y1, x1);

        Assert.IsTrue(trueArrange == trueexpected);
        Assert.IsFalse(falseArrange == falseexpected);
    }
}
