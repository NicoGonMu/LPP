
namespace SchoolLib
{
    public class Mark
    {
        Subject subject;
        Student student;
        decimal value;

        public Mark(Subject subject, Student student, decimal value)
        {
            this.subject = subject;
            this.student = student;
            this.value = value;
        }


        public Subject getSubject
        {
            get { return subject; }
            set { subject = value; }
        }

        public Student getStudent
        {
            get { return student; }
            set { student = value; }
        }

        public decimal Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}: {2} in {1}", student.ToString(), subject.ToString(), value.ToString());
        }

    }
}
