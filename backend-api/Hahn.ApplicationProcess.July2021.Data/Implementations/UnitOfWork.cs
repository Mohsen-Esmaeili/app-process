using System;
using Hahn.ApplicationProcess.July2021.Data.DataContext;

namespace Hahn.ApplicationProcess.July2021.Data.Implementations
{
    public class UnitOfWork: IDisposable
    {
        private readonly ApplicationProcessDbContext _dbContext;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Asset> _assetRepository;
        private GenericRepository<UserAsset> _userAssetRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {
                this._userRepository ??= new GenericRepository<User>(_dbContext);

                return this._userRepository;
            }
        }

        public GenericRepository<Asset> AssetRepository
        {
            get
            {
                this._assetRepository ??= new GenericRepository<Asset>(_dbContext);

                return this._assetRepository;
            }
        }

        public GenericRepository<UserAsset> UserAssetRepository
        {
            get
            {
                this._userAssetRepository ??= new GenericRepository<UserAsset>(_dbContext);

                return this._userAssetRepository;
            }
        }

        public void Save()
        {
            this._dbContext.SaveChanges();
        }

        private bool _disposed;

        public UnitOfWork(ApplicationProcessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if(disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
