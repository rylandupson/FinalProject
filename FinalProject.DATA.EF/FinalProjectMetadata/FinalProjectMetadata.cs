using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.DATA.EF/*.FinalProjectMetadata*/
{
    #region ApplicationMetadata   
    [MetadataType(typeof(ApplicationMetadata))]
    public partial class Application
    {

    }

    public class ApplicationMetadata
    {
        [Display(Name = "Open Position")]
        [Required(ErrorMessage = "An open position is required")]
        public int OpenPositionID { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "A user is required")]
        [StringLength(128, ErrorMessage = "*Value must be 128 characters or less")]
        public string UserID { get; set; }

        [Display(Name = "Application Date")]
        [Required(ErrorMessage = "An application date is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-]")]
        public DateTime ApplicationDate { get; set; }

        [Display(Name = "Manager Notes")]
        [StringLength(2000, ErrorMessage = "*Value must be 2000 characters or less")]
        public string ManagerNotes { get; set; }

        [Display(Name = "Application Status")]
        [Required(ErrorMessage = "An application status is required")]
        public int ApplicationStatusID { get; set; }

        [Display(Name = "Resume")]
        //[Required(ErrorMessage = "A resume is required")]
        [StringLength(75, ErrorMessage = "*Value must be 75 characters or less")]
        public string ResumeFileName { get; set; }
    }
    #endregion

    #region ApplicationStatusMetadata
    [MetadataType(typeof(ApplicationStatusMetadata))]
    public partial class ApplicationStatus
    {

    }

    public class ApplicationStatusMetadata
    {
        [Display(Name = "Status")]
        [Required(ErrorMessage = "A status name is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string StatusName { get; set; }

        [Display(Name = "Description")]
        [StringLength(250, ErrorMessage = "*Value must be 250 characters or less")]
        public string StatusDescription { get; set; }
    }
    #endregion

    #region LocationMetadata
    [MetadataType(typeof(LocationMetadata))]
    public partial class Location
    {

    }

    public class LocationMetadata
    {
        [Display(Name = "Store")]
        [Required(ErrorMessage ="A store number is required")]
        [StringLength(10, ErrorMessage = "*Value must be 10 characters or less")]
        public string StoreNumber { get; set; }

        [Required(ErrorMessage = "A city is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string City { get; set; }

        [Required(ErrorMessage = "A state is required")]
        [StringLength(2, ErrorMessage = "*Value must be 2 characters or less")]
        public string State { get; set; }

        [Display(Name = "Manager")]
        [Required(ErrorMessage = "A manager is required")]
        [StringLength(128, ErrorMessage = "*Value must be 128 characters or less")]
        public string ManagerID { get; set; }
    }
    #endregion

    #region OpenPositionMetadata
    [MetadataType(typeof(OpenPositionMetadata))]
    public partial class OpenPosition
    {

    }

    public class OpenPositionMetadata
    {
        [Display(Name = "Position")]
        [Required(ErrorMessage = "A position is required")]
        public int PositionID { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "A location is required")]
        public int LocationID { get; set; }
    }
    #endregion

    #region PositionMetadata
    [MetadataType(typeof(PositionMetadata))]
    public partial class Position
    {

    }

    public class PositionMetadata
    {
        [Required(ErrorMessage = "A title is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [UIHint("MultilineText")]
        public string JobDescription { get; set; }
    }
    #endregion

    #region UserDetailMetadata
    public class UserDetailMetadata
    {
        [Display(Name = "User ID")]
        [Required(ErrorMessage = "A user is required")]
        [StringLength(128, ErrorMessage = "*Value must be 128 characters or less")]
        public string UserID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "A first name is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "A last name is required")]
        [StringLength(75, ErrorMessage = "*Value must be 75 characters or less")]
        public string LastName { get; set; }

        [Display(Name = "Resume")]
        [StringLength(75, ErrorMessage = "*Value must be 75 characters or less")]
        public string ResumeFileName { get; set; }
    }

    [MetadataType(typeof(UserDetailMetadata))]
    public partial class UserDetail
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
    #endregion
}
