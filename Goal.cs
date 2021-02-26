namespace sq1code
{
    public enum Goal { 
        SolveShape,

        // L1 strategy 1
        SolveL1Quarter123,
        SolveL1Quarter4,

        // L1 strategy 2
        SolveUpDownColor,
        SolveL1,

            /// L3 strategy 1
            SolveL3Cross,
            SolveL3Corner34,

            /// L3 strategy 2
            SolveL3Quarter1,
            SolveL3Quarter2,
            SolveL3Quarter34,

            /// L3 strategy 3
            SolveL3Cell_01,
            SolveL3Cell_2,
            SolveL3Cell_3,
            SolveL3Cell_46,
            SolveL3Cell_57,

            /// L3 strategy 4
            SolveL3QuarterPairs,
            SolveL3QuarterPosition
    };
}