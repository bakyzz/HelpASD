using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class TimerInsert_Function : MonoBehaviour
{
    #region Masa
    [Header("Breakfast/Lunch/Dinner")]
    public string OraMasa1 = "9";
    public string OraMasa2 = "13";
    public string OraMasa3 = "18";

    private float _duration_eating = 1200f; //trimite o notificare odata la 20 de minute
    private float _timer_eating = 0f; //in secunde
    #endregion

    #region Toaleta
    private string OraBaie1;
    private string OraBaie2;
    private string OraBaie3;

    private float _duration_toilet = 1800f; //trimite o notificare odata la 30 de minute
    private float _timer_toilet = 0f; //in secunde
    #endregion

    #region BedTime
    [Header("BedTime")]
    public string OraCulcare = "20";

    private float _duration_GoToSleep = 600; //trimite o notificare odata la 10 de minute
    private float _timer_sleeping = 0f; //in secunde
    #endregion
    
    private string NotTitle;
    private string NotText; 

    private void Start()
    {
        //calculare ore recomandate pentru mersul la baie
        int auxnumber;
        if (int.Parse(OraCulcare) == 0)
            auxnumber = 9;
        else
            auxnumber = int.Parse(OraCulcare) - 15; //ora de culcare + inca 9 ore
        OraBaie1 = auxnumber.ToString();
        auxnumber = auxnumber + 5;
        OraBaie2 = auxnumber.ToString();
        auxnumber = auxnumber + 5;
        OraBaie3 = auxnumber.ToString();

        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }
    public void FixedUpdate()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("HH");
        _timer_eating += Time.deltaTime;
        _timer_toilet += Time.deltaTime;
        _timer_sleeping += Time.deltaTime;
        if (string.Equals(time, OraMasa1) || string.Equals(time, OraMasa2) || string.Equals(time, OraMasa3))
        {
            if (_timer_eating >= _duration_eating)
            {
                _timer_eating = 0f;
                Send_Notification("The Food is on the Table", "You should go eat!");
            }
        }
        if (string.Equals(time, OraBaie1) || string.Equals(time, OraBaie2) || string.Equals(time, OraBaie3))
        {
            if (_timer_toilet >= _duration_toilet)
            {
                _timer_toilet = 0f;
                Send_Notification("U spent too much time w/o using the bathroom", "You should go to the toilet!");
            }
        }
        if (string.Equals(time, OraCulcare))
        {
            if (_timer_sleeping >= _duration_GoToSleep)
            {
                _timer_sleeping = 0f;
                Send_Notification("It is getting late", "You should go sleep!");
                Send_Notification("Don't forget to brush your teeth!", " ");
            }
        }
    }
    
    private void Send_Notification(string NotTitle, string NotText)
    {
        //create notification channel
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        //create the notification
        var notification = new AndroidNotification();
        notification.Title = NotTitle;
        notification.Text = NotText;
        notification.FireTime = System.DateTime.Now.AddMinutes(1);
        notification.SmallIcon = "my_custom_icon_id";
        notification.LargeIcon = "my_custom_large_icon_id";

        //send the notificaton
        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    public void InOraMasa1()
    {
        InputField inputField = GetComponent<InputField>();
        string value = inputField.text;
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("OraMasa1 is empty");
            return;
        }
        OraMasa1 = value;
    }

    public void InOraMasa2()
    {
        InputField inputField = GetComponent<InputField>();
        string value = inputField.text;
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("OraMasa2 is empty");
            return;
        }
        OraMasa2 = value;
    }

    public void InOraMasa3()
    {
        InputField inputField = GetComponent<InputField>();
        string value = inputField.text;
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("OraMasa3 is empty");
            return;
        }
        OraMasa3 = value;
    }

    public void InOraCulcare()
    {
        InputField inputField = GetComponent<InputField>();
        string value = inputField.text;
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("OraCulcare is empty");
            return;
        }
        OraCulcare = value;
    }
}
