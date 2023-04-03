using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotExperiments
{

    class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("5361388603:AAEoyD3e2VhTTeTCUjJyAtAIVWjLlzk0Ebo");
        static int nomernedel = 0;
        static int kurs = 0;
        static int napraw = 0;
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Message message1;

            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                message1 = message;
                if (message1.Text.ToLower() == "/start")
                {
                    var markup = new ReplyKeyboardMarkup(new[]
                     {
                        new KeyboardButton("Расписание")
                    });
                    markup.OneTimeKeyboard = true;
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите, что вас интересует", replyMarkup: markup);
                    return;
                }
                ////////разбивка по направлениям///////////////
                if (message1.Text.ToLower() == "расписание")
                {
                    var markup = new ReplyKeyboardMarkup(new[]
                    {
                        new KeyboardButton("ИТ"),
                        new KeyboardButton("ПИ"),
                        new KeyboardButton("БИ")
                    });
                    markup.OneTimeKeyboard = true;
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите направление", replyMarkup: markup);
                    return;
                }

                switch (message1.Text.ToLower())
                {
                    case "ит":
                        {
                            napraw = 0;
                            var markup = new ReplyKeyboardMarkup(new[]
                   {
                       new KeyboardButton("Первый курс"),
                       new KeyboardButton("Второй курс"),
                       new KeyboardButton("Третий курс"),
                       new KeyboardButton("Четвертый курс")

                   });
                            markup.OneTimeKeyboard = true;
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите курс", replyMarkup: markup);
                            return;
                        }
                    case "пи":
                        {
                            napraw = 1;
                            var markup = new ReplyKeyboardMarkup(new[]
                   {
                       new KeyboardButton("Первый курс"),
                       new KeyboardButton("Второй курс"),
                       new KeyboardButton("Третий курс"),
                       new KeyboardButton("Четвертый курс")

                   });
                            markup.OneTimeKeyboard = true;
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите курс", replyMarkup: markup);
                            return;
                        }
                    case "би":
                        {
                            napraw = 2;
                            var markup = new ReplyKeyboardMarkup(new[]
                       {
                       new KeyboardButton("Первый курс"),
                       new KeyboardButton("Второй курс"),
                       new KeyboardButton("Третий курс"),
                       new KeyboardButton("Четвертый курс")

                   });
                            markup.OneTimeKeyboard = true;
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите курс", replyMarkup: markup);
                            return;
                        }
                }

                switch (message1.Text.ToLower())
                {
                    case "первый курс":
                        {
                            kurs = 0;
                            var markup = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton("первая неделя"),
                    new KeyboardButton("вторая неделя")
                });
                            markup.OneTimeKeyboard = true;
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите неделю", replyMarkup: markup);
                            return;
                        }
                    case "второй курс":
                        {
                            kurs = 1;
                            var markup = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton("первая неделя"),
                    new KeyboardButton("вторая неделя")
                });
                            markup.OneTimeKeyboard = true;
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите неделю", replyMarkup: markup);
                            return;
                        }
                    case "третий курс":
                        {
                            kurs = 2;
                            var markup = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton("первая неделя"),
                    new KeyboardButton("вторая неделя")
                });
                            markup.OneTimeKeyboard = true;
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите неделю", replyMarkup: markup);
                            return;
                        }
                    case "четвертый курс":
                        {
                            kurs = 3;
                            var markup = new ReplyKeyboardMarkup(new[]
                {
                    new KeyboardButton("первая неделя"),
                    new KeyboardButton("вторая неделя")
                });
                            markup.OneTimeKeyboard = true;
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите неделю", replyMarkup: markup);
                            return;
                        }
                }


                if (message1.Text.ToLower() == "первая неделя")
                {
                    nomernedel = 0;
                    switch (napraw)
                    {
                        case 0:
                            {

                                switch (kurs)
                                {
                                    case 0:
                                        {

                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                        new KeyboardButton("ит2101"),
                                        new KeyboardButton("ит2102"),
                                        new KeyboardButton("ит2103"),
                                        new KeyboardButton("ит2104")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                    case 1:

                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                        new KeyboardButton("ит2001"),
                                        new KeyboardButton("ит2002"),
                                        new KeyboardButton("ит2003") });
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                    case 2:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                        new KeyboardButton("ит1901"),
                                        new KeyboardButton("ит1902"),
                                        new KeyboardButton("ит1903")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                    case 3:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("ит1821"),
                                                new KeyboardButton("ит1822"),
                                                new KeyboardButton("ит1823")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                }
                                return;
                            }
                        case 1:
                            {

                                switch (kurs)
                                {
                                    case 0:
                                        {

                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("пи2101"),
                                                new KeyboardButton("пи2102"),
                                                new KeyboardButton("пи2103"),
                                                new KeyboardButton("пи2104")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 1:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("пи2001"),
                                                new KeyboardButton("пи2002"),
                                                new KeyboardButton("пи2003")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 2:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("пи1901"),
                                                new KeyboardButton("пи1902"),
                                                new KeyboardButton("пи1903")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 3:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("пи1821"),
                                                new KeyboardButton("пи1822")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                }
                                return;
                            }
                        case 2:
                            {

                                switch (kurs)
                                {
                                    case 0:
                                        {

                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("би2101"),
                                                new KeyboardButton("би2102"),
                                                new KeyboardButton("би2103")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 1:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("би2001")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 2:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("би1901")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 3:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("би1801")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                }
                                return;
                            }

                    }
                }
                if (message1.Text.ToLower() == "вторая неделя")
                {
                    nomernedel = 1;
                    switch (napraw)
                    {
                        case 0:
                            {

                                switch (kurs)
                                {
                                    case 0:
                                        {

                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                        new KeyboardButton("ит2101"),
                                        new KeyboardButton("ит2102"),
                                        new KeyboardButton("ит2103"),
                                        new KeyboardButton("ит2104")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                    case 1:

                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                        new KeyboardButton("ит2001"),
                                        new KeyboardButton("ит2002"),
                                        new KeyboardButton("ит2003") });
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                    case 2:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                        new KeyboardButton("ит1901"),
                                        new KeyboardButton("ит1902"),
                                        new KeyboardButton("ит1903")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                    case 3:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("ит1821"),
                                                new KeyboardButton("ит1822"),
                                                new KeyboardButton("ит1823")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                }
                                return;
                            }
                        case 1:
                            {

                                switch (kurs)
                                {
                                    case 0:
                                        {

                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("пи2101"),
                                                new KeyboardButton("пи2102"),
                                                new KeyboardButton("пи2103"),
                                                new KeyboardButton("пи2104")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 1:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("пи2001"),
                                                new KeyboardButton("пи2002"),
                                                new KeyboardButton("пи2003")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 2:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("пи1901"),
                                                new KeyboardButton("пи1902"),
                                                new KeyboardButton("пи1903")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 3:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("пи1821"),
                                                new KeyboardButton("пи1822")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                }
                                return;
                            }
                        case 2:
                            {

                                switch (kurs)
                                {
                                    case 0:
                                        {

                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("би2101"),
                                                new KeyboardButton("би2102"),
                                                new KeyboardButton("би2103")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 1:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("би2001")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 2:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("би1901")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;
                                        }
                                    case 3:
                                        {
                                            var markup = new ReplyKeyboardMarkup(new[]
                                           {
                                                new KeyboardButton("би1801")});
                                            markup.OneTimeKeyboard = true;
                                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите группу", replyMarkup: markup);
                                            return;

                                        }
                                }
                                return;
                            }

                    }
                }
                switch (message1.Text.ToLower())
                {
                    //ит
                    case "ит2101": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ2101", nomernedel); return; }
                    case "ит2102": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ2102", nomernedel); return; }
                    case "ит2103": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ2103", nomernedel); return; }
                    case "ит2104": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ2104", nomernedel); return; }
                    case "ит2001": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ2001", nomernedel); return; }
                    case "ит2002": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ2002", nomernedel); return; }
                    case "ит2003": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ2003", nomernedel); return; }
                    case "ит1901": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ1902", nomernedel); return; }
                    case "ит1902": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ1902", nomernedel); return; }
                    case "ит1903": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ1903", nomernedel); return; }
                    case "ит1821": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ1821", nomernedel); return; }
                    case "ит1822": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ1822", nomernedel); return; }
                    case "ит1823": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ИТ1823", nomernedel); return; }
                    //пи
                    case "пи2101": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ2101", nomernedel); return; }
                    case "пи2102": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ2102", nomernedel); return; }
                    case "пи2103": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ2103", nomernedel); return; }
                    case "пи2104": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ2104", nomernedel); return; }
                    case "пи2001": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ2001", nomernedel); return; }
                    case "пи2002": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ2002", nomernedel); return; }
                    case "пи2003": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ2003", nomernedel); return; }
                    case "пи1901": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ1902", nomernedel); return; }
                    case "пи1902": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ1902", nomernedel); return; }
                    case "пи1903": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ1903", nomernedel); return; }
                    case "пи1821": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ1821", nomernedel); return; }
                    case "пи1822": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=ПИ1822", nomernedel); return; }
                    //би
                    case "би2101": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=БИ2101", nomernedel); return; }
                    case "би2102": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=БИ2102", nomernedel); return; }
                    case "би2103": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=БИ2103", nomernedel); return; }
                    case "би2001": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=БИ2001", nomernedel); return; }
                    case "би1901": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=БИ1901", nomernedel); return; }
                    case "би1801": { parser(@"https://s.kubsau.ru/?type_schedule=1&val=БИ1801", nomernedel); return; }


                }

                await botClient.SendTextMessageAsync(message.Chat.Id, "Что-то пошло не по плану, в следующем сообщении введите команду /start");
            }
            void parser(string url, int nomernedel1)
            {
                // Создание документа
                var txtHTML = GetPage(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(txtHTML);
                int index = txtHTML.IndexOf("<h3");
                var txtHTMLdlyizmen = txtHTML.Remove(0, index);
                string[] nedelrasp = new string[2];
                ///Отедление недели
                for (int nedel = 0; nedel < 2; nedel++)
                {
                    var txtnedel = FindText(txtHTMLdlyizmen, @"<h3 class=", @"</h3>");
                    index = txtHTMLdlyizmen.IndexOf(txtnedel);
                    txtHTMLdlyizmen = txtHTMLdlyizmen.Remove(0, index);
                    txtnedel = Obrezkaslov(txtnedel);
                    for (int j = 1; j <= 5; j++)
                    {
                        ///Отделение дня
                        var txtden = FindText(txtHTMLdlyizmen, @"<h4 class=", @"</h4>");
                        index = txtHTMLdlyizmen.IndexOf(txtden);
                        txtHTMLdlyizmen = txtHTMLdlyizmen.Remove(0, index);
                        txtden = Obrezkaslov(txtden);
                        txtnedel += "\n" + txtden;
                        txtnedel += "\n______________________________________";
                        ///Отделение пар
                        for (int i = 1; i <= 6; i++)
                        {
                            var txtpara = FindText(txtHTMLdlyizmen, @"<tr>", @"</tr>");
                            index = txtHTMLdlyizmen.IndexOf(txtpara);
                            txtHTMLdlyizmen = txtHTMLdlyizmen.Remove(0, index);
                            string txttime;
                            string txtlekci;
                            string txtpredmet;
                            string txtauditor;
                            bool result;
                            txttime = FindText(txtpara, @"<td class=", @"</td>");
                            index = txtpara.IndexOf(txttime);
                            txtpara = txtpara.Remove(0, index);
                            index = txttime.IndexOf(">");
                            txttime = txttime.Remove(0, index + 1);
                            result = txttime.Contains("br");
                            if (result)
                                txttime = txttime.Replace("<br>", " - ");
                            result = false;
                            txtlekci = FindText(txtpara, @"<td class=", @"></td>");
                            index = txtpara.IndexOf("></td>");
                            txtpara = txtpara.Remove(0, index + 6);
                            txtlekci = txtlekci.TrimStart();
                            result = txtlekci.Contains("yes");
                            if (result)
                            {
                                txtlekci = "Лекция";
                                txtpredmet = FindText(txtpara, @">", @"<span class");
                                txtpredmet = FindText(txtpredmet, @"<strong>", @"</strong>");
                                index = txtpara.IndexOf(txtpredmet);
                                txtpara = txtpara.Remove(0, index);
                                txtauditor = FindText(txtpara, @"<span>", @"</span>");
                            }
                            else
                            {
                                txtlekci = "Практика";
                                txtpredmet = FindText(txtpara, @"<td", @"</td>");
                                index = txtpara.IndexOf("</td>");
                                txtpara = txtpara.Remove(0, index);
                                txtpredmet = FindText(txtpredmet, @">", @"<");
                                if (txtpredmet == "\n                ")
                                { txtpredmet = "-"; }
                                result = txtpredmet.Contains("\n                ");
                                if (result)
                                    txtpredmet = txtpredmet.Replace("\n                ", "");
                                txtauditor = FindText(txtpara, @"<td", @"</td>");
                                index = txtpara.IndexOf("</td>");
                                txtpara = txtpara.Remove(0, index);
                                txtauditor = FindText(txtauditor, @"<span>", @"</span>");
                                if (txtauditor == "")
                                    txtauditor = "-";
                            }
                            result = txtauditor.Contains("br");
                            if (result)
                            {
                                txtauditor = txtauditor.Replace("<br>", ", ");
                            }
                            txtauditor = Obrezkaslov(txtauditor);
                            result = false;
                            if ((txtpredmet != "-") && (txtauditor != "-"))
                            {
                                txtnedel += "\n" + txttime + "\n" + txtlekci + "\n" + txtpredmet + "\n" + txtauditor;
                                txtnedel += "\n............";
                            }
                        }
                    }
                    nedelrasp[nedel] = txtnedel;
                }
                botClient.SendTextMessageAsync(message1.Chat.Id, nedelrasp[nomernedel1]);
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));// выводит ошибку с сервера телеги
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // получает все виды обновлений с сервера телеги
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
        static String FindText(string source, string prefix, string suffix)
        {
            var prefixPosition = source.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
            var suffixPosition = source.IndexOf(suffix, prefixPosition + prefix.Length, StringComparison.OrdinalIgnoreCase);
            if ((prefixPosition >= 0) && (suffixPosition >= 0) && (suffixPosition > prefixPosition) && ((prefixPosition + prefix.Length) <= suffixPosition))
            {
                return source.Substring(prefixPosition + prefix.Length, suffixPosition - prefixPosition - prefix.Length);
            }
            else
            {
                return String.Empty;
            }
        }

        static string GetPage(string url)
        {
            var result = String.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    StreamReader streamReader;
                    if (response.CharacterSet != null)
                        streamReader = new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
                    else
                        streamReader = new StreamReader(responseStream);
                    result = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                response.Close();
            }
            return result;
        }

        static string Obrezkaslov(string stroka)
        {
            int nomer = stroka.IndexOf(">");
            stroka = stroka.Remove(0, nomer + 1);
            return stroka;
        }
    }
}
