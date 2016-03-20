using System;
using CSharpConcepts.Interfaces;

namespace CSharpConcepts.ArticlesExamples
{
    internal class DependencyInversionExample : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Dependency Inversion Example");
        }

        public void MainMethod()
        {
            Console.WriteLine("Dependency Inversion principle states:");
            Console.WriteLine("1. High Level modules should not depend on low level modules.Both should depend on Abstractions");
            Console.WriteLine("2. Abstractions Should not depend on details.Details should depend on abstractions");
            Console.WriteLine("Dependency Injection pattern in an application/implementation of this principle and enables us in creation of object outside the dependent object");
            Console.WriteLine("DI has 3 flavors : Constructor injection, Property injection and Method Injection");

            Email email = new Email();
            NotificationService notificationService = new NotificationService(email);
            notificationService.PromotionalNotification();
        }


        public interface IMessageService
        {
            void SendMessage();
        }

        public class Email : IMessageService
        {
            public void SendMessage()
            {
                Console.WriteLine("Sending message through Email");
            }
        }

        public class SMS : IMessageService
        {
            public void SendMessage()
            {
                Console.WriteLine("Sensing message through SMS");
            }
        }

        public class NotificationService
        {
            private IMessageService _messageService;
            public NotificationService(IMessageService _messageService)
            {
                this._messageService = _messageService;
            }

            public void PromotionalNotification()
            {
                this._messageService.SendMessage();
            }
        }
    }
}