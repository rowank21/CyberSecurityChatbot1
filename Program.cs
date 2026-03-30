using CyberSecurityChatbot1.Services;
using System;
using System.Threading;

namespace CyberSecurityChatbot1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up console
            Console.Title = "🔐 Cybersecurity Awareness Bot";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Made window bigger for better display
            try
            {
                Console.WindowWidth = 90;
                Console.WindowHeight = 35;
                Console.BufferWidth = 90;
                Console.BufferHeight = 500;
            }
            catch {  }

            // Clear the screen at start
            Console.Clear();

            // Create chatbot instance
            ChatbotService chatbot = new ChatbotService();

            try
            {
                // Play voice greeting made on TTS MAKER 
                chatbot.PlayVoiceGreeting();

                // Small delay to let voice start before displaying art
                Thread.Sleep(500);

                // Display ASCII art and welcome message
                chatbot.DisplayWelcomeMessage();

                // Get user name
                string userName = chatbot.GetUserName();

                // Show personalized greeting
                chatbot.DisplayPersonalizedGreeting();

                // Show help topics
                chatbot.DisplaySectionHeader("TOPICS I CAN HELP WITH");
                Console.WriteLine("   🔐 Password Safety");
                Console.WriteLine("   🎣 Phishing Scams");
                Console.WriteLine("   🌐 Safe Browsing");
                Console.WriteLine("   🦠 Malware Protection");
                Console.WriteLine("   ℹ️ General Questions");
                Console.WriteLine("\n💡 Type 'exit' or 'bye' to quit");
                Console.WriteLine(new string('=', 60));

                // Start conversation
                chatbot.ProcessUserInput();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ Error: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
} 