using System.Collections.Generic;

namespace Equinox.Models
{
    public class FilterViewModel1
    {
        // List of filtered Equinox classes
        public List<EquinoxClass> AvailableClasses { get; set; } = new();

        // All clubs for the club dropdown
        public List<Club> AllClubs { get; set; } = new();

        // All categories for the category dropdown
        public List<ClassCategory> AllCategories { get; set; } = new();

        // Selected club filter value
        public string SelectedClubName { get; set; } = "All";

        // Selected category filter value
        public string SelectedCategoryName { get; set; } = "All";
    }
}
