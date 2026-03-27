using System.Collections.Generic;

namespace library
{
    public class ENCategory
    {
        public int Id;
        public string Name;

        public ENCategory()
        {
        }

        public ENCategory(int id)
        {
            Id = id;
        }

        public ENCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool Read()
        {
            return new CADCategory().read(this);
        }

        public List<ENCategory> ReadAll()
        {
            return new CADCategory().readAll();
        }
    }
}
