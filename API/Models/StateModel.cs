using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Models
{
    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

    public static class StateExtensions
    {
        public static State ToStateModel(this StateModel model)
        =>  new State (){StateId=model.StateId,StateName=model.StateName};
    }
}