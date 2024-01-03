using System;
using com.Halcyon.API.Core.Building;

namespace com.Halcyon.Core.Builder
{
    public class Builder : BuilderAbstract
    {
        private GridBuilder _wallGridBuilder;
        private GridBuilder _objectGridBuilder;
        private Pointer _pointer;

        protected override void OnBuilderGameStateEnabled()
        {
            throw new NotImplementedException();
        }

        protected override void OnBuilderGameStateDisabled()
        {
            throw new NotImplementedException();
        }
    }
}