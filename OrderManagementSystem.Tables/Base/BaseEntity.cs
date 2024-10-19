using OrderManagementSystem.Common.General;
using OrderManagementSystem.Tables.People;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Tables.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Creation Date Of The Item
        /// </summary>
        public DateTime CreatedDate { get; set; } = AppDateTime.Now;

        /// <summary>
        /// This Should Be The Added User Id
        /// </summary>
        [ForeignKey(nameof(CreatedUser))]
        public Guid? AddedBy { get; set; }


        /// <summary>
        /// Modified Date Of The Item
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// This Should Be The Modified User Id
        /// </summary>
        [ForeignKey(nameof(ModifiedUser))]
        public Guid? ModifiedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// The Date of Deleted This Item
        /// </summary>
        public DateTime? DeletedDate { get; set; }

        /// <summary>
        /// User Deleted this Item
        /// </summary>
        [ForeignKey(nameof(DeletedUser))]
        public Guid? DeletedBy { get; set; }


        #region Relations

        public User CreatedUser { get; set; }

        public User ModifiedUser { get; set; }

        public User DeletedUser { get; set; }

        #endregion 

    }
}
