using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CignaInsurance.Models;
namespace CignaInsurance.ViewModels
{
    public class ClaimDetailsViewModel
    {
        public IEnumerable<Agent> AgentCollection
        {
            get;
            set;
        }
        public IEnumerable<Claim> ClaimsCollection
        {
            get;
            set;
        }

    }
}