// trailservice.razor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testdatabase.DataLayer
{
    public class TrailService
    {
        private List<Trail> Trails { get; set; } = new List<Trail>
        {
            new Trail { Id = 1, Title = "Stress Relief", Description = "Relax and unwind with this guided meditation.", Path = "https://www.youtube.com/embed/VIDEO_ID_1" },
            new Trail { Id = 2, Title = "Self-Compassion", Description = "Cultivate self-love and compassion.", Path = "https://www.youtube.com/embed/VIDEO_ID_2" },
            new Trail { Id = 3, Title = "Relaxing Meditation", Description="Calm down your self", Path = "https://www.youtube.com/embed/caq8XpjAswo" },
            new Trail { Id = 4, Title  = "Morning Meditation", Description="Start morning with a mood", Path = "https://www.youtube.com/embed/KgwC348gl3w" }
        };

        private List<UserTrailProgress> UserTrailProgresses { get; set; } = new List<UserTrailProgress>();

        public async Task<List<Trail>> GetTrails()
        {
            await Task.Delay(100);
            return Trails.ToList();
        }

        public async Task RecordTrailProgress(string userEmail, int trailId)
        {
            UserTrailProgresses.Add(new UserTrailProgress
            {
                UserEmail = userEmail,
                TrailId = trailId,
                WatchedOn = DateTime.Now
            });

            await Task.Delay(50); // Simulate async operation
        }

        public List<Trail> GetUserWatchedTrails(string userEmail)
        {
            var watchedTrailIds = UserTrailProgresses
                .Where(progress => progress.UserEmail == userEmail)
                .Select(progress => progress.TrailId)
                .ToList();

            return Trails.Where(trail => watchedTrailIds.Contains(trail.Id)).ToList();
        }
    }

    public class Trail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }

    public class UserTrailProgress
    {
        public string UserEmail { get; set; }
        public int TrailId { get; set; }
        public DateTime WatchedOn { get; set; }
    }
}
