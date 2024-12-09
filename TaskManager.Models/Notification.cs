using System;

namespace TaskManager.Models;

public class Notification
{
    public Notification(){}

    public Notification(string message, DateTime dateShipping, Labor labor){
        Message = message;
        DateShipping = dateShipping;
        Labor = labor;
    }

    public int? NotificationId;

    public string? Message;

    public DateTime? DateShipping;

    Labor? Labor;
}
