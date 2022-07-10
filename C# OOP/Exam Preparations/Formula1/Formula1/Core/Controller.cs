using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly PilotRepository pilotRepository;
        private readonly RaceRepository raceRepository;
        private readonly FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);

            if(pilot == null || pilot.Car != null )
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            carRepository.Remove(car);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);

            if(race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if(pilot == null || pilot.CanRace == false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);

        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if(!(type == "Ferrari" || type == "Williams"))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            if(carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if(type == "Ferrari")
            {
                Ferrari ferrari = new Ferrari(model, horsepower, engineDisplacement);
                carRepository.Add(ferrari);
            }
            else
            {
                Williams williams = new Williams(model, horsepower, engineDisplacement);
                carRepository.Add(williams);
            }

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {

            if(pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            Pilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if(raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            Race race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder result = new StringBuilder();

            foreach(var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                result.AppendLine(pilot.ToString());
            }

            return result.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder result = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(x => x.TookPlace == true))
            {
                result.AppendLine(race.RaceInfo());
            }

            return result.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if(race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if(race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if(race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> pilots = pilotRepository.Models.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            race.TookPlace = true;

            pilots[0].WinRace();

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Pilot { pilots[0].FullName } wins the { raceName } race.");
            result.AppendLine($"Pilot { pilots[1].FullName } is second in the { raceName } race.");
            result.AppendLine($"Pilot { pilots[2].FullName } is third in the { raceName } race.");

            return result.ToString().Trim();
        }
    }
}
