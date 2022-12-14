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
        static CacheStore? instance;
        //public List<string> UsernameList;
        //public List<Diary_List> defaultDiaryList;
        //public DefaultUserList UserList;

        //public List<User> defaultAdminList;

        public User? currentUser;

        public static CacheStore GetCache()
        {
            instance ??= new CacheStore();;
            return instance;
        }

        CacheStore()
        {
            currentUser = new();
            currentUser = Xml<User>.Deserialize(currentUser);
            //MessageBox.Show(currentUser.display());
           if (currentUser == null || currentUser.Id == 0)
            {
                currentUser= new();
                Xml<User>.Serialize(currentUser);
            }
            else
            {
            Cache.getCache().currentUser = currentUser;

            }
        }
        public void Logout()
        {
            Cache.getCache().Logout();
            CacheStore.GetCache().CurrentUser = new User();

        }
        public void UpdateCurrentUser()
        {
            Xml<User>.Serialize(GetCache().currentUser);
            currentUser = Xml<User>.Deserialize(currentUser);

        }
        public User CurrentUser
        {
            get => GetCache().currentUser;
            set
            {
                currentUser = value;
                UpdateCurrentUser();
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
