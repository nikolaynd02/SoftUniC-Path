namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;

        public Animal()
        {

        }
        public Animal(string species,string diet, double weight,double lenght)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = lenght;
        }


        public override string ToString()
        {
            return $"The {Species} is a {Diet} and weighs {Weight} kg.";
        }


        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public string Diet
        {
            get { return diet; }
            set { diet = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }



    }
}
