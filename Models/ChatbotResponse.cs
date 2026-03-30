using System.Collections.Generic;

namespace CybersecurityChatbot.Models
{
    public class ChatbotResponse 
    {
        public int Id { get; set; }
        public string Keyword { get; set; } 
        public string Response { get; set; }
        public string Category { get; set; }

        public static List<ChatbotResponse> GetDefaultResponses()
        {
            return new List<ChatbotResponse>
            {
                new ChatbotResponse
                {
                    Id = 1,
                    Keyword = "hello",
                    Category = "Greeting",
                    Response = "Hello {0}! How can I help you with cybersecurity today?"
                },
                new ChatbotResponse
                {
                    Id = 2,
                    Keyword = "how are you",
                    Category = "Greeting",
                    Response = "I'm doing great, {0}! Ready to help you stay safe online!"
                },
                new ChatbotResponse
                {
                    Id = 3,
                    Keyword = "purpose",
                    Category = "General",
                    Response = "My purpose is to educate South African citizens about cybersecurity threats and how to stay safe online, {0}."
                },
                new ChatbotResponse
                {
                    Id = 4,
                    Keyword = "password",
                    Category = "Password Safety",
                    Response = @"🔐 PASSWORD SAFETY TIPS:
• Use at least 12 characters with mix of letters, numbers, and symbols
• Don't reuse passwords across different sites
• Use a password manager
• Enable two-factor authentication when available"
                },
                new ChatbotResponse
                {
                    Id = 5,
                    Keyword = "phishing",
                    Category = "Phishing",
                    Response = @"🎣 PHISHING AWARENESS:
• Never click suspicious links in emails
• Check sender email addresses carefully
• Be wary of urgent requests for personal information
• Hover over links to see real destination
• When in doubt, contact the company directly"
                },
                new ChatbotResponse
                {
                    Id = 6,
                    Keyword = "safe browsing",
                    Category = "Safe Browsing",
                    Response = @"🌐 SAFE BROWSING TIPS:
• Look for 'https://' in website addresses
• Don't download files from untrusted sources
• Keep your browser updated
• Use ad-blockers and security extensions
• Avoid public Wi-Fi for sensitive transactions"
                },
                new ChatbotResponse
                {
                    Id = 7,
                    Keyword = "malware",
                    Category = "Malware",
                    Response = @"🦠 MALWARE PROTECTION:
• Install reputable antivirus software
• Don't open suspicious email attachments
• Keep your operating system updated
• Regular backups of important data
• Be careful with USB drives from others"
                },
                new ChatbotResponse
                {
                    Id = 8,
                    Keyword = "help",
                    Category = "Help",
                    Response = @"📚 YOU CAN ASK ME ABOUT:
• Password safety
• Phishing scams
• Safe browsing
• Malware protection
• General cybersecurity tips
• My purpose
• How I'm doing"
                }
            };
        }
    }
}