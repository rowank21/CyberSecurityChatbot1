using CybersecurityChatbot.Models;
using CybersecurityChatbot1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;

namespace CyberSecurityChatbot1.Services
{
    public class ChatbotService
    {
        private List<ChatbotResponse> responses;
        private string userName;
        private Random random;

        public ChatbotService()
        {
            responses = ChatbotResponse.GetDefaultResponses();
            random = new Random();
        }

        public void PlayVoiceGreeting()
        {
            try
            {
                string audioPath = @"Audio\greeting.wav";
                if (System.IO.File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.Play();
                    }
                }
                else
                {
                    Console.WriteLine("Note: Voice greeting file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Note: Could not play voice greeting: {ex.Message}");
            }
        }

        public void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(AsciiArt.GetLogo());
            Console.ResetColor();
            Thread.Sleep(1000);
        }

        public void DisplayWelcomeMessage()
        {
            Console.Clear();
            DisplayAsciiArt();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("     WELCOME TO THE CYBERSECURITY AWARENESS BOT");
            Console.WriteLine(new string('=', 60));
            Console.ResetColor();

            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🔒 Your personal guide to online safety!");
            Console.ResetColor();

            Thread.Sleep(500);
        }

        public string GetUserName()
        {
            Console.Write("\n👤 Please enter your name: ");
            string input = Console.ReadLine()?.Trim();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("❌ Name cannot be empty. Please enter your name: ");
                Console.ResetColor();
                input = Console.ReadLine()?.Trim();
            }

            userName = input;
            return userName;
        }

        public void DisplayPersonalizedGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n╔════════════════════════════════════════════╗");
            Console.WriteLine($"║   Hello, {userName}! 👋                 ");
            Console.WriteLine($"║   I'm your Cybersecurity Assistant       ");
            Console.WriteLine($"╚════════════════════════════════════════════╝");
            Console.ResetColor();

            Thread.Sleep(1000);

            TypewriterEffect($"\nNice to meet you, {userName}! I'm here to help you stay safe online.\n", 40);
        }

        public void TypewriterEffect(string text, int delay)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        public void ProcessUserInput()
        {
            bool continueChat = true;

            while (continueChat)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\n{userName} >> ");
                Console.ResetColor();

                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    HandleInvalidInput();
                    continue;
                }

                if (input == "exit" || input == "quit" || input == "bye")
                {
                    continueChat = false;
                    DisplayGoodbye();
                    break;
                }

                string response = GetResponse(input);
                DisplayResponse(response);
            }
        }

        private string GetResponse(string input)
        {
            // Check for exact matches first
            foreach (var response in responses)
            {
                if (input.Contains(response.Keyword.ToLower()))
                {
                    return string.Format(response.Response, userName);
                }
            }

            // Check for partial matches
            foreach (var response in responses)
            {
                if (response.Keyword.Split(' ').Any(word => input.Contains(word)))
                {
                    return string.Format(response.Response, userName);
                }
            }

            // Random fallback responses
            string[] fallbackResponses = {
                $"I'm not sure about that, {userName}. Could you rephrase your question?",
                $"That's an interesting question, {userName}. Can you ask me about passwords, phishing, or safe browsing?",
                $"I don't have information about that, {userName}. Try asking about cybersecurity topics!",
                $"Hmm, I didn't quite understand. Ask me about password safety, phishing, or malware protection!"
            };

            return fallbackResponses[random.Next(fallbackResponses.Length)];
        }

        private void HandleInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ I didn't receive any input. Please type something!");
            Console.ResetColor();
        }

        private void DisplayResponse(string response)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nBot >> ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            TypewriterEffect(response + "\n", 30);
            Console.ResetColor();

            // Add decorative border after response
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
        }

        private void DisplayGoodbye()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(AsciiArt.GetShield());
            Console.WriteLine($"\nThank you for using the Cybersecurity Awareness Bot, {userName}!");
            Console.WriteLine("Remember: Stay vigilant, stay safe online! 🔐");
            Console.WriteLine("\nPress any key to exit...");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n╔════════════════════════════════════╗");
            Console.WriteLine($"║   {title,-30} ║");
            Console.WriteLine($"╚════════════════════════════════════╝");
            Console.ResetColor();
        }
    }
} 