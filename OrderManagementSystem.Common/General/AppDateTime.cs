namespace OrderManagementSystem.Common.General
{
    public static class AppDateTime
    {
        /// <summary>
        /// توقيت مصر
        /// </summary>
        public static DateTime Now => DateTime.UtcNow.AddHours(2);
    }
}
