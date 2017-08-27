using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SimulatedAnnealing
    {
        private bool probability(double energy1, double energy2, double temperature)
        {
            std.uniform_int_distribution<> percent = new std.uniform_int_distribution<>(0, 100);
            // mutation probability P(e1, e2, T) = e^(-c(e1 - e2)/T)
            double chance = 100 * Math.Exp(-problem.constant * (energy1 - energy2) / temperature); // [0, 1] -> [0, 100]
            return percent(GlobalMembersRandom_generator.rg.engine) < chance;
        }
        public SimulatedAnnealing(Problem p, Mutator m) : base(p, m)
        {
        }
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: const Individual solve() const
        public override Individual solve()
        {
                    // actual simulated-annealing algorithm
                    for (int T = problem.iterations; T > 0; --T)
                    {
                        // convert temperature to [0, 100]
                        double temperature = 100.0 * (double)T / problem.iterations;
                        // get neighbor
                        Individual neighbor = mutator.mutate(problem, best);
                        // keep track of best solution
                        if (neighbor > best || probability(problem.normal(best), problem.normal(neighbor), temperature))
                        {
                            // SA swaps in bad solutions with this probability
                            best = neighbor;
                            // terminating condition
                            if (best > problem.goal)
                            {
                                return best;
                            }
                        }
                    }
                }
            }
        }
