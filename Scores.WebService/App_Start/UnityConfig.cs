using Scores.WebService.BusinessLogic;
using Scores.WebService.Models;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Scores.WebService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IScoresCalculator, ScoresCalculator>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}