using System;

namespace DieRolling
{ /// <summary>
  /// Information about the tossed die
  /// </summary>
    public class DieArgs : EventArgs
    {
        public readonly int DieValue;
        public DieArgs(int DieValue)
        {
            this.DieValue = DieValue;
        }
        public static bool operator ==(DieArgs d1, DieArgs d2)
        {
            return d1.DieValue == d2.DieValue;
        }
        public static bool operator !=(DieArgs d1, DieArgs d2)
        {
            return d1.DieValue != d2.DieValue;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

