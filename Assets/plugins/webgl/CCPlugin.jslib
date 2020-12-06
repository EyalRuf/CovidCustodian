var CCPlugin = {
     IsMobile: function()
     {
         return UnityLoader.SystemInfo.mobile;
     }
 };
 
 mergeInto(LibraryManager.library, CCPlugin);