using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using System.Collections;

namespace Dal.Services
{
    public class DalExpendituresService : IDalExpenditures
    {
        dbcontext data;

        public DalExpendituresService(dbcontext data)
        {
            this.data = data;
        }
        public List<Expenditure> GetExpenditures()=>
             data.Expenditures.ToList();
        

        public Expenditure UpdateExpenditure(Expenditure Expenditure, int id)
        {
            int index = GetExpenditures().ToList().FindIndex(e => e.Id == id);
            GetExpenditures()[index] = Expenditure;
            data.SaveChanges();
            return GetExpenditures()[index];
        }

        public bool Create(Expenditure expenditure)
        {
            try
            {
                data.Expenditures.Add(expenditure);
                try
                {
               
                    data.SaveChanges();
                }
                catch (Exception ex) {
                    data.Expenditures.Local.Remove(expenditure);
                    return false;
                }
               
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("expenditure not create");
            }
        }


        public void RemoveExpenditure(int id)
        {
            try
            {
                var e = GetExpenditures().ToList().Find(e => e.Id == id);
                data.Expenditures.Remove(e);
                data.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Expenditure didnt removed");

            }

        }

       
    }
}
