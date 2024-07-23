using System.Collections.Generic;
using System.Linq;

namespace testdatabase
{
    public class MindfulnessExercise
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }

    public class MindfulnessExerciseService
    {
        private readonly List<MindfulnessExercise> availableExercises = new List<MindfulnessExercise>
        {
            new MindfulnessExercise { Id = 1, Description = "Focus on your breath for one minute.", ImagePath = "/images/breath.jpg" },
            new MindfulnessExercise { Id = 2, Description = "Scan your body from head to toe, noticing any tension or discomfort.", ImagePath = "/images/scan.jpg" },
            new MindfulnessExercise { Id = 3, Description = "Take five deep breaths, counting each inhale and exhale.", ImagePath = "/images/inhale.jpg" },
            new MindfulnessExercise { Id = 4, Description = "Close your eyes and focus on the sound around you for two minutes.", ImagePath = "/images/birds.jpg" },
            new MindfulnessExercise { Id = 5, Description = "Take a moment to appreciate something beautiful in your surroundings.", ImagePath = "/images/calm.jpg" },
            new MindfulnessExercise { Id = 6, Description = "Practice gratitude by listing three things you're thankful for right now.", ImagePath = "/images/grat.jpg" },
            new MindfulnessExercise { Id = 7, Description = "Go for a nature walk and observe the sights, sounds, and smells around you.", ImagePath = "/images/naturewalk.jpg" },
        };

        private readonly Dictionary<string, List<MindfulnessExercise>> userCompletedExercises = new Dictionary<string, List<MindfulnessExercise>>();

        public bool IsAllExercisesCompleted(string email)
        {
            return availableExercises.Count == GetCompletedExercises(email).Count;
        }

        public List<MindfulnessExercise> GetAvailableExercises()
        {
            return availableExercises;
        }

        public List<MindfulnessExercise> GetCompletedExercises(string email)
        {
            if (userCompletedExercises.ContainsKey(email))
            {
                return userCompletedExercises[email];
            }
            return new List<MindfulnessExercise>();
        }

        public void AddCompletedExercise(string email, MindfulnessExercise exercise)
        {
            if (!userCompletedExercises.ContainsKey(email))
            {
                userCompletedExercises[email] = new List<MindfulnessExercise>();
            }
            if (!userCompletedExercises[email].Any(e => e.Id == exercise.Id))
            {
                userCompletedExercises[email].Add(exercise);
            }
        }

        public MindfulnessExercise GetExerciseById(int id)
        {
            return availableExercises.FirstOrDefault(e => e.Id == id);
        }

        public void AddExercise(MindfulnessExercise exercise)
        {
            // You might want to add validation here to ensure exercise doesn't already exist
            availableExercises.Add(exercise);
        }
        public void RemoveExercise(int id)
        {
            var exercise = availableExercises.FirstOrDefault(e => e.Id == id);
            if (exercise != null)
            {
                availableExercises.Remove(exercise);
            }
        }

    }
}
