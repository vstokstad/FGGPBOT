// FGGPBOTPublicModule.cs2020Vilhelm Stokstad

using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace app {
    public class PublicModule : ModuleBase<SocketCommandContext> {
        // Dependency Injection will fill this value in for us


        [Command("commands")]
        public async Task CommandsAsync(){
            await ReplyAsync(
                "!commands : this list of commands\n" +
                "!ping : ping the bot\n" +
                "!cat : MJAU\n" +
                "!friday : thank god its friday.\n" +
                "!userinfo : who are you?\n" +
                "!teams : what is the teams link for current lecture again!?!?!?\n" +
                "!canvas : canvas login page\n" +
                "!canvas-cal : link to subscribable canvas cal.\n" +
                "!canvas-list : Google Doc with all current Courses pulled from Canvas API");
        }

        [Command("ping")]
        [Alias("pong", "hello")]
        public Task PingAsync(){
            return ReplyAsync("pong!");
        }

        [Command("cat")]
        public async Task CatAsync(){
            try {
                // Get a stream containing an image of a cat
                Stream stream = await PictureService.GetCatPictureAsync();
                // Streams must be seeked to their beginning before being uploaded!

                stream.Seek(0, SeekOrigin.Begin);

                await Context.Channel.SendFileAsync(stream, "cat.png");
            }
            catch {
                await ThorAsync();
            }
        }

        [Command("thor")]
        public async Task ThorAsync(){
           string message = Emote.TryParse(":Thor:795573677189365790", out Emote thorEmote)? thorEmote.Name : ":thor:";
            await ReplyAsync(message: "mjau" + message, isTTS: false);
        }

        [Command("friday")]
        public async Task FridayAsync(){
            await ReplyAsync("https://www.youtube.com/watch?v=xZ8DCHA7G3Q&ab_channel=AxxAL@");
        }

        // Get info on a user, or the user who invoked the command if one is not specified
        [Command("userinfo")]
        public async Task UserInfoAsync(IUser user = null!){
            // ReSharper disable once ConstantNullCoalescingCondition
            user ??= Context.User;

            await ReplyAsync(user.ToString());
        }

        [Command("canvas-cal")]
        public Task CalendarAsync(){
            return ReplyAsync(
                "https://changemakereducations.instructure.com/feeds/calendars/user_fWCUnBCCeE0EDDrOo9fUTBv9hoZx0gdNxgHNWpTL.ics");
        }

        [Command("teams")]
        public Task TeamsAsync(){
            return ReplyAsync(MentionUtils.MentionUser(247783494141345793) +
                              " Do you have the Teams link for the current lecture?\n" +
                              "this is the link mentioned in Important Announcements at least:" +
                              "" +
                              " https://teams.microsoft.com/l/meetup-join/19%3ameeting_NmMzNjAzYzQtOTI2My00YjhlLWJjNjItMzUwYzMwODhlNDA1%40thread.v2/0?context=%7b%22Tid%22%3a%228f61bbde-d53d-41b6-95a1-ae26833d1cf1%22%2c%22Oid%22%3a%226c05ae9d-5d76-4d48-a33a-c1a7d5a7a53f%22%7d\n" +
                              "Hope it works!");
        }

        [Command("canvas")]
        public Task CanvasAsync(){
            return ReplyAsync("https://changemakereducations.instructure.com/login/canvas");
        }

        [Command("canvas-list")]
        public Task CanvasListAsync(){
            return ReplyAsync(
                "https://docs.google.com/spreadsheets/d/1Pubg1dHWfmMWzuYubT41zhrGqcTwdxZn7uFzK6P6HMc/edit?usp=sharing");
        }
    }
}