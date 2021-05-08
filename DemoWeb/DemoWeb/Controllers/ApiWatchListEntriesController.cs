using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using DemoWeb.Models;

namespace DemoWeb.Controllers
{
    public class ApiWatchListEntriesController : ApiController
    {
        private SafeFlightContext db = new SafeFlightContext();

        public IQueryable<WatchListEntry> GetWatchList()
        {
            return db.WatchList;
        }

        [ResponseType(typeof(WatchListEntry))]
        public async Task<IHttpActionResult> GetWatchListEntry(int id)
        {
            WatchListEntry watchListEntry = await db.WatchList.FindAsync(id);
            if (watchListEntry == null)
            {
                return NotFound();
            }

            return Ok(watchListEntry);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWatchListEntry(int id, WatchListEntry watchListEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != watchListEntry.WatchListEntryId)
            {
                return BadRequest();
            }

            db.Entry(watchListEntry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchListEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(WatchListEntry))]
        public async Task<IHttpActionResult> PostWatchListEntry(WatchListEntry watchListEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WatchList.Add(watchListEntry);
            await db.SaveChangesAsync();

            CreatedAtRouteNegotiatedContentResult<WatchListEntry> contentResult = CreatedAtRoute("DefaultApi", new { id = watchListEntry.WatchListEntryId }, watchListEntry);
            return contentResult;
        }

        [ResponseType(typeof(WatchListEntry))]
        public async Task<IHttpActionResult> DeleteWatchListEntry(int id)
        {
            WatchListEntry watchListEntry = await db.WatchList.FindAsync(id);
            if (watchListEntry == null)
            {
                return NotFound();
            }

            db.WatchList.Remove(watchListEntry);
            await db.SaveChangesAsync();

            return Ok(watchListEntry);
        }

        [ResponseType(typeof(WatchListEntry))]
        public async Task<IHttpActionResult> DeleteWatchListEntryByName(string firstName, string lastName)
        {
            WatchListEntry watchListEntry = db.WatchList.FirstOrDefault(x => (firstName == x.FirstName) && (lastName == x.LastName));
            if (watchListEntry == null)
            {
                return NotFound();
            }

            db.WatchList.Remove(watchListEntry);
            await db.SaveChangesAsync();

            return Ok(watchListEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private bool WatchListEntryExists(int id)
        {
            return db.WatchList.Count(e => e.WatchListEntryId == id) > 0;
        }
    }
}