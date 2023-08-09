/*******************************************************************************
* Author    :  Angus Johnson                                                   *
* Date      :  19 July 2023                                                    *
* Website   :  http://www.angusj.com                                           *
* Copyright :  Angus Johnson 2010-2022                                         *
* License   :  http://www.boost.org/LICENSE_1_0.txt                            *
*******************************************************************************/

using System.IO;
using System.Reflection;
using Clipper2Lib;
using Newtonsoft.Json;

namespace ClipperNugetTest
{

  public class Application
  {

    public static void Main()
    {
      DoDrop();
    }


    public static void DoDrop()
    {
      string pJson = File.ReadAllText("../../../paths64.json");
      Paths64 p = JsonConvert.DeserializeObject<Paths64>(pJson);
      Paths64 solution = new();
      ClipperOffset co = new();
      co.AddPaths(p, JoinType.Miter, EndType.Joined);
      co.Execute(1000000, solution);
      Console.WriteLine("Number of offset paths in solution = " + solution.Count.ToString());

    }
    
  } //end Application

} //namespace
