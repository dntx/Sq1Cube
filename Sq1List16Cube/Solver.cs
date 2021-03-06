﻿using System;

namespace Cube.Sq1List16Cube
{
    class Solver
    {
        public static bool SolveEasy(ASolver.Mode mode)
        {
            DateTime startTime = DateTime.Now;
            bool successful = true;

            successful &= DoASolve(Goal.SolveL1Quarter123, mode);
            successful &= DoASolve(Goal.SolveL1Quarter4, mode);
            successful &= DoASolve(Goal.SolveL3Cell01, mode);
            successful &= DoASolve(Goal.SolveL3Cell2, mode);
            successful &= DoASolve(Goal.SolveL3Cell3, mode);
            successful &= DoASolve(Goal.SolveL3Cell46, mode);
            
            Console.WriteLine("total seconds: {0:0.00}, successful: {1}", 
                DateTime.Now.Subtract(startTime).TotalSeconds,
                successful);
            Console.WriteLine();
            return successful;
        }

        public static bool SolveHard(ASolver.Mode mode)
        {
            DateTime startTime = DateTime.Now;
            bool successful = true;

            successful &= DoASolve(Goal.SolveL3Cell57Then, mode, 10^7);
            
            Console.WriteLine("total seconds: {0:0.00}, successful: {1}", 
                DateTime.Now.Subtract(startTime).TotalSeconds,
                successful);
            Console.WriteLine();
            return successful;
        }

        private static bool DoASolve(Goal goal, ASolver.Mode mode) {
            return DoASolve(goal, mode, int.MaxValue);
        }

        private static bool DoASolve(Goal goal, ASolver.Mode mode, int maxStateCount) {
            Console.WriteLine("start {0} ...", goal);
            
            bool successful = DoASolve(new ASolver(mode, maxStateCount), goal);

            Console.WriteLine("end {0}, successful: {1}", goal, successful);
            Console.WriteLine("############################################");
            Console.WriteLine();
            return successful;
        }

        private static bool DoASolve(ASolver solver, Goal goal) {
            ASolver.CreatePredictor createPredictor = (targetCube => new Predictor(targetCube));

            switch (goal)
            {
                // L1 strategy
                case Goal.SolveL1Quarter123:
                    return solver.Solve(Cube.L1Quarter123UnsolvedList, Cube.L1Quarter123Solved, createPredictor);

                case Goal.SolveL1Quarter4:
                    return solver.Solve(Cube.L1Quarter4UnsolvedList, Cube.L1Quarter4Solved, createPredictor);

                // L3 strategy 1
                case Goal.SolveL3Cross:
                    return solver.Solve(Cube.L3CrossUnsolvedList, Cube.L3CrossSolved, createPredictor);

                case Goal.SolveL3CornersThen:
                    throw new NotImplementedException();

                // // L3 strategy 2
                case Goal.SolveL3Corners:
                    throw new NotImplementedException();

                case Goal.SolveL3CrossThen:
                    throw new NotImplementedException();

                // L3 strategy 3
                case Goal.SolveL3Cell01:
                    return solver.Solve(Cube.L3Cell01UnsolvedList, Cube.L3Cell01Solved, createPredictor);

                case Goal.SolveL3Cell2:
                    return solver.Solve(Cube.L3Cell012UnsolvedList, Cube.L3Cell012Solved, createPredictor);

                case Goal.SolveL3Cell3:
                    return solver.Solve(Cube.L3Cell0123UnsolvedList, Cube.L3Cell0123Solved, createPredictor);

                // L3 strategy 3.1
                case Goal.SolveL3Cell46:
                    return solver.Solve(Cube.L3Cell012364, Cube.L3Cell012346, createPredictor);

                case Goal.SolveL3Cell57Then:
                    return solver.Solve(Cube.L3Cell01234765, Cube.Solved, createPredictor);

                // L3 strategy 3.2
                case Goal.SolveL3Cell57:
                    return solver.Solve(Cube.L3Cell012375, Cube.L3Cell012357, createPredictor);

                case Goal.SolveL3Cell46Then:
                    return solver.Solve(Cube.L3Cell01236547, Cube.Solved, createPredictor);

                // scratch
                case Goal.Scratch:
                    return solver.Solve(Cube.Solved, Cube.L1L3Cell08Swapped, createPredictor);
            }
            return false;
        }
    }
}
