#region using



#endregion

namespace LM.Framework.Diagnostics.Log4Net
{
    public class DBLogAppender : AdoNetAppender
    {
        /// <summary>
        ///     Gets or sets the connection string.
        ///     This is to override the base to take a connection string name and read it from web.config
        /// </summary>
        /// <value>
        ///     The connection string Name.
        /// </value>
        public new string ConnectionString
        {
            get { return base.ConnectionString; }
            set { base.ConnectionString = ConfigurationManager.ConnectionStrings[value].ConnectionString; }
        }
    }
}