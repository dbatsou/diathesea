using Domain.Entities;

namespace Storage
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {

            if (!context.State.Any())
                await context.State.AddRangeAsync(SeedStates());

            await context.SaveChangesAsync();

            if (!context.StateEntry.Any())
                await context.StateEntry.AddRangeAsync(SeedStateEntries());

            if (!context.User.Any())
                await context.User.AddAsync(SeedUser());

            await context.SaveChangesAsync();
        }

        private static List<StateEntry> SeedStateEntries()
        => new List<StateEntry>()
        {
            new StateEntry() {StateId=1,  Note = "today was meh"   },
            new StateEntry() {StateId=2,  Note = "yesterday also meh"  },
        };

        static List<State> SeedStates()
        {
            var states = new List<State>()
            {
                #region fear

                new State() { StateName = "Fear", StateId = 1 },

                new State() { StateId = 7 ,StateName = "Scared", ParentStateID = 1 },
                new State() { StateId = 12 ,StateName = "Frightened", ParentStateID = 7 },
                new State() { StateId = 13 ,StateName = "Helpless", ParentStateID = 7 },

                new State() { StateId = 8 ,StateName = "Terrified", ParentStateID = 1 },
                new State() { StateId = 14 ,StateName = "Panicked", ParentStateID = 8 },
                new State() { StateId = 15 ,StateName = "Hysterical", ParentStateID = 8 },

                new State() { StateId = 9 ,StateName = "Insecure", ParentStateID = 1 },
                new State() { StateId = 16 ,StateName = "Inadequate", ParentStateID = 9 },
                new State() { StateId = 17 ,StateName = "Inferior", ParentStateID = 9 },

                new State() { StateId = 10 ,StateName = "Nervous", ParentStateID = 1 },
                new State() { StateId = 19 ,StateName = "Worried", ParentStateID = 10 },
                new State() { StateId = 20 ,StateName = "Anxious", ParentStateID = 10 },

                new State() { StateId = 11 ,StateName = "Horrified", ParentStateID = 1 },
                new State() { StateId = 21 ,StateName = "Mortified", ParentStateID = 11 },
                new State() { StateId = 22 ,StateName = "Dreadful", ParentStateID = 11 },
                #endregion
                
                #region anger
                new State() { StateName = "Anger", StateId = 2 },

                new State() { StateId = 23 ,StateName = "Enraged", ParentStateID = 2 },
                new State() { StateId = 24 ,StateName = "Hostile", ParentStateID = 23 },
                new State() { StateId = 25 ,StateName = "Hateful", ParentStateID = 23 },

                new State() { StateId = 26 ,StateName = "Exasperated", ParentStateID = 2 },
                new State() { StateId = 27 ,StateName = "Agitated", ParentStateID = 26 },
                new State() { StateId = 28 ,StateName = "Frustrated", ParentStateID = 26 },

                new State() { StateId = 29 ,StateName = "Irritable", ParentStateID = 2 },
                new State() { StateId = 30 ,StateName = "Annoyed", ParentStateID = 29 },
                new State() { StateId = 31 ,StateName = "Aggravated", ParentStateID = 29 },

                new State() { StateId = 32 ,StateName = "Jealous", ParentStateID = 2 },
                new State() { StateId = 33 ,StateName = "Resentful", ParentStateID = 32 },
                new State() { StateId = 34 ,StateName = "Envious", ParentStateID = 32 },

                new State() { StateId = 35 ,StateName = "Disgusted", ParentStateID = 2 },
                new State() { StateId = 36 ,StateName = "Contemptuous", ParentStateID = 35 },
                new State() { StateId = 37 ,StateName = "Revolted", ParentStateID = 35 },
                #endregion

                #region sadness
                new State() { StateName = "Sadness", StateId = 3 },
                new State() { StateId = 38 ,StateName = "Hurt", ParentStateID = 3 },
                new State() { StateId = 39 ,StateName = "Agonized", ParentStateID = 38 },
                new State() { StateId = 40 ,StateName = "Disturbed", ParentStateID = 38 },


                new State() { StateId = 41 ,StateName = "Unhappy", ParentStateID = 3 },
                new State() { StateId = 42 ,StateName = "Miserable", ParentStateID = 41 },
                new State() { StateId = 43 ,StateName = "Dishartened", ParentStateID = 41 },


                new State() { StateId = 44 ,StateName = "Disappointed", ParentStateID = 3 },
                new State() { StateId = 45 ,StateName = "Dismayed", ParentStateID = 44 },
                new State() { StateId = 46 ,StateName = "Displeased", ParentStateID = 44 },


                new State() { StateId = 47 ,StateName = "Shameful", ParentStateID = 3 },
                new State() { StateId = 48 ,StateName = "Regretful", ParentStateID = 47 },
                new State() { StateId = 49 ,StateName = "Guilty", ParentStateID = 47 },


                new State() { StateId = 50 ,StateName = "Lonely", ParentStateID = 3 },
                new State() { StateId = 51 ,StateName = "Isolated", ParentStateID = 50 },
                new State() { StateId = 52 ,StateName = "Neglected", ParentStateID = 50 },

                new State() { StateId = 53 ,StateName = "Gloomy", ParentStateID = 3 },
                new State() { StateId = 54 ,StateName = "Hopeless", ParentStateID = 53 },
                new State() { StateId = 55 ,StateName = "Depressed", ParentStateID = 53 },
                #endregion
                
                #region surprise
                new State() { StateName = "Surprise", StateId = 4 },

                new State() { StateId = 56 ,StateName = "Moved", ParentStateID = 4 },
                new State() { StateId = 57 ,StateName = "Touched", ParentStateID = 56 },
                new State() { StateId = 58 ,StateName = "Stimulated", ParentStateID = 56 },

                new State() { StateId = 59 ,StateName = "Overcome", ParentStateID = 4 },
                new State() { StateId = 60 ,StateName = "Astounded", ParentStateID = 59 },
                new State() { StateId = 61 ,StateName = "Speechless", ParentStateID = 59 },

                new State() { StateId = 62 ,StateName = "Amazed", ParentStateID = 4 },
                new State() { StateId = 63 ,StateName = "Awe-struck", ParentStateID = 62 },
                new State() { StateId = 64 ,StateName = "Astonished", ParentStateID = 62 },

                new State() { StateId = 65 ,StateName = "Confused", ParentStateID = 4 },
                new State() { StateId = 66 ,StateName = "Perplexed", ParentStateID = 65 },
                new State() { StateId = 67 ,StateName = "Disillusioned", ParentStateID = 65 },

                new State() { StateId = 68 ,StateName = "Stunned", ParentStateID = 4 },
                new State() { StateId = 69 ,StateName = "Shoched", ParentStateID = 68 },
                new State() { StateId = 70 ,StateName = "Bewildered", ParentStateID = 69 },
                #endregion
                
                #region joy
                new State() { StateName = "Joy", StateId = 5 },

                new State() { StateId = 71 ,StateName = "Euphoric", ParentStateID = 5 },
                new State() { StateId = 72 ,StateName = "Jubilant", ParentStateID = 71 },
                new State() { StateId = 73 ,StateName = "Elated", ParentStateID = 71 },

                new State() { StateId = 74 ,StateName = "Excited", ParentStateID = 5 },
                new State() { StateId = 75 ,StateName = "Zealous", ParentStateID = 74 },
                new State() { StateId = 76 ,StateName = "Enthousiastic", ParentStateID = 74 },

                new State() { StateId = 77 ,StateName = "Optimistic", ParentStateID = 5 },
                new State() { StateId = 78 ,StateName = "Hopeful", ParentStateID = 77 },
                new State() { StateId = 79 ,StateName = "Eager", ParentStateID = 77 },

                new State() { StateId = 80 ,StateName = "Proud", ParentStateID = 5 },
                new State() { StateId = 81 ,StateName = "Illustrious", ParentStateID = 80 },
                new State() { StateId = 82 ,StateName = "Triumphant", ParentStateID = 80 },

                new State() { StateId = 83 ,StateName = "Cheerful", ParentStateID = 5 },
                new State() { StateId = 84 ,StateName = "Playful", ParentStateID = 83 },
                new State() { StateId = 85 ,StateName = "Amused", ParentStateID = 83 },

                new State() { StateId = 86 ,StateName = "Happy", ParentStateID = 5 },
                new State() { StateId = 87 ,StateName = "Jovial", ParentStateID = 86 },
                new State() { StateId = 88 ,StateName = "Delighted", ParentStateID = 86 },

                new State() { StateId = 89 ,StateName = "Content", ParentStateID = 5 },
                new State() { StateId = 90 ,StateName = "Pleased", ParentStateID = 89 },
                new State() { StateId = 91 ,StateName = "Satisfied", ParentStateID = 89 },

                new State() { StateId = 92 ,StateName = "Peaceful", ParentStateID = 5 },
                new State() { StateId = 93 ,StateName = "Serene", ParentStateID = 92 },
                new State() { StateId = 94 ,StateName = "Tranquil", ParentStateID = 92 },
                #endregion

                #region love

                new State() { StateName = "Love", StateId = 6 },

                new State() { StateId = 95 ,StateName = "Grateful", ParentStateID = 6 },
                new State() { StateId = 96 ,StateName = "Thankful", ParentStateID = 95 },
                new State() { StateId = 97 ,StateName = "Appreciative", ParentStateID = 95 },

                new State() { StateId = 98 ,StateName = "Sentimental", ParentStateID = 6 },
                new State() { StateId = 99 ,StateName = "Nostalgic", ParentStateID = 98 },
                new State() { StateId = 100 ,StateName = "Tender", ParentStateID = 98 },

                new State() { StateId = 101 ,StateName = "Affectionate", ParentStateID = 6 },
                new State() { StateId = 102 ,StateName = "Compassionate", ParentStateID = 101 },
                new State() { StateId = 103 ,StateName = "Warm-hearted", ParentStateID = 101 },

                new State() { StateId = 104 ,StateName = "Romantic", ParentStateID = 6 },
                new State() { StateId = 105 ,StateName = "Enamored", ParentStateID = 104 },
                new State() { StateId = 106 ,StateName = "Passionate", ParentStateID = 104 },

                new State() { StateId = 107 ,StateName = "Enchanted", ParentStateID = 6 },
                new State() { StateId = 108 ,StateName = "Rapturous", ParentStateID = 107 },
                new State() { StateId = 109 ,StateName = "Enthralled", ParentStateID = 107 }
                #endregion
            };
            return states;
        }

        static User SeedUser() => new User() { Username = "dimi", Password = "dimi", DisplayName = "Dimitrios" };

    }
}