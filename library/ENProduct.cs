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
        private int _ammount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Code;
        public string Name;
        public int Ammount;
        public float Price;
        public int Category;
        public DateTime CreationDate;

        public ENProduct(string code, string name, int ammount, float price, int category, DateTime creationDate)
        {
            _code = code;
            _name = name;
            _ammount = ammount;
            _price = price;
            _category = category;
            _creationDate = creationDate;
            Code = code;
            Name = name;
            Ammount = ammount;
            Price = price;
            Category = category;
            CreationDate = creationDate;
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

        public bool Read() {             if (new CADProduct().Read(this))
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

        public bool readNext()
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

        public bool readPrev()
        {
            if (new CADProduct().ReadPrevious(this))
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
