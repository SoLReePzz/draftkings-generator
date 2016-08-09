using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings
{
    public class Player
    {
        private string _name;
        private string _position;
        private int _cost;

        public string Name
        {
            get { return _name; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                _name = value; }
        }

        public string Position
        {
            get { return _position; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                _position = value; }
        }

        public int Cost
        {
            get { return _cost; }
            set {
                if (value == 0)
                    throw new ArgumentNullException();
                _cost = value; }
        }
    }
}
