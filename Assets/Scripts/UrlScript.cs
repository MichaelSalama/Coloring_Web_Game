using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlScript : MonoBehaviour
{
    public void Twitter()
    {
        Application.OpenURL("https://www.twitter.com/anasaudiprogram?lang=ar");
    }

    public void Facebook()
    {
        Application.OpenURL("https://www.facebook.com/anasaudiprogram/");
    }

    public void Instagram()
    {
        Application.OpenURL("https://instagram.com/anasaudiprogram?utm_source=ig_profile_share&igshid=28qmci0pja8c");
    }

    public void Youtube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCxZE-ii7RPfLKQm1huh71Qg");
    }


}
