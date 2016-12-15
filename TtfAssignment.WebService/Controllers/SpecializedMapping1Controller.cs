using TtfAssignment.Core.Strategies;

namespace TtfAssignment.WebService.Controllers
{
    public class SpecializedMapping1Controller : BaseMappingController
    {
        /// <summary>
        /// Returns X and Y for the specefied query
        /// A && B && !C => X = S
        /// A && B && C => X = R
        /// !A && B && C => X =T
        /// [other] => [error]
        ///
        /// X = S => Y = D + (D * E / 100)
        /// X = R => Y = 2D + (D * E / 100)
        /// X = T => Y = D - (D * F / 100)
        /// </summary>
        public SpecializedMapping1Controller()
        {
            Mapping = new SpecializedMapping1();
        }
    }
}