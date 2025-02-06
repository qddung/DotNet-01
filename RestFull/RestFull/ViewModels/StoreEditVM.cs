namespace RestFull.ViewModels;
using System.ComponentModel.DataAnnotations;

public class StoreEditVM
{
    public int id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string name { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string alias { get; set; }

    [Required(ErrorMessage = "Latitude is required.")]
    public string latitude { get; set; }

    [Required(ErrorMessage = "Longtitude is required.")]
    public string longtitude { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string description { get; set; }

    [Required(ErrorMessage = "Image Url is required.")]
    [Url(ErrorMessage = "Please provide a valid URL.")]
    public string image { get; set; }
    public bool deleted { get; set; }
}
