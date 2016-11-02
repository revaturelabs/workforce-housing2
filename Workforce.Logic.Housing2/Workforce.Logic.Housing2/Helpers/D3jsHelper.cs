using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Housing2.Models;
using Workforce.Logic.Housing2.TransferModels;

namespace Workforce.Logic.Housing2.Helpers
{
   public class D3jsHelper
   {

      /// <summary>
      /// this is the logic for getting the name of each apartment and the current and max capacity of each apartment complex
      /// </summary>
      /// <returns></returns>
      public async Task<List<GraphAptCapacityDto>> ReturnGraphAptCapacity()
      {
         D3AptCapacity aptCapacity = new D3AptCapacity();
         return await aptCapacity.getNewModel();
      }


      /// <summary>
      /// this helper methdo is calls the logic for percolating the model needed for the d3js projection back to its caller
      /// </summary>
      /// <param name="projectionDate"></param>
      /// <returns></returns>
      public async Task<List<D3Projection>> ReturnGraphProjection(DateTime projectionDate)
      {
         D3DateProjection d3DateProjection = new D3DateProjection();
         return await d3DateProjection.getNewModel(projectionDate);
      }
   }
}