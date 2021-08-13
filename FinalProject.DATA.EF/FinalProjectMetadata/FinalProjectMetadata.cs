using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.DATA.EF/*.FinalProjectMetadata*/
{
    #region ApplicationMetadata   
    public class ApplicationMetadata
    {
        [Required(ErrorMessage = "An open position is required")]
        public int OpenPositionID { get; set; }

        [Required(ErrorMessage = "A user is required")]
        [StringLength(128, ErrorMessage = "*Value must be 128 characters or less")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "An application date is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[-N/A-]")]
        public DateTime ApplicationDate { get; set; }

        [StringLength(2000, ErrorMessage = "*Value must be 2000 characters or less")]
        public string ManagerNotes { get; set; }

        [Required(ErrorMessage = "An application status is required")]
        public int ApplicationStatusID { get; set; }

        //[Required(ErrorMessage = "A resume is required")]
        [StringLength(75, ErrorMessage = "*Value must be 75 characters or less")]
        public string ResumeFileName { get; set; }
    }
    #endregion

    #region ApplicationStatusMetadata
    public class ApplicationStatusMetadata
    {
        [Required(ErrorMessage = "A status name is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string StatusName { get; set; }

        [StringLength(250, ErrorMessage = "*Value must be 250 characters or less")]
        public string StatusDescription { get; set; }
    }
    #endregion

    #region LocationMetadata
    public class LocationMetadata
    {
        [Required(ErrorMessage ="A store number is required")]
        [StringLength(10, ErrorMessage = "*Value must be 10 characters or less")]
        public string StoreNumber { get; set; }

        [Required(ErrorMessage = "A city is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string City { get; set; }

        [Required(ErrorMessage = "A state is required")]
        [StringLength(2, ErrorMessage = "*Value must be 2 characters or less")]
        public string State { get; set; }

        [Required(ErrorMessage = "A manager is required")]
        [StringLength(128, ErrorMessage = "*Value must be 128 characters or less")]
        public string ManagerID { get; set; }
    }
    #endregion

    #region OpenPositionMetadata
    public class OpenPositionMetadata
    {
        [Required(ErrorMessage = "A position is required")]
        public int PositionID { get; set; }

        [Required(ErrorMessage = "A location is required")]
        public int LocationID { get; set; }
    }
    #endregion

    #region PositionMetadata
    public class PositionMetadata
    {
        [Required(ErrorMessage = "A title is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string Title { get; set; }

        [UIHint("MultilineText")]
        public string JobDescription { get; set; }
    }
    #endregion

    #region UserDetailMetadata
    public class UserDetailMetadata
    {
        [Required(ErrorMessage = "A user is required")]
        [StringLength(128, ErrorMessage = "*Value must be 128 characters or less")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "A first name is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "A last name is required")]
        [StringLength(75, ErrorMessage = "*Value must be 75 characters or less")]
        public string LastName { get; set; }

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
