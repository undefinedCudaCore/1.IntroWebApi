using AutoFixture.Kernel;
using IntroWepApi.Domain.Models;

namespace IntroWebApi.Test
{
    internal class FoodSpecimenBuilder : ISpecimenBuilder
    {
        private static readonly List<string> Countries = new List<string>
        {
            "Lithuania", "Latvia", "Estonia", "Poland", "Germany"
        };
        private static readonly Random random = new Random();
        private static int _idCounter = 1;


        public object Create(object request, ISpecimenContext context)
        {
            if (request is Type type && type == typeof(Food))
            {
                int id = _idCounter++;
                string name = $"Name_{id}";
                string country = Countries[random.Next(Countries.Count)];
                var weight = random.NextDouble();

                return new Food(id, name, country, weight);
            }

            return new NoSpecimen();
        }

        //public object Create(object request, ISpecimenContext context)
        //{
        //    if (request is Type type && type == typeof(Food))
        //    {
        //        return new Food(12, "Apple", "Lithuania", 0.5);
        //    }

        //    return new NoSpecimen();
        //}
    }
}
