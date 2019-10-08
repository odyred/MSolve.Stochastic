# Example
# 1D cantilever beam with uncertain material properties.

The example is a simple one-dimensional cantilever beam where flexibility is modeled through a 1D-Gaussian random field. **MSolve.Stochastic**.
The first code section creates the stochastic model.

```csharp
   public class SolveProblem
    {
        public void Solve()
        {
            const int iterations = 1000;
            const double youngModulus = 2.1e8;

            var domainMapper = new CantileverStochasticDomainMapper(new [] { 0d, 0d, 0d });
            var realizer = new GiannisStructuralStochasticRealizer(youngModulus, domainMapper);
            var evaluator = new StructuralStochasticEvaluator(youngModulus, domainMapper);
            var m = new MonteCarlo(iterations, realizer, evaluator);
            m.Evaluate();
        }
    }```

The model is created using the /CantileverStochasticDomainMapper/ used to describe the mapping from the model geometry to the stochastic domain.

```csharp
    public class CantileverStochasticDomainMapper : IStochasticDomainMapper
    {
        private readonly double[] origin;

        public CantileverStochasticDomainMapper(double[] origin)
        {
            this.origin = origin;
        }

        public double[] Map(double[] problemDomainVector)
        {
            return new[]
            {
                Math.Sqrt(Math.Pow(problemDomainVector[0] - origin[0], 2) +
                          Math.Pow(problemDomainVector[1] - origin[1], 2) +
                          Math.Pow(problemDomainVector[2] - origin[2], 2))
            };
        }
    }
```
