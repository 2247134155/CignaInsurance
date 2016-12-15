using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CignaInsurance.Models;

namespace CignaInsurance.ViewModels
{
    public class PlanDetailsModelView
    {
        public IEnumerable<Plan> PlanCollections
        {
            get;
            set;
        }
        public IEnumerable<PlanType> PlanTypeCollections
        {
            get;
            set;
        }
    }
}