using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sondeln_1._0
{
    class position
    {
        
        string _positionName,
               _divisions,
               _comments_position;
               
        double _Xposition,
               _Yposition;

        public string positionName
        {
            get { return _positionName; }
            set { _positionName = value; }
        }

        public string divisions
        {
            get { return _divisions; }
            set { _divisions = value; }
        }


        public string comments_position
        {
            get { return _comments_position; }
            set { _comments_position = value; }
        }

        public double Xposition
        {
            get { return _Xposition; }
            set { _Xposition = value; }
        }

        public double Yposition
        {
            get { return _Yposition; }
            set { _Yposition = value; }
        }



    }
}
