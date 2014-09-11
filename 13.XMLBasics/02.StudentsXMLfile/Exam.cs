namespace _02.StudentsXMLfile
{
    /// <summary>
    /// Hold all exam data
    /// </summary>
    public struct Exam
    {
        public string ExamName { get; set; }

        public string Tutor { get; set; }

        public int Score { get; set; }

        public override string ToString()
        {
            return string.Format(" Exam: {0} Tutor: {1} Score: {2} ", this.ExamName, this.Tutor, this.Score);
        }
    }
}
