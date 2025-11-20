using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.Business_logic
{
    internal class BL
    {

        private string Student_Name;
        private string Student_Id;
        private int Matric_Marks;
        private int Fsc_Marks;
        private int Ecat_Marks;

        public BL(string Student_Name, string Student_id, int Matric_Marks, int Fsc_Mark, int Ecat_Marks)
        {
            this.Student_Name = Student_Name;
            this.Student_Id = Student_id;
            this.Matric_Marks = Matric_Marks;
            this.Fsc_Marks = Fsc_Mark;
            this.Ecat_Marks = Ecat_Marks;
        }

        public string getSN()
        {
            return Student_Name;
        }
        public string getSI()
        {
            return Student_Id;
        }
        public int getMatric_Marks()
        {
            return Matric_Marks;
        }
        public int getEcat_Marks()
        {
            return Ecat_Marks;
        }
        public int getfssmarks()
        {
            return Fsc_Marks;
        }
        public void setSN(string SN)
        {
            Student_Name = SN;
        }
        public void setSI(string SI)
        {
            Student_Id = SI;
        }
        public void setMM(int MM)
        {
            Matric_Marks = MM;
        }
        public void setFM(int FM)
        {
            Fsc_Marks = FM;
        }
        public void setEM(int EM)
        {
            Ecat_Marks = EM;
        }
    }
}
