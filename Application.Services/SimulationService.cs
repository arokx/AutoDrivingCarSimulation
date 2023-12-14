using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Enums.DomainEnums;

namespace Application.Services
{
    public class SimulationService
    {
        private readonly ICarService _carService;

        public SimulationService(ICarService carService)
        {
            _carService = carService;
        }

        public Position RunSimulation(int fieldWidth, int fieldHeight, int initialX, int initialY, Direction initialFacing, string commands)
        {
            var currentPosition = new Position(initialX, initialY, initialFacing);

            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'F':
                        currentPosition = _carService.MoveForward(currentPosition, fieldWidth, fieldHeight);
                        break;
                    case 'L':
                        currentPosition = new Position(currentPosition.X, currentPosition.Y, _carService.RotateLeft(currentPosition.Facing));
                        break;
                    case 'R':
                        currentPosition = new Position(currentPosition.X, currentPosition.Y, _carService.RotateRight(currentPosition.Facing));
                        break;
                }
            }

            return currentPosition;
        }
    }
}
