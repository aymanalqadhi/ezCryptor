using ezCryptor.Shared.Services;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace ezCryptor
{
    /// <summary>
    /// The application main class
    /// </summary>
    [Export]
    public partial class App
    {
        #region Private Fields

        /// <summary>
        /// The backing field of <see cref="CompositionService"/>
        /// </summary>
        private CompositionService _compositionSvc;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public App()
        {
            CompositionCatalog = new AggregateCatalog();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The global logging service
        /// </summary>
        [Import] public ILogger Logger { get; set; }

        /// <summary>
        /// The composition catalog
        /// </summary>
        public AggregateCatalog CompositionCatalog { get; private set; }

        /// <summary>
        /// Gets the composition service of the application
        /// </summary>
        public CompositionService CompositionService
        {
            get
            {
                if (_compositionSvc == null) _compositionSvc = CompositionCatalog.CreateCompositionService();
                return _compositionSvc;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the singleton instance
        /// </summary>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public Task<bool> Initialize(Action<int, string> progressCallback)
            => Task.Factory.StartNew(delegate
            {
                try
                {
                    progressCallback?.Invoke(-1, "Adding the current assembly to the catalog...");
                    CompositionCatalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));

                    if (Directory.Exists(Properties.Settings.Default.PluginsPath))
                    {
                        progressCallback?.Invoke(50, "Loading Plugins...");
                        CompositionCatalog.Catalogs.Add(new DirectoryCatalog(Properties.Settings.Default.PluginsPath));
                    }

                    progressCallback?.Invoke(50, "Creatng app controller...");
                    CompositionCatalog.CreateCompositionService().SatisfyImportsOnce(this);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }, TaskCreationOptions.LongRunning);

        #endregion
    }
}
