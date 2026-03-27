using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            _code = code;
            _name = name;
            _amount = amount;
            _price = price;
            _category = category;
            _creationDate = creationDate;
        }

        public ENProduct() { }

        public bool Create()
        {
            if (new CADProduct().Create(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update()
        {
            if (new CADProduct().Update(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete()
        {
            if (new CADProduct().Delete(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Read() 
        {             
            if (new CADProduct().Read(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReadFirst()
        {
            if (new CADProduct().ReadFirst(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReadNext()
        {
            if (new CADProduct().ReadNext(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReadPrev()
        {
            if (new CADProduct().ReadPrev(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
