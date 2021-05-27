using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int minHorsePower;
        private int maxHorsePower;
        private int horsePower;
        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;

        }



        public string Model
        {
            get { return this.model; }
            private set
            {
                //o	If the model is null, whitespace or less than 4 symbols, throw an ArgumentException with message "Model {model} cannot be less than 4 symbols."
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {model} cannot be less than 4 symbols.");
                }
                this.model = value;
            }
        }


        public int HorsePower
        {
            get
            {
                return this.horsePower ;

            }
            private set
            {
                if (value > this.minHorsePower && value < this.maxHorsePower)
                {
                    this.horsePower = value;
                }
                else
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
            }
        }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            //cubic centimeters / horsepower * laps
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
