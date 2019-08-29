using UtilantDemo.Models;

namespace UtilantDemo.ViewModels
{
    public class AlbumViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ThumbnailUrl { get; set; }
        public Address Address { get; set; }
    }
}