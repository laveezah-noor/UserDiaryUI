using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserDiary;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Stores
{
    public class CacheStore
    {
        Cache _cache;
        public Cache Cache
        {
            get => Cache.getCache();
            set
            {
                _cache = value;
                OnCurrentCacheChanged();
            }
        }
        public event Action CurrentCacheChanged;

        private void OnCurrentCacheChanged()
        {
            CurrentCacheChanged?.Invoke();
        }
    }
}
