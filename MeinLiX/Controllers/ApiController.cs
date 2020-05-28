using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeinLiX.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly DB_ORGContext _context;

        public ApiController(DB_ORGContext context)
        {
            _context = context;
        }
        [HttpGet("Region")]
        public JsonResult Region()
        {
            var regions = _context.Region.Include(o => o.Organisation).ToList();
            List<object> result = new List<object>();
            result.Add(new[] { "Organisations", "Region", "Market" });

            result.Add(new object[] { "Global", null, 0 });
            foreach (var reg in regions)
            {
                result.Add(new object[] { reg.RegionName, "Global", 1 });
                var organisations = _context.Organisation.Where(o => o.IdRegion == reg.IdRegion).Include(o => o.Subdivision).ToList();
                foreach (var org in organisations)
                {
                    result.Add(new object[] { org.OrganisationName, reg.RegionName, 1 });
                    var subdivisions = _context.Subdivision.Where(s => s.IdOrganisation == org.IdOrganisation).Include(g => g.IdGameNavigation).ToList();
                    foreach (var sub in subdivisions)
                    {
                        result.Add(new object[] { sub.IdGameNavigation.GameName + " - " + org.OrganisationName, org.OrganisationName, 1 });
                        var players = _context.Player.Where(s => s.IdSubdivision == sub.IdSubdivision).ToList();
                        foreach (var pl in players)
                        {
                            result.Add(new object[] { pl.PlayerNickname, sub.IdGameNavigation.GameName + " - " + org.OrganisationName, 1 });
                        }
                    }
                }
            }

            return new JsonResult(result);
        }

        [HttpGet("Game")]
        public JsonResult Game()
        {
            var games = _context.Game.Include(o => o.Subdivision).ToList();
            List<object> result = new List<object>();
            result.Add(new[] { "Game", "Organisations number" });
            foreach (var o in games)
            {
                result.Add(new object[] { o.GameName, o.Subdivision.Count() });
            }
            
            return new JsonResult(result);
        }

        [HttpGet("Sponsor")]
        public JsonResult Sponsor()
        {
            List<object> result = new List<object>();
            result.Add(new[] { "", "With Sponsor", "Without Sponsor", "Total" });
            var organisationt_without_sponsor = _context.Organisation.Where(o => !o.ContractOrganisation.Any());
            var organisationt_with_sponsor = _context.Organisation.Where(o => o.ContractOrganisation.Any());
            result.Add(new object[] { "Organisations", organisationt_with_sponsor.Count(), organisationt_without_sponsor.Count(), organisationt_with_sponsor.Count() + organisationt_without_sponsor.Count() });

            var player_without_sponsor = _context.Player.Where(o => !o.ContractPlayer.Any());
            var player_with_sponsor = _context.Player.Where(o => o.ContractPlayer.Any());
            result.Add(new object[] { "Players", player_with_sponsor.Count(), player_without_sponsor.Count(), player_with_sponsor.Count() + player_without_sponsor.Count() });

            var event_without_sponsor = _context.Event.Where(o => !o.ContractEvent.Any());
            var event_with_sponsor = _context.Event.Where(o => o.ContractEvent.Any());
            result.Add(new object[] { "Events", event_with_sponsor.Count(), event_without_sponsor.Count(), event_with_sponsor.Count() + event_without_sponsor.Count() });

            return new JsonResult(result);
        }


    }
}