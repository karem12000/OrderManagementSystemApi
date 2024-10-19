namespace OrderManagementSystem.Common.General
{
    public static class AppConstants
    {
        public const string _UserIdCookie = "App.Matrix_Subscription.UserId";
        public static Guid AdminUserId = Guid.Parse("762751A8-B808-4FD5-BED7-4FD53D004276");



        public static readonly string EncryptKey = "n1xdl54xsefeghk9z3xodibpmctoneyj";

        public struct Areas
        {
            public const string Api = nameof(Api);
            public const string Account = nameof(Account);
            public const string Guide = nameof(Guide);
            public const string Page = nameof(Page);
            public const string People = nameof(People);
            public const string Order = nameof(Order);

        }

        public struct ArMessages
        {
            public const string StopTitle = "توقف";
            public const string CurrentAndNewPasswordEqual = "كلمة المرور الجديدة مطابقة لكلمة المرور الحالية";
            public const string NewAndConfirmPassword = "تأكيد كلمة المرور غير مطابق لكلمة المرور الجديدة";
            public const string UserNotFound = "هذا المستخدم غير موجود";
            public const string PasswordRequired = "كلمة المرور مطلوبة";
            public const string InvalidEmail = "تأكد من إدخال الإيميل بشكل صحيح";
            public const string InvalidEmailOrPassword = "خطأ في الإيميل أو كلمة المرور";
            public const string requiredQtyNotEnough = "الكمية المطلوبة غير متاحه";
            public const string QtyMustGreateZero = "يجب أن تكون الكمية أكبر من 0";
            public const string CustomerNotFound = "العميل غير موجود";
            public const string PlaceOrderFailed = "خطأ في الطلب";
            public const string PlaceOrderSuccess = "تم الطلب بنجاح";
            public const string ProductNotFound = "هذا المنتج غير موجود";
            public const string InvalidCurrentPassword = "كلمة المرور الحالية غير صحيحه";
            public const string EmailRequired = "البريد الإلكتروني مطلوب";
            public const string SavedSuccess = "تمت عملية الحفظ بنجاح";
            public const string SavedFailed = "حدث خطا";
            public const string NameAlreadyExists = "الاسم مستخدم من قبل";
            public const string NameRequired = "من فضلك أدخل الاسم";
            public const string PhoneRequired = "من فضلك أدخل رقم الهاتف";
            public const string PriceRequired = "من فضلك أدخل السعر";
            public const string StockQntyRequired = "من فضلك أدخل الكمية";
            public const string EmailAlreadyExists = "البريد الإلكتروني مستخدم من قبل";
            public const string DeletedSuccess = "تم الحذف بنجاح";
            public const string DeletedFailed = "حدث خطا اثناء الحذف";
        }

        public struct EnMessages
        {
            public const string StopTitle = "Stop";
            public const string CurrentAndNewPasswordEqual = "The new password matches the current password";
            public const string NewAndConfirmPassword = "The confirmation password does not match the new password";
            public const string UserNotFound = "This user does not exist";
            public const string PasswordRequired = "Password is required";
            public const string InvalidEmail = "Please make sure the email is entered correctly";
            public const string InvalidEmailOrPassword = "Incorrect email or password";
            public const string requiredQtyNotEnough = "The requested quantity is not available";
            public const string QtyMustGreateZero = "The quantity must be greater than 0";
            public const string CustomerNotFound = "Customer not found";
            public const string PlaceOrderFailed = "Order failed";
            public const string PlaceOrderSuccess = "Order placed successfully! Please use your email to follow up the order";
            public const string ProductNotFound = "This product does not exist";
            public const string InvalidCurrentPassword = "The current password is incorrect";
            public const string EmailRequired = "Email is required";
            public const string SavedSuccess = "Saved successfully";
            public const string SavedFailed = "An error occurred";
            public const string PersonalDataRequired = "Please Enter all Personal data";
            public const string NameAlreadyExists = "The name is already in use";
            public const string NameRequired = "Please enter the name";
            public const string PhoneRequired = "Please enter the phone number";
            public const string PriceRequired = "Please enter the price";
            public const string StockQntyRequired = "Please enter the quantity";
            public const string EmailAlreadyExists = "The email is already in use";
            public const string DeletedSuccess = "Deleted successfully";
            public const string DeletedFailed = "An error occurred during deletion";
        }

    }
}
