using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sondeln_1._0
{
    class Finding
    {
        int _id,
            _number;
        string _name,
               _positionName,
               _discription,
               _nation,
               _comments_findings,
               _storage_box,
               _picture;
        double _item_pos_x, 
               _item_pos_y;
        bool _exposed;
        
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string positionName
        {
            get { return _positionName; }
            set { _positionName = value; }
        }

        public string discription
        {
            get { return _discription; }
            set { _discription = value; }
        }

        public string nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        public int number
        {
            get { return _number; }
            set { _number = value; }
        }

        public double item_pos_x
        {
            get { return _item_pos_x; }
            set { _item_pos_x = value; }
        }

        public double item_pos_y
        {
            get { return _item_pos_y; }
            set { _item_pos_y = value; }
        }

        public string comments_findings
        {
            get { return _comments_findings; }
            set { _comments_findings = value; }
        }

        public bool exposed
        {
            get { return _exposed; }
            set { _exposed = value; }
        }

        public string storage_box
        {
            get { return _storage_box; }
            set { _storage_box = value; }
        }
        
        public string picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

    }
}
