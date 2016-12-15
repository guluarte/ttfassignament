using System;
using System.Web.Http;
using TtfAssignment.Core.Core;
using TtfAssignment.Core.Interfaces;
using TtfAssignment.Core.Strategies;

namespace TtfAssignment.WebService.Controllers
{
    /// <summary>
    /// Returns X and Y for the specefied query
    /// </summary>
    public class BaseMappingController: ApiController
    {

        protected IMapping Mapping;

        public BaseMappingController()
        {
            Mapping = new BaseMapping();
        }

        /// <summary>
        /// Returns X and Y for the specefied query
        /// A && B && !C => X = S
        /// A && B && C => X = R
        /// !A && B && C => X =T
        /// [other] => [error]
        ///
        /// X = S => Y = D + (D * E / 100)
        /// X = R => Y = D + (D * (E - F) / 100)
        /// X = T => Y = D - (D * F / 100)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public object Get(bool a, bool b, bool c, int d, int e, int f)
        {
            var output = Mapping.Calculate(new Input()
            {
                A = a,
                B = b,
                C = c,
                D = d,
                E = e,
                F = f
            });

            if (output == null)
            {
                throw new Exception("[error]");
            }

            return new
            {
                X = output.X.ToString(),
                Y = output.Y
            };
        }
        
    }
}
