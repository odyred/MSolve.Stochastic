using System;

namespace MGroup.Stochastic.Structural.Example
{
    public class CantileverWithUncertainMaterialProperties
    {
        public void Solve()
        {
            const int iterations = 1000;
            const double youngModulus = 2.1e8;

            var domainMapper = new CantileverStochasticDomainMapper(new [] { 0d, 0d, 0d });
            var realizer = new StructuralStochasticRealizer(youngModulus, domainMapper);
            var evaluator = new StructuralStochasticEvaluator(youngModulus, domainMapper);
            var m = new MonteCarlo(iterations, realizer, evaluator);
            m.Evaluate();
        }
    }
}
