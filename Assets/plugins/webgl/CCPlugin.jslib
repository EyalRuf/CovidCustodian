var CCPlugin = {
    IsMobile: function()
    {
        return UnityLoader.SystemInfo.mobile;
    },
    PostToFB: function(score)
    {
        console.log(score);
        window.open("http://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Feyalruf.itch.io%2Fcovid-custodian&quote=My%20Covid%20Custodian%20score%20is%20" +
                score + "!%20Think%20you%20can%20beat%20me%3F%20try%20here", 
            "_blank", "resizable=yes,top=500,left=500,width=560,height=300");
    },
    Tweet: function(score)
    {
        console.log(score);
        window.open(""https://twitter.com/intent/tweet?text=My Covid Custodian score is "+ 
                score + "! Think you can beat me? Try here: https://eyalruf.itch.io/covid-custodian", 
            "_blank");
    }
 };
 
 mergeInto(LibraryManager.library, CCPlugin);