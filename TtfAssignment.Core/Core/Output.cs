using TtfAssignment.Core.Enums;
using TtfAssignment.Core.Interfaces;

namespace TtfAssignment.Core.Core
{
    public class Output: IOutputs
    {
        public ResultEnum X { get; set; }
        public decimal Y { get; set; }
    }
}
