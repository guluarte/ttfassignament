using TtfAssignment.Core.Core;
using TtfAssignment.Core.Enums;
using TtfAssignment.Core.Interfaces;

namespace TtfAssignment.Core.Strategies
{
    public class BaseMapping : IMapping
    {
        public virtual IOutputs Calculate(IInputs i)
        {
            if (i.A && i.B && !i.C)
            {
                return new Sstrategy().Calculate(i);
            }

            if (i.A && i.B && i.C)
            {
                return new Rstrategy().Calculate(i);
            }

            if (!i.A && i.B && i.C)
            {
                return new Tstrategy().Calculate(i);
            }

            return null;
        }
    }

    public class SpecializedMapping1 : BaseMapping
    {
        public override IOutputs Calculate(IInputs i)
        {
            if (i.A && i.B && i.C)
            {
                return new RstrategySpecialized().Calculate(i);
            }

            return base.Calculate(i);
        }
    }

    public class SpecializedMapping2 : BaseMapping
    {
        public override IOutputs Calculate(IInputs i)
        {
            if (i.A && i.B && !i.C)
            {
                return new Tstrategy().Calculate(i);
            }

            if (i.A && !i.B && i.C)
            {
                return new SstrategySpecialized().Calculate(i);
            }

            return base.Calculate(i);
        }
    }

    public class Sstrategy : IMapping
    {
        public IOutputs Calculate(IInputs i)
        {
            var output = new Output
            {
                X = ResultEnum.S,
                Y = i.D + (i.D * i.E / 100m)
            };
            return output;
        }
    }


    public class SstrategySpecialized : Rstrategy
    {
        public override IOutputs Calculate(IInputs i)
        {
            var output = new Output
            {
                X = ResultEnum.S,
                Y = i.F + i.D + (i.D * i.E / 100m)
            };
            return output;
        }
    }

    public class Rstrategy : IMapping
    {
        public virtual IOutputs Calculate(IInputs i)
        {
            var output = new Output
            {
                X = ResultEnum.R,
                Y = i.D + (i.D * (i.E - i.F)/ 100m)
            };
            return output;
        }
    }

    public class RstrategySpecialized : Rstrategy
    {
        public override IOutputs Calculate(IInputs i)
        {
            var output = new Output
            {
                X = ResultEnum.R,
                Y = (2 * i.D) + (i.D * i.E / 100m)
            };
            return output;
        }
    }

    public class Tstrategy : IMapping
    {
        public IOutputs Calculate(IInputs i)
        {
            var output = new Output
            {
                X = ResultEnum.T,
                Y = i.D - (i.D * i.F /100m)
            };
            return output;
        }
    }



}
