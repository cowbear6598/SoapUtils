using System;
using Zenject;

namespace SoapUtils.NotifySystem
{
    internal class NotifyService : INotifyService
    {
        [Inject] private readonly NotifyView notifyView;
        
        public void DoNotify(string content)
        {
            notifyView.SetAppear(true);
            notifyView.SetContent(content);
        }

        public void DoNotify(string content, Action confirmAction)
        {
            notifyView.SetAppear(true);
            notifyView.SetContent(content, confirmAction);
        }

        public void DoNotify(string content, Action confirmAction, Action cancelAction)
        {
            notifyView.SetAppear(true);
            notifyView.SetContent(content, confirmAction, cancelAction);
        }

        public void DoClose()
        {
            notifyView.SetAppear(false);
        }
    }
}