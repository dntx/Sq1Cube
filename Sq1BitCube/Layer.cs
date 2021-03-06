using System.Collections.Generic;

namespace Cube.Sq1BitCube
{
    class Layer : Cells {
        public Layer(uint code) : base(code) {
            Normalize();
        }

        private void Normalize() {
            uint minCell = uint.MaxValue;
            int minIndex = -1;
            uint code = Code;
            for (int i = 7; i >= 0; i--) {
                uint cell = (code & 0xF);
                if (cell % 2 == 0 && cell < minCell) {
                    minCell = cell;
                    minIndex = i;
                }
                code >>= 4;
            }
            Code = RotateCodeLeft(Code, minIndex);
        }

        public Dictionary<int, Cells> GetDivisions(int maxIndex) {
            var divisions = new Dictionary<int, Cells>();
            for (int index = 0; index < maxIndex; index++) {
                Cells division = new Cells(RotateCodeLeft(Code, index));
                divisions.Add(index, division);
            }
            return divisions;
        }

        public static Layer WhiteL1 = new Layer(0x89ABCDEF);
    }
}