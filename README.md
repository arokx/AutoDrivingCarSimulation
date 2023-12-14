# Auto Driving Car Simulation

Welcome to the Auto Driving Car Simulation project! This simulation allows you to test the movement of an auto-driving car on a rectangular field by providing a series of commands.

## Introduction

The Auto Driving Car Simulation project consists of three main components:

1. **Domain**: Defines the domain entities used in the simulation, such as the `Direction` enum and the `Position` class.

2. **Application**: Contains the `ICarService` interface and its implementation, the `CarService,SimulationService` classes. This layer handles the core logic of moving the car, rotating, and validating positions.

3. **Presentation**: The entry point for running the simulation is in the `Program` class within this layer. It interacts with the `ICarService` to execute the simulation based on the provided commands.
## Introduction
## Project Structure

AutoDrivingCarSimulation
```plaintext
│
├── AutoDrivingCarSimulation.Domain
│   └── Position.cs
│
├── AutoDrivingCarSimulation.Application
│   ├── ICarService.cs
│   └── CarService.cs
|   └── SimulationService.cs
│
├── AutoDrivingCarSimulation.Presentation
│   └── Program.cs
│
└── AutoDrivingCarSimulation.Tests
    └── CarServiceTests.cs
```    
## How to run
1. Clone the repository

2. Build the solution

3. Run the simulation

## Testing
Unit tests are available in the AutoDrivingCarSimulation Tests folder

## Contributing
If you would like to contribute to the project, you can contribute.
