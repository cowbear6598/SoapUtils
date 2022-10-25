using System;

namespace SoapUtils.Runtime.NotifySystem
{
    public interface INotifyService
    {
        void Notify(string content);
        void Notify(string content, Action confirmAction);
        void Notify(string content, Action confirmAction, Action cancelAction);
        void Close();
    }
}