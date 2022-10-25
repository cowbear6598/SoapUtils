using System;
using Zenject;

namespace SoapUtils.Runtime.NotifySystem
{
    public class NotifyService : INotifyService
    {
        [Inject] private readonly NotifyView notifyView;
        
        public void Notify(string content)
        {
            notifyView.SetAppear(true);
            notifyView.SetContent(content);
        }

        public void Notify(string content, Action confirmAction)
        {
            notifyView.SetAppear(true);
            notifyView.SetContent(content, confirmAction);
        }

        public void Notify(string content, Action confirmAction, Action cancelAction)
        {
            notifyView.SetAppear(true);
            notifyView.SetContent(content, confirmAction, cancelAction);
        }

        public void Close()
        {
            notifyView.SetAppear(false);
        }
    }
}