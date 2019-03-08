using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistration.Entities
{
    class School
    {
        const int LARGEST_CLASS_CARDINALITY = 5;

        Dictionary<int, List<Student>> _classes;

        public School(): this(LARGEST_CLASS_CARDINALITY)
        {}

        public School(int classCardinality)
        {
            _classes = new Dictionary<int, List<Student>>();

            for (int i = 1; i <= classCardinality; i++)
            {
                _classes[i] = new List<Student>();
            }
        }

        public bool IsClassCardinalityValid(int classCardinality)
        {
            return classCardinality >= 1 &&
                   classCardinality <= LARGEST_CLASS_CARDINALITY;
        }

        public bool addToClass(int classNum, Student student)
        {
            bool result = IsClassCardinalityValid(classNum) &&
                         student != null && student.IsValid();

            if (result)
            {
                _classes[classNum].Add(student);
            }

            return result;
        }

        public bool removeFromClass(int classNum, Student student)
        {
            bool result = IsClassCardinalityValid(classNum) &&
                         student != null && student.IsValid();

            if (result)
            {
                _classes[classNum].Add(student);
            }

            return result;
        }

        public List<int> getClassOfStudent()
        {
            return 1;
        }
    }
}
