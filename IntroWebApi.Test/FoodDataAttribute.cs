using AutoFixture;
using AutoFixture.Xunit2;

namespace IntroWebApi.Test
{
    internal class FoodDataAttribute : AutoDataAttribute
    {
        public FoodDataAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new FoodSpecimenBuilder());

            return fixture;
        })
        {

        }
    }
}
