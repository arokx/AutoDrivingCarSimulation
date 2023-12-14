using Application.Services;
using Domain.Entities;
using static Domain.Entities.Enums.DomainEnums;

namespace AutoDrivingCarSimulation.Tests
{
    [TestFixture]
    public class CarServiceTests
    {
        [Test]
        public void MoveForward_ShouldUpdatePosition()
        {
            // Arrange
            var carService = new CarService();
            var currentPosition = new Position(1, 2, Direction.North);

            // Act
            var newPosition = carService.MoveForward(currentPosition, 10, 10);

            // Assert
            Assert.That(newPosition.X, Is.EqualTo(1));
            Assert.That(newPosition.Y, Is.EqualTo(3));
            Assert.That(newPosition.Facing, Is.EqualTo(Direction.North));
        }

        [Test]
        public void RotateLeft_ShouldRotateCorrectly()
        {
            // Arrange
            var carService = new CarService();

            // Act
            var newDirection = carService.RotateLeft(Direction.North);

            // Assert
            Assert.That(newDirection, Is.EqualTo(Direction.West));
        }

        [Test]
        public void RotateRight_ShouldRotateCorrectly()
        {
            // Arrange
            var carService = new CarService();

            // Act
            var newDirection = carService.RotateRight(Direction.North);

            // Assert
            Assert.That(newDirection, Is.EqualTo(Direction.East));
        }

        [Test]
        public void MoveForward_ShouldIgnoreOutOfBounds()
        {
            // Arrange
            var carService = new CarService();
            var currentPosition = new Position(0, 0, Direction.South);

            // Act
            var newPosition = carService.MoveForward(currentPosition, 10, 10);

            // Assert
            Assert.That(newPosition.X, Is.EqualTo(0));
            Assert.That(newPosition.Y, Is.EqualTo(0));
            Assert.That(newPosition.Facing, Is.EqualTo(Direction.South));
        }
    }
}